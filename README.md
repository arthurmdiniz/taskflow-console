# TaskFlow Console

Aplicação de console para gerenciamento de tarefas, desenvolvida com .NET 10 e testes unitários em xUnit.

## Pré-requisitos

- .NET SDK 10.0 ou superior

## Compilar

Na raiz do repositório, execute:

```powershell
dotnet build .\TaskFlow.slnx
```

## Executar a aplicação

```powershell
dotnet run --project .\TaskFlow.Console\TaskFlow.Console.csproj
```

No menu interativo, é possível:

- Adicionar tarefas;
- Listar tarefas;
- Buscar uma tarefa pelo ID;
- Concluir tarefas;
- Encerrar a aplicação.

## Executar os testes

```powershell
dotnet test .\TaskFlow.slnx
```

## Sobre o Autor

Ajustado e documentado por **Arthur Marques Diniz**.

*   **GitHub:** [@arthurmdiniz](https://github.com)
*   **LinkedIn:** [arthurmdiniz](https://www.linkedin.com/in/arthurmdiniz/)
*   **E-mail:** arthurmdiniz@outlook.com.br

Sinta-se à vontade para enviar *pull requests*, reportar problemas ou propor melhorias!