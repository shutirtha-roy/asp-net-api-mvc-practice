using CreationalPattern.AbstractFactory;
using CreationalPattern.Factory;

//Factory Pattern
string choice = Console.ReadLine();
var car = CarFactory.CreateCar(choice);

//Abstract Factory Pattern
ICarFactory carFactory = new BMWCarFactory();
IEngine engine = carFactory.CreateEngine();
ITire tire = carFactory.CreateTire();
