# Applicants


This is a Solution designed for recording Applicants, to start the solution first run migration by running command update-database and set infrastructure the startup project at console manager.

I applied clean architecture, as shown at this link https://csharpcorner-mindcrackerinc.netdna-ssl.com/article/introduction-to-clean-architecture-and-implementation-with-asp-net-core/Images/pic2-1.png .

At the application layer, I used CQS Pattern to separate between commands and queries.

I used a mediator pattern with CQS to prevent tight coupling on CQS handlers.
I used fluent validation and used also automapper.
