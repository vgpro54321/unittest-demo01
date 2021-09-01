namespace UnitTestDemo.Services
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
