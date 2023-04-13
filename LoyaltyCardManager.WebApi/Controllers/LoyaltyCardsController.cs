using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;
using LoyaltyCardManager.WebApi.Dtms.LoyaltyCard;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyCardManager.WebApi.Controllers
{
    [ApiController]
    [Route("/api/loyalty-cards")]
    public class LoyaltyCardsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoyaltyCardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all loyalty cards
        /// </summary>
        /// <returns>List of loyalty cards</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyCardGetDtm>>> GetAllAsync()
        {
            IEnumerable<LoyaltyCardEntity> loyaltyCardEntities = await _unitOfWork.LoyaltyCardRepository.GetManyAsync();
            return Ok(loyaltyCardEntities.Select(e => new LoyaltyCardGetDtm(e)));
        }

        /// <summary>
        /// Get an loyalty card by its identifier
        /// </summary>
        /// <param name="id">Loyalty card identifier</param>
        /// <returns>A single loyalty card or NotFound</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LoyaltyCardGetDtm>> GetByIdAsync(int id)
        {
            LoyaltyCardEntity? loyaltyCardEntity = await _unitOfWork.LoyaltyCardRepository.GetAsync(id);
            if(loyaltyCardEntity == null)
            {
                return NotFound();
            }
            return Ok(new LoyaltyCardGetDtm(loyaltyCardEntity));
        }

        /// <summary>
        /// Create a new loyalty card
        /// </summary>
        /// <param name="dto">Loyalty card to create</param>
        [HttpPost]
        public async Task<IActionResult> AddAsync(LoyaltyCardPostDtm dto)
        {
            LoyaltyCardEntity entity = new();
            await _unitOfWork.LoyaltyCardRepository.AddAsync(dto.MapTo(entity));
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = entity.Id }, new LoyaltyCardGetDtm(entity));
        }

        /// <summary>
        /// Update a loyalty card
        /// </summary>
        /// <param name="id">Loyalty card identifier</param>
        /// <param name="dto">Loyalty card data</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, LoyaltyCardPutDtm dto)
        {
            LoyaltyCardEntity? loyaltyCardEntity = await _unitOfWork.LoyaltyCardRepository.GetAsync(id);
            if (loyaltyCardEntity is null)
            {
                return NotFound();
            }
            _unitOfWork.LoyaltyCardRepository.Update(dto.MapTo(loyaltyCardEntity));
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        /// <summary>
        /// Delete a loyalty card
        /// </summary>
        /// <param name="id">Loyalty card identifier</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            LoyaltyCardEntity? loyaltyCardEntity = await _unitOfWork.LoyaltyCardRepository.GetAsync(id);
            if(loyaltyCardEntity is null)
            {
                return NotFound();
            }
            _unitOfWork.LoyaltyCardRepository.Delete(loyaltyCardEntity);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
