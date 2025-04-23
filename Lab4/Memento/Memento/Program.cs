using System;
using System.Collections.Generic;

public class TextDocument
{
    public string Content { get; set; }

    public TextDocument(string content)
    {
        Content = content;
    }
}

public class TextEditor
{
    private TextDocument document;
    private List<Memento> history = new List<Memento>();
    private int currentState = -1;

    public TextEditor(string initialContent)
    {
        document = new TextDocument(initialContent);
        SaveState();
    }

    public void Edit(string newContent)
    {
        document.Content = newContent;
        SaveState();
    }

    public void SaveState()
    {
        history.Add(new Memento(new TextDocument(document.Content)));
        currentState++;
    }

    public void Undo()
    {
        if (currentState > 0)
        {
            currentState--;
            document = history[currentState].GetState();
        }
        else
        {
            Console.WriteLine("Немає доступних змін для відміни.");
        }
    }

    public void Redo()
    {
        if (currentState < history.Count - 1)
        {
            currentState++;
            document = history[currentState].GetState();
        }
        else
        {
            Console.WriteLine("Немає доступних змін для повтору.");
        }
    }

    public void DisplayContent()
    {
        Console.WriteLine($"Поточний текст: {document.Content}");
    }
}

public class Memento
{
    private TextDocument state;

    public Memento(TextDocument state)
    {
        this.state = new TextDocument(state.Content);
    }

    public TextDocument GetState()
    {
        return state;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var editor = new TextEditor("Привіт, світ!");

        editor.DisplayContent();

        editor.Edit("Привіт, програмування!");
        editor.DisplayContent();

        editor.Edit("Привіт, C#!");
        editor.DisplayContent();

        editor.Undo();
        editor.DisplayContent();

        editor.Undo();
        editor.DisplayContent();

        editor.Undo();
        editor.DisplayContent();

        editor.Redo();
        editor.DisplayContent();

        editor.Redo();
        editor.DisplayContent();
    }
}
