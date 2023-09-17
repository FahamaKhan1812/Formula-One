using AutoMapper;
using FormulaOne.Api.Queries.Achievement;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.Achievement;
public class GetDriverAchievementHandler : IRequestHandler<GetDriverAchievementQuery, DriverAchievementResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public  async Task<DriverAchievementResponse?> Handle(GetDriverAchievementQuery request, CancellationToken cancellationToken)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(request.DriverAchievementId);
        if (driverAchievements == null)
        {
            return null;
        }
        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);

        return result;
    }
}
