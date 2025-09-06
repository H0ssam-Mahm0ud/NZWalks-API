using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Dto;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IMapper mapper, IWalkRepository walkRepository, NZWalksDbContext context)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDM =  await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(_mapper.Map<List<WalkDto>>(walkDM));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkDM = _mapper.Map<Walk>(addWalksRequestDto);

                await _walkRepository.CreateAsync(walkDM);

                return Ok(_mapper.Map<WalkDto>(walkDM));
            }

            return BadRequest(ModelState);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDM = await _walkRepository.GetByIdAsync(id);

            if (walkDM == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDM));
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name must be provided.");
            }

            var walkDM = await _context.Walks.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (walkDM == null)
            {
                return NotFound();
            }

            return Ok(walkDM);
        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkDM = _mapper.Map<Walk>(updateWalkRequestDto);

                walkDM = await _walkRepository.UpdateAsync(id, walkDM);

                if (walkDM == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<WalkDto>(walkDM));
            }

            return BadRequest(ModelState);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDM = await _walkRepository.DeleteAsync(id);

            if (walkDM == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalkDto>(walkDM));
        }
    }
}
