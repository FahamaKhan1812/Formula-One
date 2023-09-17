using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.Achievement;
public class GetDriverAchievementQuery : IRequest<DriverAchievementResponse>
{
    public Guid DriverAchievementId { get; set; }
    public GetDriverAchievementQuery(Guid driverAchievementId)
    {
        DriverAchievementId = driverAchievementId;
    }
}