# Remind.ME App

## Functional Requirement
 * Develop a system that I can use to create reminders.
 * It should have an ability to create a new user.
 * In future. it should have an ability to create reminders for different things like Birthdays, Anniversaries, Tax Dates etc.

## Assumptions

## Current Limitations
 * There is no UI. Swagger UI can be used to push data to the database
 * There is no actual email being sent.
 * There are no validations on the data.
 
## Technical Requirements
 * The system should have a database.
 * The system should be scalable.
 * The system should have different microservices that can be changed and deployed without impacting other parts of the system.
 
 ## Technologies Used
 * All code will be in .Net Core 3.1
 * Mongo DB database will be used to save the data
 * RabbitMQ will be used to host the queues 
 * Seq will be used for logging.
 
 ## System Architecture
 
 ![Alt text](https://github.com/rramname/Remind.ME/blob/main/system.png "Title")

 
 ## Future Enhancements
 * API Gateway will be implemented to take advantage of additional   security and logging features
 * Multiple subscriber instances can be created to point to the queue for system scalability
 * Can be made cloud native with Azure functions, postgresql etc
 
 ## Setup Instruction
 * Navigate to Remind.ME\docker-compose.yaml and run "docker-compose up"
   This will setup mongo DB database , User service at port 5005 and Birthday service at port 5006. 
   User service (http://localhost:5005/swagger/index.html) can be used to create users
   Birthday service (http://localhost:5006/swagger/index.html) can be used to create users
 * Navigate to Remind.ME\Infrastructure\RabbitMQ and run "docker-compose up"
   This will setup rabitMQ server at port http://localhost:15672/
 * Now we can run Publisher service and Subscriber services using dotnet run at the root. (Dockerizing this is coming soon....)
   Publisher will run in a loop and will hit mongo db database every 5 second to check if there are any message and if there are, it will send those to the queue.
   As of now, in the config file, birthday queue has been specified. Different subscriber instance can be created for different type of reminders like Anniversary.
  
 
