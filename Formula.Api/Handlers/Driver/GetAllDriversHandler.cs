using AutoMapper;
using FormulaOne.Api.Queries.Driver;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;
public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<DriverResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _unitOfWork.Drivers.All();
        var driverResult = _mapper.Map<IEnumerable<DriverResponse>>(drivers);
        return driverResult;
    }
}
