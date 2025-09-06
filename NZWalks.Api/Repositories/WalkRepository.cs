using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;
        public WalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }


        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }


        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            _context.Walks.Remove(existingWalk);
            _context.SaveChanges();
            return existingWalk;
        }


        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            //return await _context.Walks.Include("Region").Include("Difficulty").ToListAsync();

            var walks = _context.Walks.Include("Region").Include("Difficulty").AsQueryable();

            // Apply flitering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKM) : walks.OrderByDescending(x => x.LengthInKM);
                }
            }

            // Pagination
            var skipResults = (pageNumber -1) * pageSize;   

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
        }


        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _context.Walks.Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKM = walk.LengthInKM;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            await _context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
