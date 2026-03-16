namespace TaskTrackerCLI.Cli;

public class ConsoleUi
{
    private const int MaxCellLength = 128;
    private const string Ellipsis = "...";
    private const string DateTimeFormat = "dd/MM/yyyy HH:mm";
    private const char VerticalSeparator = '|';
    private const char HorizontalSeparator = '-';
    private const char Intersection = '+';
    private const string ColumnPadding = " ";
    
    public static void ShowWelcome()
    {
        Console.Clear();
        WriteLine("Welcome to Task Tracker CLI!!!", ConsoleColor.Cyan);
        Write("Insert ", ConsoleColor.Gray);
        Write("add \"your task\"", ConsoleColor.DarkCyan);
        WriteLine(" to save your task.", ConsoleColor.Gray);
    }

    public static void ShowHint(string? command = null)
    {
        Console.WriteLine();

        if (!string.IsNullOrWhiteSpace(command))
        {
            Write("Unknown command: ", ConsoleColor.Red);
            WriteLine(command, ConsoleColor.DarkCyan);
        }

        WriteLine("Available commands:", ConsoleColor.Cyan);
        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"task description\"", ConsoleColor.Gray);
        Write("      ", ConsoleColor.Gray);
        WriteLine("Adds a new task to the list.", ConsoleColor.DarkGray);

        Console.WriteLine();

