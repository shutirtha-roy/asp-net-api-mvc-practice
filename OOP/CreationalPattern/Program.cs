using CreationalPattern.AbstractFactory;
using CreationalPattern.Builder;
using CreationalPattern.Factory;
using System.Text;

//Factory Pattern
string choice = Console.ReadLine();
var car = CarFactory.CreateCar(choice);

//Abstract Factory Pattern
ICarFactory carFactory = new BMWCarFactory();
IEngine engine = carFactory.CreateEngine();
ITire tire = carFactory.CreateTire();

//Builder Pattern
//CardBuilder cardBuilder = new CardBuilder;
//cardBuilder.AddMessage("Hello");
//cardBuilder.AddColor("red");
//cardBuilder.AddDesign("Modern");
//cardBuilder.AddReceiverName("Samin");

//Builder Pattern With Method Chaining
CardBuilder cardBuilder = new CardBuilder()
    .AddMessage("Hello")
    .AddColor("red")
    .AddDesign("Modern")
    .AddReceiverName("Samin");

Card card = cardBuilder.Build();

//String Builder Example which also uses Builder pattern
StringBuilder stringBuilder = new StringBuilder();
stringBuilder.Append(".NET 5.0")
    .Append(".NET 6.0")
    .Append(".NET 7.0");

string message = stringBuilder.ToString();