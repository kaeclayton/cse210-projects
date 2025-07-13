using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        if (!file.EndsWith(".csv")) file += ".csv";

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                string escapedPrompt = EscapeCsvField(entry._promptText);
                string escapedEntry = EscapeCsvField(entry._entryText);

                outputFile.WriteLine($"\"{entry._date}\",\"{escapedPrompt}\",\"{escapedEntry}\"");
            }
        }
        Console.WriteLine($"Journal saved to {file}");
    }

    private string EscapeCsvField(string field)
    {
        if (field == null) return "";

        string escaped = field.Replace("\"", "\"\"");
        return escaped.Trim();
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        if (!File.Exists(file))
        {
            Console.WriteLine($"File not found: {file}");
            return;
        }

        try
        {
            using (StreamReader inputFile = new StreamReader(file))
            {
                inputFile.ReadLine();

                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    string[] parts = ParseCsvLine(line);

                    if (parts.Length >= 3)
                    {
                        Entry loadedEntry = new Entry
                        {
                            _date = UnescapeCsvField(parts[0]),
                            _promptText = UnescapeCsvField(parts[1]),
                            _entryText = UnescapeCsvField(parts[2])
                        };
                        _entries.Add(loadedEntry);
                    }
                }
            }
            Console.WriteLine($"Journal loaded from {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                parts.Add(line.Substring(startIndex, i - startIndex));
                startIndex = i + 1;
            }
        }

        parts.Add(line.Substring(startIndex));

        for (int i = 0; i < parts.Count; i++)
        {
            parts[i] = UnescapeCsvField(parts[i]);
        }

        return parts.ToArray();
    }

    private string UnescapeCsvField(string field)
    {
        field = field.Trim();

        if (field.StartsWith("\"") && field.EndsWith("\""))
        {
            field = field.Substring(1, field.Length - 2);
        }

        return field.Replace("\"\"", "\"");
    }
}