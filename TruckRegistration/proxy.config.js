const proxy = [
    {
      context: '/api',
      target: 'http://localhost:63996',
      pathRewrite: {'^/api' : ''}
    }
  ];module.exports = proxy;