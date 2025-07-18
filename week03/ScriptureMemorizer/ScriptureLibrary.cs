using System;
using System.IO;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public ScriptureLibrary(string filePath)
    {
        LoadScriptures(filePath);
    }

    private void LoadScriptures(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = ParseReference(parts[0]);
                    _scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading scriptures: {ex.Message}");
            _scriptures.Add(new Scripture(new Reference("Alma", 7, 11, 12), "And behold, he shall be born of Mary, at Jerusalem which is the land of our forefathers, she being a virgin, a precious and chosen vessel, who shall be overshadowed and conceive by the power of the Holy Ghost, and bring forth a son, yea, even the Son of God. And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people."));
        }
    }    

    private Reference ParseReference(string referenceText)
    {
        int lastSpace = referenceText.LastIndexOf(' ');
        if (lastSpace < 0)
            throw new FormatException($"Invalid reference format: {referenceText}");

        string book = referenceText.Substring(0, lastSpace).Trim();
        string versePart = referenceText.Substring(lastSpace + 1).Trim();

        string[] chapterVerseParts = versePart.Split(new char[] { ':', '-' });
        if (chapterVerseParts.Length < 2)
        {
            throw new FormatException($"Invalid chapter/verse format: {referenceText}");
        }

        int chapter = int.Parse(chapterVerseParts[0]);
        int startVerse = int.Parse(chapterVerseParts[1]);

        if (chapterVerseParts.Length > 2)
        {
            int endVerse = int.Parse(chapterVerseParts[2]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, startVerse);
        }
    }

    public List<Scripture> GetScriptures()
    {
        return _scriptures;
    }
}