using CreationalPattern.Factory;

//Factory Pattern
string choice = Console.ReadLine();
var car = CarFactory.CreateCar(choice);