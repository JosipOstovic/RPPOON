using System;
using System.Collections;
using System.Collections.Generic;

abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    public abstract int Key();
    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();
}

abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

class AlphabeticalOrderIterator : Iterator
{
    private WordsCollection collection;
    private int position = -1;
    private bool reverse = false;

    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        this.collection = collection;
        this.reverse = reverse;

        if (reverse)
        {
            this.position = collection.getItems().Count;
        }
    }
        
    public override object Current()
    {
        return this.collection.getItems()[position];
    }

    public override int Key()
    {
        return this.position;
    }
        
    public override bool MoveNext()
    {
        int updatedPosition = this.position + (this.reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < this.collection.getItems().Count)
        {
            this.position = updatedPosition;
            return true;
        }
        else
        {
            return false;
        }
    }
        
    public override void Reset()
    {
        this.position = this.reverse ? this.collection.getItems().Count - 1 : 0;
    }
}

class WordsCollection : IteratorAggregate
{
    List<string> collection = new List<string>();
    bool direction = false;
        
    public void ReverseDirection()
    {
        direction = !direction;
    }
        
    public List<string> getItems()
    {
        return collection;
    }
        
    public void AddItem(string item)
    {
        this.collection.Add(item);
    }
        
    public override IEnumerator GetEnumerator()
    {
        return new AlphabeticalOrderIterator(this, direction);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var collection = new WordsCollection();
        collection.AddItem("R");
        collection.AddItem("P");
        collection.AddItem("P");
        collection.AddItem("O");
        collection.AddItem("N");

        Console.WriteLine("Straight:");

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\nReverse:");

        collection.ReverseDirection();

        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }
}