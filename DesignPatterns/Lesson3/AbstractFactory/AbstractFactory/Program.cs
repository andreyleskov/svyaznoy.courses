using System;

class MainApp
{
    public static void Main()
    {
        // Abstract factory #1
        AbstractFactory factory1 = new ConcreteFactory1();
        Client c1 = new Client(factory1);
        c1.Run();

        // Abstract factory #2
        AbstractFactory factory2 = new ConcreteFactory2();
        Client c2 = new Client(factory2);
        c2.Run();

        // Wait for user input
        Console.Read();
    }
}

// "AbstractFactory"

interface AbstractFactory
{
     AbstractProductA CreateProductA();
     AbstractProductB CreateProductB();
}

// "ConcreteFactory1"

class ConcreteFactory1 : AbstractFactory
{
    public AbstractProductA CreateProductA()
    {
        return new ProductA1();
    }
    public AbstractProductB CreateProductB()
    {
        return new ProductB1();
    }
}

// "ConcreteFactory2"

class ConcreteFactory2 : AbstractFactory
{
    public AbstractProductA CreateProductA()
    {
        return new ProductA2();
    }
    public AbstractProductB CreateProductB()
    {
        return new ProductB2();
    }
}

// "AbstractProductA"

interface AbstractProductA
{
}

// "AbstractProductB"

interface AbstractProductB
{
    void Interact(AbstractProductA a);
}

// "ProductA1"

class ProductA1 : AbstractProductA
{
}

// "ProductB1"

class ProductB1 : AbstractProductB
{
    public void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " interacts with " + a.GetType().Name);
    }
}

// "ProductA2"

class ProductA2 : AbstractProductA
{
}

// "ProductB2"

class ProductB2 : AbstractProductB
{
    public void Interact(AbstractProductA a)
    {
        Console.WriteLine(this.GetType().Name +
          " interacts with " + a.GetType().Name);
    }
}

// "Client" - the interaction environment of the products

class Client
{
    private AbstractProductA abstractProductA;
    private AbstractProductB abstractProductB;

    // Constructor
    public Client(AbstractFactory factory)
    {
        abstractProductB = factory.CreateProductB();
        abstractProductA = factory.CreateProductA();
    }

    public void Run()
    {
        abstractProductB.Interact(abstractProductA);
    }
}