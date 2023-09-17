using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands.Achievement;
public class CreateDriverAchievementInfoRequest : IRequest<DriverAchievementResponse>
{
    public CreateDriverAchievementRequest CreateDriverAchievementRequest { get; }
    public CreateDriverAchievementInfoRequest(CreateDriverAchievementRequest createDriverAchievementRequest)
    {
        CreateDriverAchievementRequest = createDriverAchievementRequest;
    }
}
