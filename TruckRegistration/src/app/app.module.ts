import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, Http, XHRBackend, RequestOptions } from '@angular/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { routing } from './app.router';

import { HomeService } from "./core/services/home.service";

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        routing
    ],
    exports: [
        FormsModule
    ],
    declarations: [
        HomeComponent,
        AppComponent
    ],
    providers: [HomeService],
    bootstrap: [AppComponent]
})
export class AppModule { }
