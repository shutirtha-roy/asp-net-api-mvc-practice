namespace CreationalPattern.Factory
{
    public class CarFactory
    {
        public static ICar CreateCar(string name)
        {
            if (name.Equals("Toyota"))
            {
                return new Toyota() { Model = "X Corolla", Color = "White" };
            }
            else if (name.Equals("BMW"))
            {
                return new BMW() { Model = "X 2000", Color = "Black" };
            }
            else
            {
                return null;
            }
        }
    }
}