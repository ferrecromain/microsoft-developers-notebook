using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;
using DotnetSampleSolution.WebApi.Dtms.User;
using Microsoft.AspNetCore.Mvc;

namespace DotnetSampleSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDtm>>> GetAllAsync()
        {
            IEnumerable<UserEntity> userEntities = await _unitOfWork.UserRepository.GetAllAsync();
            return Ok(userEntities.Select(e => new UserGetDtm(e)));
        }

        /// <summary>
        /// Get an user by its identifier
        /// </summary>
        /// <param name="id">User identifier</param>
        /// <returns>A single user or NotFound</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserGetDtm>> GetByIdAsync(int id)
        {
            UserEntity? userEntity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if(userEntity == null)
            {
                return NotFound();
            }
            return Ok(new UserGetDtm(userEntity));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="dtm">User to create</param>
        [HttpPost]
        public async Task<IActionResult> AddAsync(UserPostDtm dtm)
        {
            UserEntity userEntity = new();
            await _unitOfWork.UserRepository.AddAsync(dtm.MapTo(userEntity));
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(AddAsync), new { userEntity.Id }, dtm);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User identifier</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            UserEntity? userEntity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if(userEntity is null)
            {
                return NotFound();
            }
            _unitOfWork.UserRepository.Delete(userEntity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
