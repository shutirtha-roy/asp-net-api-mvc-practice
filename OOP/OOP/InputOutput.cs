namespace OOP
{
    internal class InputOutput
    {
        public void TakeInput()
        {
            Console.WriteLine("Please Provide Username");
            var username = Console.ReadLine();
            Console.WriteLine("Please Provide Password");
            var password = Console.ReadLine();
            Console.WriteLine("Please Provide Email");
            var email = Console.ReadLine();
        }
    }
}