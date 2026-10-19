using TaskFlow.ConsoleApp;

var manager = new TaskManager();
var running = true;

while (running)
{
    ShowMenu();
    var option = Console.ReadLine();

    if (option is null)
    {
        break;
    }

    Console.WriteLine();

    switch (option.Trim())
    {
        case "1":
            AddTask();
            break;
        case "2":
            ListTasks();
            break;
        case "3":
            FindTask();
            break;
        case "4":
            CompleteTask();
            break;
        case "0":
            running = false;
            Console.WriteLine("Até logo!");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPressione Enter para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
}

void ShowMenu()
{
    Console.WriteLine("=== TaskFlow ===");
    Console.WriteLine("1. Adicionar tarefa");
    Console.WriteLine("2. Listar tarefas");
    Console.WriteLine("3. Buscar tarefa por ID");
    Console.WriteLine("4. Concluir tarefa");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha uma opção: ");
}

void AddTask()
{
    Console.Write("Título: ");
    var title = Console.ReadLine();

    if (title is null)
    {
        Console.WriteLine("Entrada encerrada.");
        return;
    }

    try
    {
        var task = manager.AddTask(title);
        Console.WriteLine($"Tarefa adicionada com sucesso. ID: {task.Id}");
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine(exception.Message);
    }
}

void ListTasks()
{
    if (manager.Tasks.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada.");
        return;
    }

    foreach (var task in manager.Tasks)
    {
        var status = task.IsCompleted ? "Concluída" : "Pendente";
        Console.WriteLine($"{task.Id} | {status} | {task.Title}");
    }
}

void FindTask()
{
    var task = ReadTaskById();

    if (task is null)
    {
        Console.WriteLine("Tarefa não encontrada.");
        return;
    }

    var status = task.IsCompleted ? "Concluída" : "Pendente";
    Console.WriteLine($"{task.Id} | {status} | {task.Title}");
}

void CompleteTask()
{
    var id = ReadTaskId();

    if (id is null)
    {
        return;
    }

    Console.WriteLine(manager.CompleteTask(id.Value)
        ? "Tarefa concluída com sucesso."
        : "Tarefa não encontrada.");
}

TaskItem? ReadTaskById()
{
    var id = ReadTaskId();
    return id is null ? null : manager.GetById(id.Value);
}

Guid? ReadTaskId()
{
    Console.Write("ID da tarefa: ");
    var input = Console.ReadLine();

    if (Guid.TryParse(input, out var id))
    {
        return id;
    }

    Console.WriteLine("ID inválido. Informe um GUID válido.");
    return null;
}
