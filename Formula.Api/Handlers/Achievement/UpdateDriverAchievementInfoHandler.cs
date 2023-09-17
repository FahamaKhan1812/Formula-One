using AutoMapper;
using FormulaOne.Api.Commands.Achievement;
using FormulaOne.DataService.Repository.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers.Achievement;
public class UpdateDriverAchievementInfoHandler : IRequestHandler<UpdateDriverAchievementInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDriverAchievementInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDriverAchievementInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Entities.DbSet.Achievement>(request.UpdateDriverAchievementRequest);
        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();
        if(result is null)
        {
            return false;
        }
        return true;
    }
}
