using DotnetSampleSolution.Core.Contracts;

namespace DotnetSampleSolution.Core.Entities
{
    public class UserEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }
    }
}
