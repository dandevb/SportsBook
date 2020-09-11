using SportsBook.Domain.SeedWork;

namespace SportsBook.Tests.Test_Objects
{
    public class TestEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
