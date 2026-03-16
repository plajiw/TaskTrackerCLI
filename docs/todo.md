# TODO — TaskTrackerCLI

---

## 🔲 Pendente

### Funcionalidades

- [ ] Implementar `update <id> "nova descrição"` — alterar a descrição de uma tarefa existente
- [ ] Implementar `update <id> --in-progress` — marcar tarefa como In Progress
- [ ] Implementar `update <id> --done` — marcar tarefa como Done
- [ ] Implementar `update <id> --todo` — reverter tarefa para Todo
- [ ] Implementar `remove <id>` — remover tarefa pelo ID
- [ ] Implementar `list --done` — listar apenas tarefas com status Done
- [ ] Implementar `list --todo` — listar apenas tarefas com status Todo
- [ ] Implementar `list --in-progress` — listar apenas tarefas com status In Progress
- [ ] Implementar `exit` — encerrar a aplicação de forma limpa

### Infraestrutura

- [ ] Implementar `GetTaskItem(int id)` no `JsonTaskItemRepository` (atualmente lança `NotImplementedException`)
- [ ] Implementar `UpdateTaskItem(TaskItem)` no `JsonTaskItemRepository` (atualmente lança `NotImplementedException`)
- [ ] Adicionar `DeleteTaskItem(int id)` à interface `ITaskItemRepository` e implementar no `JsonTaskItemRepository`

### Validações e tratamento de erros

- [ ] Retornar erro descritivo quando o ID informado não existir (`update`, `remove`)
- [ ] Validar que a descrição do `add` não é vazia após o parse
- [ ] Tratar `ArgumentException` no `AddCommandHandler` com mensagem clara ao usuário

### Qualidade

- [ ] Corrigir bug: bloco de erro do `ParserResult` itera sobre `lexerResult.Errors` em vez de `parserResult.Errors`
- [ ] Escrever testes unitários para `Lexer` e `Parser`
- [ ] Escrever testes unitários para os handlers (`Add`, `List`, `Update`, `Remove`)

---

## 🔄 Andamento

### Documentação

- [ ] Estudar e documentar o projeto

---

## ✅ Concluído

- [x] Estrutura base do projeto (Domain, Infrastructure, CLI)
- [x] Lexer e Parser implementados
- [x] Handler `add` com suporte a `--done`
- [x] Handler `list` com tabela formatada
- [x] Handler `clear`
- [x] Handler `help`
- [x] Persistência via JSON (`JsonTaskItemRepository`)
- [x] Auto-incremento de ID na inserção

