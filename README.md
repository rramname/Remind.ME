# Remind.ME App

## Functional Requirement
 * Develop a system that I can use to create reminders.
 * It should have an ability to create a new user.
 * It should have an ability to create reminders for different things like Birthdays, Anniversaries, Tax Dates etc.

## Assumptions

## Current Limitations
 * There is no UI. Swagger UI can be used to push data to the database
 
## Technical Requirements
 * The system should have a database.
 * The system should be scalable.
 * The system should have different microservices that can be changed and deployed without impacting other parts of the system.
 
 ## Technologies Used
 * All code will be in .Net Core 3.1
 * Mongo DB database will be used to save the data
 * RabbitMQ will be used to host the queues 
 
 ## System Architecture
 
 https://github.com/rramname/Remind.ME/blob/main/system.png
 
 ## Future Enhancements
 * API Gateway will be implemented to take advantage of additional   security and logging features
 * Multiple subscriber instances can be created to point to the queue for system scalability
 
 ## Setup Instruction
  
 
