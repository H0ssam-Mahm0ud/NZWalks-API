using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Dto;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext context, IRegionRepository regionRepository, IMapper mapper)
        {
            _context = context;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // Here we are retrieving all the regions 
        // Get: https:..//localhost:7059/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionRepository.GetAllAsync();

            if (regions == null || !regions.Any())
                return NotFound("No regions found...");

            return Ok(_mapper.Map<List<Region>>(regions));
        }


        // Here we retrieve a single region by Id
        // Get: https:..//localhost:7059/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            if (region == null)
                return NotFound("Region not found...");

            return Ok(_mapper.Map<RegionDto>(region));
        }


        // Post: https:..//localhost:7059/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var region = _mapper.Map<Region>(addRegionRequestDto);

                region = await _regionRepository.CreateAsync(region);

                var regionDto = _mapper.Map<RegionDto>(region);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                var region = _mapper.Map<Region>(updateRegionRequestDto);

                region = await _regionRepository.UpdateAsync(id, region);

                if (region == null)
                {
                    return NotFound();
                }

                var regionDto = _mapper.Map<RegionDto>(region);

                return Ok(regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // Delete: https:..//localhost:7059/api/regions
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(region));
        }
    }
}
