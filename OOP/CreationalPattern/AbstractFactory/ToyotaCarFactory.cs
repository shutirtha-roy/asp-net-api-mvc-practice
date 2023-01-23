namespace CreationalPattern.AbstractFactory
{
    public class ToyotaCarFactory : ICarFactory
    {
        public IEngine CreateEngine()
        {
            return new ToyotaEngine();
        }

        public ITire CreateTire()
        {
            return new ToyotaTire();
        }
    }
}