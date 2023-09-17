using AutoMapper;
using FormulaOne.Api.Commands.Achievement;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers.Achievement;
public class GetDriverAchievementInfoHandler : IRequestHandler<CreateDriverAchievementInfoRequest, DriverAchievementResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverAchievementInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DriverAchievementResponse> Handle(CreateDriverAchievementInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Entities.DbSet.Achievement>(request.CreateDriverAchievementRequest);
        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<DriverAchievementResponse>(result);
    }
}
