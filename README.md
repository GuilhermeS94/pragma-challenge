# pragma-challenge
Repo de teste para Db Server / Pragma Team

## Framework & languages
This project uses
* .Net Core 5.0 / C#
## Available scripts

### Root
- `dotnet run` - Start the server on (http://localhost:5000)
- Swagger docs - Open url (http://localhost:5000/swagger)
- `dotnet test` - Run unit tests

## History
<ol>
    <li>Add .gitignore file</li>
    <li>First commit running and compiling code</li>
    <li>Create Postman Files/Collections to test endpoint.</li>
    <li>Add Swagger for API documentation. Framework SwashBuckle.AspNetCore for auto generating.</li>
    <li>Add Middleware and model for global exception and return object pattern for front.</li>
    <li>Adding NewtonSoft.Json for property name and objects serializations.</li>
    <li>Adding Scoped Interfaces with classes with singles and easy understanding functions.</li>
    <li>Adding unit tests, `dotnet test` command</li>
    <li>Adding unit tests, for services, refactor of execute method from CheckBeerStatusService.</li>
</ol>

### IF I have time...
<ul>
    <li>Create a react hook architecture for requests, beacuse the front should use more than one api, and I like to call them separetly, but following a pattern.</li>
    <li>Create a react hook to call de backend Products, using the previous architecture.</li>
    <li>Refactor about set status when I get the current temperature from sensor, I didnt like the method.</li>
    <li>Create tests for the controller and the new front components.</li>
    <li>Create a method, logic and tests for update a single status beer each time, when it have to update, like there is some time to the beer lose degrees, and the range between de min and max are different, so it means that could have different moments to check sensor.</li>
<ul>

### Failures
I tried to create the component in front to make the request calls, but Im not succeeded about typescript samples and make it work with javascript ClientApp.
I dont know how to use libs in .net core, every time I have tried, it brought me error that I didnt find how to solve, so Im used to organize my classes and Tests in folders.

### Point of view
The application is simple, but the coverage was improved, there is at least one at the front, and I created the backend ones. The way it was build, if needed to create another method, so much code needs to be rewrite and now, there is some reusable ones, making the next feature deliver faster.