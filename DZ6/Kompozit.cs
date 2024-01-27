using System;
using System.Collections.Generic;


//Komponenta
public interface FileSystem{
    virtual void Display();
}


//List
public class File : FileSystem
{
    private string fileName;

    public File(string name)
    {
        fileName = name;
    }

    public override void Display()
    {
        Console.WriteLine($"Folder: {fileName}");
    }



//Kompozit
public class Directory : FileSystem 
{
    private string directoryName;
    private List<FileSystem> files;

    public Directory(string name)
    {
        directoryName = name;
        files = new List<FileSystem>();
    }

    public void Add(FileSystem item)
    {
        files.Add(item);
    }

    public void Remove(FileSystem item)
    {
        files.Remove(item);
    }

    public override void Display()
    {
        Console.WriteLine($"Directory: {directoryName}");
        foreach (var file in files)
        {
            file.Display();
        }
    }
}

//Koristio bi kompozit koji pripada obrascima strukture jer je najprikladniji za rad sa stablastom strukturom
//U ovom slucaju imamo foldere pa ih mozemo prikazati kao stablo
