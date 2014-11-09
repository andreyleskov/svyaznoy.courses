using System;

interface IAnimal
{
    void MakeSound();
}

class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

class NullAnimal : IAnimal
{
    public void MakeSound()
    {
    }
}

static class Program
{
    private static IAnimal GetAnimal()
    {
        return new NullAnimal();
    }

    static void Main()
    {
        IAnimal dog = GetAnimal();
        dog.MakeSound(); 
        Console.ReadKey();
    }
}
