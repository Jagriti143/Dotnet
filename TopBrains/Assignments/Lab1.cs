using System;

class Program
{
    static void Main()
    {
        string original = "  Hello, Training Team!  ";

        // TODO 1: Trim the string
        string trimmed = original.Trim();

        // TODO 2: Compare original and trimmed
        Console.WriteLine(
            "ReferenceEquals(original, trimmed): " +
            object.ReferenceEquals(original, trimmed)
        );

        // TODO 3: String operations

        Console.WriteLine(
            "Contains \"Training\": " +
            trimmed.Contains("Training")
        );

        Console.WriteLine(
            "StartsWith trimmed \"Hello\": " +
            trimmed.StartsWith("Hello")
        );

        Console.WriteLine(
            "Index of first comma: " +
            trimmed.IndexOf(',')
        );

        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            "\"Training Team\" replaced -> " + replaced
        );

        // TODO 4: Split into words
        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // TODO 5: IsNullOrWhiteSpace checks

        string? nullString = null;
        string emptyString = "";
        string spaces = "   ";
        string normalString = "ok";

        Console.WriteLine(
            "IsNullOrWhiteSpace(null): " +
            string.IsNullOrWhiteSpace(nullString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"\"): " +
            string.IsNullOrWhiteSpace(emptyString)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"   \"): " +
            string.IsNullOrWhiteSpace(spaces)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"ok\"): " +
            string.IsNullOrWhiteSpace(normalString)
        );

        // Bonus
        string first = "HELLO";
        string second = "hello";

        int comparison = string.Compare(
            first,
            second,
            StringComparison.OrdinalIgnoreCase
        );

        Console.WriteLine(
            "Case-insensitive comparison result: " + comparison
        );
    }
}
