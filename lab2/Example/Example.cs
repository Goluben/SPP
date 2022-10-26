

namespace Faker
{
    public class Example
    {
        public Example(string name, int age)
        {
            Name = name;
            Age = age;
            throw new Exception();
        }
        
        public Example(string name)
        {
            Name = name;
            Age = 10;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class MainClass
    {
        static void Main(string[] args)
        {
            var faker = new Faker.Core.FakerImpl.Faker();
            Example boss = faker.Create<Example>();
        }
    }
}
