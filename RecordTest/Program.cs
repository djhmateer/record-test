using System;

//var person = new Person { FirstName = "Mads", LastName = "Nielsen" };
//var otherPerson = person with { LastName = "Torgersen" };


//public record Person
//{
//    public string? FirstName { get; init; }
//    public string? LastName { get; init; }
//}


var person = new Person(FirstName: "Mads", LastName: "Nielsen"); // positional construction
Console.WriteLine(person); // nice override of ToString

var personB = new Person("Mads", "Nielsen"); // don't need argument names
//Error CS8852	Init-only property or indexer 'Person.LastName' can only be assigned in an object initializer,
//or on 'this' or 'base' in an instance constructor or an 'init' accessor.	
//person.LastName = "asdf";

var (f, l) = person; // positional deconstruction

// value-ness based equality
// ie if all fields are equal then the 2 objects are considered equal
if (person == personB) Console.WriteLine("they are equal");

var otherPerson = person with { LastName = "Torgersen" };
if (person == otherPerson) Console.WriteLine("they are equal");

// positional record
// init-only properly under the hood
public record Person(string FirstName, string LastName);



class PersonX
{
    // to avoid warnings, we could set firstName to "" here as a default
    // which would avoid FirstName being null
    // which by using string we are saying the reference should not be null (C# 8 nullable ref type)
    //public Person(int id = 0, string firstName = "")
    //{
    //    ID = id;
    //    FirstName = firstName;
    //}

    // int (like all simple types eg bool, char, byte etc) is a value type, so directly contains the data
    // non nullable by default
    // so an int has an default value of 0 if not set
    public int ID { get; set; }

    // reference type ie stores references to their data
    // reference types are nullable by default
    // https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
    // to avoid warnings, if we don't use a ctor to explicitly set the string to something, must set to nullable string

    // compiler warning 
    // Warning CS8618  Non-nullable property 'FirstName' must contain a non-null value when exiting constructor.
    // Consider declaring the property as nullable


    // essentially we need to tell the compiler that FirstName could be null (or set it in the ctor)
    public string? FirstName { get; set; }
}
