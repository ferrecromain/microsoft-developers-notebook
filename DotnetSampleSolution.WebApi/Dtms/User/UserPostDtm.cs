using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.WebApi.Dtms.User
{
    public class UserPostDtm : IMappableTo<UserEntity>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Email { get; set; }

        public UserEntity MapTo(UserEntity entity)
        {
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.Birthday = Birthday;
            entity.Email = Email;
            return entity;
        }
    }
}
