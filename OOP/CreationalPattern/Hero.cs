namespace CreationalPattern
{
    public class Hero : ICloneable
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double Speed { get; set; }
        public int Power { get; set; }

        public object Clone()
        {
            return Copy();
        }

        public Hero Copy()
        {
            return new Hero
            {
                Name = Name,
                Color = Color,
                Speed = Speed,
                Power = Power
            };
        }
    }
}