        WriteLine("Examples:", ConsoleColor.Cyan);
        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"Buy milk\"", ConsoleColor.Gray);
        Write("  add ", ConsoleColor.DarkCyan);
        WriteLine("\"Study algorithms\" --done", ConsoleColor.Gray);

        Console.WriteLine();

        WriteLine("Type \"help\" to see this message again.\n", ConsoleColor.DarkGray);
    }

    public static void ShowHelp()
    {
        Console.WriteLine();
        WriteLine("Task Tracker CLI", ConsoleColor.Cyan);
        Console.WriteLine();

        WriteLine("USAGE", ConsoleColor.Cyan);
        Write("  ", ConsoleColor.Gray);
        Write("<command>", ConsoleColor.DarkCyan);
        WriteLine(" [arguments] [options]", ConsoleColor.DarkGray);
        Console.WriteLine();

        WriteLine("COMMANDS", ConsoleColor.Cyan);
        Console.WriteLine();

        Write("  add ", ConsoleColor.DarkCyan);
        Write("<\"description\">", ConsoleColor.Gray);
        WriteLine(" [options]", ConsoleColor.DarkGray);
        Write("      ", ConsoleColor.Gray);
        WriteLine("Adds a new task to the list.", ConsoleColor.DarkGray);
        Console.WriteLine();
        Write("      Options:", ConsoleColor.Gray);
        Console.WriteLine();
        Write("        --done", ConsoleColor.DarkCyan);
        WriteLine("         Creates the task with status Done.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  list", ConsoleColor.DarkCyan);
        Console.WriteLine();
        Write("      ", ConsoleColor.Gray);
        WriteLine("Lists all tasks.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  update ", ConsoleColor.DarkCyan);
        Write("<id>", ConsoleColor.Gray);
        Write(" [options]", ConsoleColor.DarkGray);
        WriteLine("                        (coming soon)", ConsoleColor.DarkGray);
        Write("      ", ConsoleColor.Gray);
        WriteLine("Updates the description or status of a task.", ConsoleColor.DarkGray);
        Console.WriteLine();
        Write("      Options:", ConsoleColor.Gray);
        Console.WriteLine();
        Write("        --todo", ConsoleColor.DarkCyan);
        WriteLine("          Sets the task status to Todo.", ConsoleColor.DarkGray);
        Write("        --in-progress", ConsoleColor.DarkCyan);
        WriteLine("   Sets the task status to In Progress.", ConsoleColor.DarkGray);
        Write("        --done", ConsoleColor.DarkCyan);
        WriteLine("          Sets the task status to Done.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  remove ", ConsoleColor.DarkCyan);
        Write("<id>", ConsoleColor.Gray);
        WriteLine("                                 (coming soon)", ConsoleColor.DarkGray);
        Write("      ", ConsoleColor.Gray);
        WriteLine("Removes a task by its ID.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  clear", ConsoleColor.DarkCyan);
        Console.WriteLine();
        Write("      ", ConsoleColor.Gray);
        WriteLine("Clears the terminal.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  help", ConsoleColor.DarkCyan);
        Console.WriteLine();
        Write("      ", ConsoleColor.Gray);
        WriteLine("Shows this help message.", ConsoleColor.DarkGray);
        Console.WriteLine();

        Write("  exit", ConsoleColor.DarkCyan);
        WriteLine("                                        (coming soon)", ConsoleColor.DarkGray);
        Write("      ", ConsoleColor.Gray);
        WriteLine("Exits the application.", ConsoleColor.DarkGray);
        Console.WriteLine();

        WriteLine("STATUS VALUES", ConsoleColor.Cyan);
        Console.WriteLine();
        Write("  todo           ", ConsoleColor.DarkCyan);
        WriteLine("Task not started yet.", ConsoleColor.DarkGray);
        Write("  in-progress    ", ConsoleColor.DarkCyan);
        WriteLine("Task currently in progress.", ConsoleColor.DarkGray);
        Write("  done           ", ConsoleColor.DarkCyan);
        WriteLine("Task completed.", ConsoleColor.DarkGray);
        Console.WriteLine();
    }

    public static string? ReadPrompt()
    {
        Write("> ", ConsoleColor.DarkCyan);
        return Console.ReadLine()?.Trim();
    }

    public static void Write(string text, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previous;
    }

    public static void WriteLine(string text, ConsoleColor color)
    {
        var newLine = Environment.NewLine;
        Write($"{text}{newLine}", color);
    }

    public static void DrawLine()
    {
        const char lineChar = '-';
        const int lineSize = 80;
        WriteLine(new string(lineChar, lineSize), ConsoleColor.Gray);
    }
    
    public static void PrintTable<T>(List<T>? itemRows) where T : class
    {
        if (itemRows == null)
            return;

        var properties = typeof(T).GetProperties();
        var columnWidths = properties.Select(p => p.Name.Length).ToArray();

        foreach (var item in itemRows)
        {
            for (var i = 0; i < properties.Length; i++)
            {
                var stringValue = FormatValue(properties[i].GetValue(item));
                columnWidths[i] = Math.Max(columnWidths[i], stringValue.Length);
            }
        }
        
        var columnTemplate = string.Join(string.Empty, properties.Select((p, i) => 
            $"{ColumnPadding}{{{i},-{columnWidths[i]}}}{ColumnPadding}{VerticalSeparator}"));
        
        var separatorLine = string.Join(string.Empty, columnWidths.Select((w, i) => 
            $"{HorizontalSeparator}{new string(HorizontalSeparator, w)}{HorizontalSeparator}" +
            $"{(i == columnWidths.Length - 1 ? VerticalSeparator : Intersection)}"));

        var columnHeader = properties.Select(p => p.Name.ToUpperInvariant()).ToArray<object>();
        WriteLine(string.Format(columnTemplate, columnHeader), ConsoleColor.DarkCyan);
        
        WriteLine(separatorLine, ConsoleColor.DarkCyan);

        foreach (var item in itemRows)
        {
            var rowValues = new object[properties.Length];
            
            for (var i = 0; i < properties.Length; i++)
                rowValues[i] = FormatValue(properties[i].GetValue(item));

            WriteLine(string.Format(columnTemplate, rowValues), ConsoleColor.Cyan);
        }

        WriteLine(separatorLine, ConsoleColor.DarkCyan);
    }

    private static string FormatValue(object? value)
    {
        if (value is null) 
            return string.Empty;

        string strValue;

        if (value is DateTime dateValue)
            strValue = dateValue.ToString(DateTimeFormat);
        else
            strValue = value.ToString() ?? string.Empty;

        if (strValue.Length > MaxCellLength)
            return strValue[..(MaxCellLength - Ellipsis.Length)] + Ellipsis;

        return strValue;
    }
}