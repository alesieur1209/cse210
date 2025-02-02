using System;

public class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}\n");
    }
}

public class Journal
{
    public List<Entry> Entries { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string mood)
    {
        Entries.Add(new Entry(prompt, response, mood));
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("You don't have any entries yet.\n");
            return;
        }

        foreach (var entry in Entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date.ToShortDateString()}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No file found.\n");
            return;
        }

        Entries.Clear();  // Clears the existing entries
        foreach (var line in File.ReadLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entries.Add(new Entry(parts[1], parts[2], parts[3]) { Date = DateTime.Parse(parts[0]) });
            }
        }
    }
}

public class Program
{
    private static Journal journal = new Journal();
    private static Random random = new Random();

    private static readonly string[] prompts = 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void WriteNewEntry()
    {
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        string mood = "";
        bool validMood = false;

        while (!validMood) //Here's my extra addition to the code. Each journal entry now also tracks the user's mood.
        {
            Console.Write("How would you rate your mood today (e.g., happy, sad, neutral): ");
            mood = Console.ReadLine().Trim().ToLower();

            if (mood == "happy" || mood == "sad" || mood == "neutral")
            {
                validMood = true;
            }
            else
            {
                Console.WriteLine("Invalid mood. Please choose from 'happy', 'sad', or 'neutral'");
            }
        }

        journal.AddEntry(prompt, response, mood);
        Console.WriteLine("Entry added!\n");
    }

    private static void SaveJournalToFile()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved!\n");
    }

    private static void LoadJournalFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded!\n");
    }
}
