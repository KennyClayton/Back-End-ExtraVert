using System.Diagnostics;

// From ChatGPT: "Each class defines its own set of properties, methods, and behavior, which you can use to create instances and manipulate data. Classes allow you to model and organize your code in an object-oriented manner."
public class Plant 
{
    public string Species { get; set; } //the type here is a string
    public int LightNeeds { get; set; } // the type here is an integer
    public decimal AskingPrice { get; set; } // the type here is a decimal. it is more precise than double, but takes more memory and is slower.
    public string City { get; set; } // this data type is a string
    public int ZIP { get; set; } // this data type is an integer
    public DateTime AvailableUntil { get; set; }
    public bool Sold { get; set; } // this data type is a boolean (true or false)
}

