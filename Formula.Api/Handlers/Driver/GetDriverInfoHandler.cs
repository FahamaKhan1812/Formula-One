using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;
public class GetDriverInfoHandler : IRequestHandler<CreateDriverInfoRequest, DriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = _mapper.Map<Driver>(request.DriverRequest);
        await _unitOfWork.Drivers.Add(driver);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<DriverResponse>(driver);
    }
}
