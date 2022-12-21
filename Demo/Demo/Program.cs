using DemoLib;

string line = Console.ReadLine();
int[] nums = line.Split(' ').Select(x => int.Parse(x)).ToArray();

Calculator calculator = new Calculator();
Console.WriteLine(calculator.Sum(nums[0], nums[1]));