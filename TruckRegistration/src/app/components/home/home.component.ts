import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeService } from "../../core/services/home.service";


@Component({
    selector: 'home',
    templateUrl: 'home.component.html',
})

export class HomeComponent implements OnInit {

    isEditing: boolean;
    isAdding: boolean;
    result: any[] = [];

    models = ['FH', 'FM'];
    createForm = this.formBuilder.group({
        Desc: '',
        Year: '',
        YearModel: '',
        Model: '',
        Chassi: ''
    });

    editForm = this.formBuilder.group({});

    constructor(private hserv: HomeService, private formBuilder: FormBuilder) {

    }

    ngOnInit(): void {

        this.loadTrucks();
    }

    onSubmit(): void {
        this.hserv.CreateTruck(this.createForm.value).subscribe((response) => {
            alert("truck created!");
            this.createForm.reset();
            this.isAdding = false;
            this.loadTrucks();
        }, (error) => {
            alert(`error: ${error._body}`);
        });

    }

    editTruck(truck: any): void {

        this.editForm = this.formBuilder.group({
            Id: truck.id,
            Desc: truck.desc,
            Year: truck.year,
            YearModel: truck.yearModel,
            Model: truck.model,
            Chassi: truck.chassi
        });

        this.isEditing = true;
    }

    onEditSubmit(): void {
        this.hserv.EditTruck(this.editForm.value).subscribe((response) => {
            alert("truck updated!");
            this.editForm.reset();
            this.isEditing = false;
            this.loadTrucks();
        }, (error) => {
            debugger;
            alert(`error: ${error._body}`);
        });
    }

    cancelEdit(): void {
        this.editForm.reset();
        this.isEditing = false;
    }

    addTruck(): void {
        this.isAdding = true;
    }

    removeTruck(truck: any): void {
        if (confirm("Are you sure?")) {

            this.hserv.RemoveTruck(truck.id).subscribe((response) => {
                alert("truck removed!");
                this.editForm.reset();
                this.isEditing = false;
                this.loadTrucks();
            }, (error) => {
                debugger;
                alert(`error: ${error._body}`);
            });
        }
    }

    cancelTruck(): void {
        this.createForm.reset();
        this.isAdding = false;
    }

    loadTrucks(): void {
        this.hserv.GetTruckList().subscribe(response => this.result = response);
    }

}


