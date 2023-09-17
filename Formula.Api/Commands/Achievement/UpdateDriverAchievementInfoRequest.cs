using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Commands.Achievement;
public class UpdateDriverAchievementInfoRequest : IRequest<bool>
{
    public UpdateDriverAchievementRequest UpdateDriverAchievementRequest { get; }
    public UpdateDriverAchievementInfoRequest(UpdateDriverAchievementRequest updateDriverAchievementRequest)
    {
        UpdateDriverAchievementRequest = updateDriverAchievementRequest;
    }
}