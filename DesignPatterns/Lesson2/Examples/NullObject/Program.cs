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
    static void Main()
    {
        IAnimal dog = new Dog();
        dog.MakeSound(); 

        IAnimal unknown = new NullAnimal(); 
        unknown.MakeSound(); 
    }
}
