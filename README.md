# TaskTrackerCLI

## English

TaskTrackerCLI is a robust command-line interface application designed for efficient personal task management. This project is a high-level implementation of the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).
Unlike simple CLI tools, this project is built with a focus on Clean Architecture and Behavioral Design Patterns, treating user input through a professional processing pipeline.

## Architecture & Design

The engine of this application follows a "mini-compiler" flow to ensure stability and scalability:

- Lexical Analysis (Lexer): Processes raw strings into meaningful Tokens (Keywords, Literals, Flags).
- Parsing (Parser): Validates the token stream and builds a structured Command object.
- Command Pattern: Decouples the request from the execution. Each command is an isolated handler.

## Portuguese

TaskTrackerCLI é uma aplicação de linha de comando robusta, construída para um gerenciamento de tarefas eficiente. Este projeto é uma implementação avançada do desafio [task-tracker](https://roadmap.sh/projects/task-tracker) do [roadmap.sh](https://roadmap.sh/).
Diferente de ferramentas CLI simples, este projeto foca em Arquitetura Limpa e Padrões de Projeto Comportamentais, tratando a entrada do usuário através de um pipeline de processamento profissional.

## Arquitetura e Design

O motor desta aplicação segue o fluxo de um "mini-compilador" para garantir estabilidade e escalabilidade:

- Análise Léxica (Lexer): Processa strings brutas em Tokens significativos (Palavras-chave, Literais, Flags).
- Análise Sintática (Parser): Valida a sequência de tokens e constrói um objeto Command estruturado.
- Command Pattern: Desacopla a requisição da execução. Cada comando é um handler isolado.
