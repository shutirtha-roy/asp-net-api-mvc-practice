namespace CreationalPattern.AbstractFactory
{
    public class BMWCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new BMWEngine();
        }

        public ITire CreateTire()
        {
            return new BMWTire();
        }
    }
}