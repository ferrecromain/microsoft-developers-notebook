using DotnetSampleSolution.Core.Contracts;

namespace DotnetSampleSolution.Core.Entities
{
    public class GroupEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
