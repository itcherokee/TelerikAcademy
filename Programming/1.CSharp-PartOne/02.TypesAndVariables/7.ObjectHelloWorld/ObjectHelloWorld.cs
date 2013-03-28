using System;

class ObjectHelloWorld
{
    static void Main()
    {
        // Declare two string variables and assign them with “Hello” and “World”. 
        // Declare an object variable and assign it with the concatenation of the 
        // first two variables (mind adding an interval). Declare a third string 
        // variable and initialize it with the value of the object variable.

        string hello = "Hello";
        string world = "World";
        object objectHelloWorld;
        string stringHelloWorld;
        objectHelloWorld = hello + " " + world;
        stringHelloWorld = (string)objectHelloWorld;
        Console.WriteLine(stringHelloWorld);
        Console.ReadKey();
    }
}

