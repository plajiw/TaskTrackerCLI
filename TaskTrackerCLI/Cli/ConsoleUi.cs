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

    public static void ShowHelp(string? command = null)
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