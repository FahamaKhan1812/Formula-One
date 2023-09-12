using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repository.Interfaces;
using Microsoft.Extensions.Logging;
namespace FormulaOne.DataService.Repository;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get; }
  
    public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(logger, _context);
        Achievements = new AchievmentRepository(logger, _context);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
