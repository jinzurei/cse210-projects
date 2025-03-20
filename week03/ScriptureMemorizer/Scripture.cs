using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random(); // Persistent random instance

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Hides random words, ensuring they are not already hidden
    public void HideRandomWords(int numberToHide)
    {
        if (IsCompletelyHidden()) return; // Prevent unnecessary execution

        int hiddenCount = 0;
        while (hiddenCount < numberToHide)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }

            // Stop if all words are hidden
            if (IsCompletelyHidden())
                break;
        }
    }

    // Returns formatted scripture text with hidden words replaced by underscores
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    // Checks if all words are hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}