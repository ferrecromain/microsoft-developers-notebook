using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;
using LoyaltyCardManager.WebApi.Dtms.Group;
using LoyaltyCardManager.WebApi.Dtms.LoyaltyCard;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyCardManager.WebApi.Controllers
{
    [ApiController]
    [Route("/api/groups")]
    public class GroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all groups
        /// </summary>
        /// <returns>List of groups</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupGetDtm>>> GetAllAsync()
        {
            IEnumerable<GroupEntity> groupEntities = await _unitOfWork.GroupRepository.GetManyAsync();
            return Ok(groupEntities.Select(e => new GroupGetDtm(e)));
        }

        /// <summary>
        /// Get a group by its identifier
        /// </summary>
        /// <param name="id">Group identifier</param>
        /// <returns>A single group or NotFound</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GroupGetDtm>> GetByIdAsync(int id)
        {
            GroupEntity? groupEntity = await _unitOfWork.GroupRepository.GetAsync(id);
            if (groupEntity == null)
            {
                return NotFound();
            }
            return Ok(new GroupGetDtm(groupEntity));
        }

        /// <summary>
        /// Create a new group
        /// </summary>
        /// <param name="dto">Group to create</param>
        [HttpPost]
        public async Task<IActionResult> AddAsync(GroupPostDtm dto)
        {
            GroupEntity entity = new();
            await _unitOfWork.GroupRepository.AddAsync(dto.MapTo(entity));
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = entity.Id }, new GroupGetDtm(entity));
        }

        /// <summary>
        /// Update a group
        /// </summary>
        /// <param name="id">Group identifier</param>
        /// <param name="dto">Group data</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, GroupPutDtm dto)
        {
            GroupEntity? groupEntity = await _unitOfWork.GroupRepository.GetAsync(id);
            if (groupEntity is null)
            {
                return NotFound();
            }
            _unitOfWork.GroupRepository.Update(dto.MapTo(groupEntity));
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Delete a group
        /// </summary>
        /// <param name="id">Group identifier</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            GroupEntity? groupEntity = await _unitOfWork.GroupRepository.GetAsync(id);
            if (groupEntity is null)
            {
                return NotFound();
            }
            _unitOfWork.GroupRepository.Delete(groupEntity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
