A console-based Task Manager application built with C# to practice Object-Oriented Programming, clean separation of responsibilities, polymorphism, repository pattern, file persistence, and error handling.

## Overview

This project started as a simple console-based task manager and was gradually developed into a more structured application.

The application allows users to create, manage, search, filter, and complete different types of tasks while persisting task data in a local text file.

The main goal of this project was not just to build a Task Manager, but to understand how C# OOP concepts can be applied to a real application.

## Features

- Create Work Tasks
- Create Personal Tasks
- View All Tasks
- Update Tasks
- Delete Tasks
- Search Tasks
- Live Task Search
- Mark Tasks as Complete
- Filter Tasks by Status
- Persistent data storage using a text file
- Load tasks when the application starts
- Save changes automatically
- Input validation
- File data validation
- Exception handling
- Logging

## Task Types

The application currently supports two task types:

### Work Task

A Work Task contains:

- ID
- Title
- Company
- Completion Status

### Personal Task

A Personal Task contains:

- ID
- Title
- Person
- Completion Status

Both task types inherit from the common `TaskItem` abstract class.

## Architecture

The application separates responsibilities between different classes.


                    TaskItem
                   (abstract)
                       │
             ┌─────────┴─────────┐
             │                   │
         WorkTask          PersonalTask
             │                   │
             └─────────┬─────────┘
                       │
                 TaskManager
                  /         \
                 /           \
       ITaskRepository       Logger
              │
              │
     FileTaskRepository
              │
              ▼
          tasks.txt


## TaskItem

TaskItem is an abstract base class that contains the properties and behavior shared by all tasks.

It also defines abstract methods that child classes must implement.

WorkTask and PersonalTask

These classes inherit from TaskItem and provide their own implementations for task-specific behavior.

This allows the application to use polymorphism when working with different task types.

## TaskManager

TaskManager contains the application's business logic.

It is responsible for operations such as:

Adding tasks
Updating tasks
Deleting tasks
Searching tasks
Filtering tasks
Completing tasks
Logging business operations

## Repository

The repository is responsible for data access.

ITaskRepository defines the operations required by the application, while FileTaskRepository provides the actual implementation using a local text file.

TaskManager
     │
     ▼
ITaskRepository
     │
     ▼
FileTaskRepository
     │
     ▼
tasks.txt

This separation keeps business logic independent from the storage implementation.

## OOP Concepts Used

This project was built to practice several important C# and OOP concepts.

## Abstraction

TaskItem is an abstract class because a generic TaskItem should not be instantiated directly.

internal abstract class TaskItem

## Inheritance

WorkTask and PersonalTask inherit from TaskItem.

internal class WorkTask : TaskItem
internal class PersonalTask : TaskItem

## Polymorphism

Different task types can be handled through the common TaskItem type while providing different implementations.

For example:

public abstract void DisplayDetails();

Each task type implements this method differently.

## Encapsulation

Task data is controlled through properties and methods.

For example, the task ID cannot be directly changed from outside the class:

public int Id { get; private set; }

The ID is assigned through:

SetId()

## Interfaces

ITaskRepository defines the contract for task data access.

This allows TaskManager to depend on an abstraction instead of a specific storage implementation.

## Composition

TaskManager uses other objects such as the repository and logger instead of inheriting from them.

TaskManager
 ├── ITaskRepository
 └── Logger

## Repository Pattern

The repository pattern separates data access from business logic.

This makes it possible to change the storage mechanism later without rewriting the main business logic.

## Data Persistence

Tasks are stored in a local tasks.txt file.

The current format is:

Id|Type|Title|Company/Person|Status

Example:

1|Work|Debug a Feature|Microsoft|True
3|Personal|Buying a Laptop|Basir|True
4|Work|Building a Feature|Software House|False

Tasks are loaded when the repository is created and saved whenever task data changes.

## Error Handling

The application validates data loaded from the file before creating task objects.

It checks:

Column count
Task ID
Completion status
Task type

Invalid records are skipped instead of causing the entire application to stop.

The application also uses exception handling as an additional safety layer when processing file data.

## Search and Filtering

The application supports normal task searching as well as live search.

Users can also filter tasks by completion status:

1. All Tasks
2. Completed Tasks
3. Incompleted Tasks

## Logging

A separate Logger class is used to record important business operations.

Examples include:

Task Added
Task Updated
Task Deleted
Task Completed

The logger is used by TaskManager, keeping logging separate from the repository's data-access responsibility.

## Technologies

C#
.NET
LINQ
Object-Oriented Programming
File I/O
Interfaces
Abstract Classes
Inheritance
Polymorphism
Repository Pattern
Exception Handling

## Project Structure

Task_Manager/
│
├── Program.cs
├── TaskManager.cs
├── TaskItem.cs
├── WorkTask.cs
├── PersonalTask.cs
├── ITaskRepository.cs
├── FileTaskRepository.cs
├── Logger.cs
│
└── tasks.txt

## How to Run

Clone the repository.
Open the project in Visual Studio.
Build the project.
Run the application.
Use the console menu to manage tasks.

## Screenshots

## Main Menu

<img width="977" height="480" alt="MainMenu" src="https://github.com/user-attachments/assets/a8bc2e4e-c0e0-4d68-831e-a4828b0c5d02" />


## All Tasks

<img width="982" height="417" alt="All Tasks" src="https://github.com/user-attachments/assets/2e62286c-eaf3-4c67-adfd-c132837ec3b4" />


## Update Task

<img width="980" height="507" alt="Update" src="https://github.com/user-attachments/assets/2f1dcfa3-a30b-41b4-b559-81c3c721665f" />


## Filter Tasks by Status

<img width="980" height="243" alt="Filter" src="https://github.com/user-attachments/assets/0dd8db28-ec4a-41da-9ade-bfa115569b33" />


## Live Task Search

<img width="979" height="180" alt="Live Search" src="https://github.com/user-attachments/assets/58a3337d-62c9-4e45-b1cd-57cf32b101c9" />


## What I Learned

This project helped me understand how to move from a simple console application toward a more structured C# application.

Key concepts practiced:

Designing classes using OOP principles
Abstraction and inheritance
Polymorphism
Encapsulation
Interfaces
Composition
Separating business logic from data access
Repository Pattern
Working with collections
LINQ
File I/O
Data persistence
Input validation
Exception handling
Logging
Git and GitHub workflow

## Future Improvements

Possible future improvements include:

Replace text-file storage with JSON
Add task priorities
Add due dates
Add task categories
Add more task types
Add unit tests
Introduce dependency injection
Improve the console UI
Replace file storage with a database
