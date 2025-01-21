# 010 Custom Responses

## Lecture

[![# Custom Responses](https://img.youtube.com/vi/yQTp4Gg767Y/0.jpg)](https://www.youtube.com/watch?v=yQTp4Gg767Y)

## Instructions

In this assignment you will implement handling an exception and returning a custom response in HomeEnergyApi.

In `HomeEnergyApi/Controllers/HomesController.cs`...

- Create a new HTTP Get Method.
  - The route for this GET should be `/Homes/HackApi`
  - This method should throw an exception.
  - When an exception is thrown, this method should respond with a custom status code.
    - The status code should have the code `500`
    - The status code should have the error `Internal Server Error`
    - The status code should have the message `Please don't try to hack me...`
    - You will need to return these values exactly as written(Capitalization, spacing, etc.)

Additional Information:

- You should ONLY make code changes in `HomeEnergyApi/Controllers/HomesController.cs` to complete this assignment.

## Building toward CSTA Standards:

- Explain how abstractions hide the underlying implementation details of computing systems embedded in everyday objects (3A-CS-01) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards

## Resources

- https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
- https://en.wikipedia.org/wiki/Request%E2%80%93response
- https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.statuscode?view=aspnetcore-8.0
- https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponse.headers?view=aspnetcore-8.0#microsoft-aspnetcore-http-httpresponse-headers

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
