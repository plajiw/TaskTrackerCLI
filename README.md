# TaskTrackerCLI

TaskTrackerCLI is a command-line interface application built to manage personal tasks.
This project is an implementation of the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh),
focusing on clean architecture and the application of behavioral design patterns.

Architecture
The project is structured around the Command Design Pattern. This choice allows for the decoupling of the object that invokes the operation from the one that knows how to perform it.