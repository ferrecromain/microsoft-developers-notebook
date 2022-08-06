using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;
using DotnetSampleSolution.WebApi.Dtms.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotnetSampleSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IEnumerable<UserGetDtm>> GetAllAsync()
        {
            IEnumerable<UserEntity> userEntities = await _userRepository.GetAllAsync();
            return userEntities.Select(e => new UserGetDtm(e));
        }
    }
}
