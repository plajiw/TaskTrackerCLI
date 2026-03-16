# Guia de Classes do Projeto

## Como preencher este arquivo

- Objetivo: descrever a funcionalidade de cada classe do projeto de forma padronizada.
- Estilo: manter linguagem direta, tópicos curtos e foco na responsabilidade da classe.
- Regra: preservar a lógica atual da implementação e complementar apenas o que estiver confuso ou incompleto.

---

## Program.cs

- Classe/arquivo: `Program.cs`
- Tipo: ponto de entrada da aplicação
- Responsabilidade principal: inicializar dependências e iniciar o fluxo da CLI

### Fluxo principal (`Main()`)

- Contém o método privado e estático `Main()`.
- Inicializa o `JsonContext` pelo construtor padrão, obtendo o caminho do diretório temporário do usuário para montar o caminho do arquivo JSON `tasktracker.json`, usado como banco de dados.
- Caso o arquivo ainda não exista, cria sua primeira instanciação com valor interno `[]`.
- Prepara o repositório com `JsonTaskItemRepository`, recebendo `JsonContext` como parâmetro; esse repositório é usado na instanciação do dispatcher.
- Instancia o `Parser`, responsável por realizar a análise sintática e interpretar os argumentos de entrada no terminal.
- Instancia o `CommandDispatcher`, responsável por supervisionar os comandos oferecidos no terminal.
- Instancia o `CliApplication` com dispatcher e parser; como essas dependências são criadas no bootstrap da aplicação, essa inicialização ocorre uma única vez por execução.
- Executa `Run()` para iniciar a aplicação.

### Dependências diretas

- `JsonContext`
- `JsonTaskItemRepository`
- `Parser`
- `CommandDispatcher`
- `CliApplication`

---

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
