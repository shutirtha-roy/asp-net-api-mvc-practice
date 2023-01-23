namespace CreationalPattern.AbstractFactory
{
    public interface ICarFactory
    {
        IEngine CreateEngine();
        ITire CreateTire();
    }
}