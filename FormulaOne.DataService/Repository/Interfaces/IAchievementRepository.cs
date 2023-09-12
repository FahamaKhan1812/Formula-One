using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repository.Interfaces;
public interface IAchievementRepository : IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievementAsync(Guid driverId);
}
