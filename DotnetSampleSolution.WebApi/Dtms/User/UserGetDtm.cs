using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.WebApi.Dtms.User
{
    public class UserGetDtm
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }

        public UserGetDtm(UserEntity entity)
        {
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Birthday = entity.Birthday;
            Email = entity.Email;
        }
    }
}
