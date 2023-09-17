using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repository;
public class AchievmentRepository : GenericRepository<Achievement>, IAchievementRepository
{
    public AchievmentRepository(ILogger logger, ApplicationDbContext context) : base(logger, context)
    {
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} GetDriverAchievementAsync Function error", typeof(AchievmentRepository));
            throw;
        }
    }


    public override async Task<IEnumerable<Achievement>> All()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All Function error", typeof(AchievmentRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            // get entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            result.Status = 0;
            result.UpdatedDate = DateTime.UtcNow;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete Function error", typeof(AchievmentRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            // get entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.DriverId == achievement.DriverId);
            if (result == null)
            {
                return false;
            }
            result.UpdatedDate = DateTime.UtcNow;
            result.RaceWins = achievement.RaceWins;
            result.PolePosition = achievement.PolePosition;
            result.FastestLap = achievement.FastestLap;
            result.WorldChampionship = achievement.WorldChampionship;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update Function error", typeof(AchievmentRepository));
            throw;
        }
    }
}