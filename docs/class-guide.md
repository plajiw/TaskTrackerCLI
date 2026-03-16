# Class Guide

## Como preencher este arquivo

- Objetivo: descrever a funcionalidade de cada classe do projeto de forma padronizada.
- Estilo: manter linguagem direta, tópicos curtos e foco na responsabilidade da classe.
- Regra: preservar a lógica atual da implementação e complementar apenas o que estiver confuso ou incompleto.

```md

## Template para próximas classes

## NomeDaClasse.cs

- Classe/arquivo: `NomeDaClasse.cs`
- Tipo: (ex: domínio, infraestrutura, handler, parser, ui, etc.)
- Responsabilidade principal: (descrever em 1 frase)

### O que ela faz

- (ação principal 1)
- (ação principal 2)
- (ação principal 3)

### Entradas e saídas

- Entrada: (dados/parâmetros recebidos)
- Saída: (retorno, efeito colateral, persistência, impressão em console, etc.)

### Dependências diretas

- (classe/interface 1)
- (classe/interface 2)

### Observações

- (regra importante, limitação, detalhe de comportamento)

---

```

---

## Program.cs

- Classe/arquivo: `Program.cs`
- Tipo: ponto de entrada da aplicação
- Responsabilidade principal: inicializar dependências e iniciar o fluxo da CLI

### Fluxo principal (`Main()`)

1. Contém o método privado e estático `Main()`.
2. Inicializa o `JsonContext` pelo construtor padrão, obtendo o caminho do diretório temporário do usuário para montar o caminho do arquivo JSON `tasktracker.json`, usado como banco de dados.
3. Caso o arquivo ainda não exista, cria sua primeira instanciação com valor interno `[]`.
4. Prepara o repositório com `JsonTaskItemRepository`, recebendo `JsonContext` como parâmetro; esse repositório é usado na instanciação do dispatcher.
5. Instancia o `Parser`, responsável por realizar a análise sintática e interpretar os argumentos de entrada no terminal.
6. Instancia o `CommandDispatcher`, responsável por supervisionar os comandos oferecidos no terminal.
7. Instancia o `CliApplication` com dispatcher e parser; como essas dependências são criadas no bootstrap da aplicação, essa inicialização ocorre uma única vez por execução.
8. Executa `Run()` para iniciar a aplicação.

### Dependências diretas

- `JsonContext`
- `JsonTaskItemRepository`
- `Parser`
- `CommandDispatcher`
- `CliApplication`

---

## CliApplication.cs

- Classe/arquivo: `CliApplication.cs`
- Tipo: aplicação — orquestra o loop principal da CLI
- Responsabilidade principal: manter o ciclo de leitura de input, coordenar análise léxica e sintática, e despachar o comando resultante

### Fluxo principal (`Run()`)

1. Exibe a tela de boas-vindas via `ConsoleUi.ShowWelcome()`.
2. Entra em loop infinito controlado por `_runner` (sempre `true`); só sai por interrupção externa.
3. Lê o input do usuário via `ConsoleUi.ReadPrompt()`. Entradas nulas ou em branco são ignoradas e o ciclo reinicia.
4. Instancia um `Lexer` com o input recebido e executa `Tokenizer()`, que percorre o texto caractere a caractere e retorna um `LexerResult` contendo uma lista de `Token` (Type, Value, Position) ou uma lista de erros.
5. Se `LexerResult.Success` for `false`, exibe os erros com `ShowErrors()` e reinicia o ciclo.
6. Passa os tokens ao `Parser` via `ParseCommand()`, que interpreta a sequência e monta um `Command` com `Name`, `ArgumentsTokens` e `FlagsTokens`.
7. Se `ParserResult.Success` for `false`, exibe os erros e reinicia o ciclo.
8. Repassa o `Command` ao `CommandDispatcher.Dispatch()`, que seleciona e executa o handler correspondente.

### Entradas e saídas

- Entrada: input de texto digitado pelo usuário no terminal
- Saída: efeito colateral — execução do comando e impressão de resultado ou erros no console

### Dependências diretas

- `CommandDispatcher` — recebe o `Command` montado e executa o handler correto
- `Parser` — converte tokens em um `Command` estruturado
- `Lexer` — instanciado a cada ciclo a partir do input; fragmenta o texto em tokens
- `ConsoleUi` — leitura do prompt e exibição de erros

### Observações

- `_runner` é um campo `readonly bool` fixo em `true`; não há mecanismo de saída limpa implementado atualmente.
- O loop de erro na falha do `ParserResult` itera sobre `lexerResult.Errors` em vez de `parserResult.Errors` — possível bug a corrigir.

---

## Lexer.cs