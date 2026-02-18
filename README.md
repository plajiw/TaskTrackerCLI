# TaskTrackerCLI

## English

TaskTrackerCLI is a command-line interface application built to manage personal tasks.
This project is an implementation of the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh),
focusing on clean architecture and the application of behavioral design patterns.

**Architecture**
The project employs lexical analysis to process user input, transforming raw character sequences into structured tokens—such as keywords, identifiers, and literals.
This is integrated with the Command Design Pattern, which decouples the input parsing logic from the actual task execution. By isolating each operation into its own command object, the architecture ensures the system is modular, maintainable, and easily scalable for future feature additions.

## Portuguese

TaskTrackerCLI é uma aplicação de interface de comando construida para gerenciar tarefas pessoais.
O projeto é uma implementação do desafio [task-tracker](https://roadmap.sh/projects/task-tracker) [roadmap.sh](https://roadmap.sh).

**Arquitetura**
O projeto utiliza um recurso de análise léxica, processando a sequência de caracteres inserida pelo usuário para transformá-la em uma sequência de tokens (unidades significativas como palavras-chave, identificadores e literais).
Complementando essa estrutura, foi aplicado o Command Design Pattern para organizar a execução das funcionalidades. Essa abordagem separa a lógica de processamento de entrada da execução propriamente dita, resultando em um código modular, de fácil manutenção e altamente extensível para novos comandos.
