using AutoMapper;
using FormulaOne.Api.Queries.Driver;
using FormulaOne.DataService.Repository.Interfaces;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers;
public class GetDriverHandler : IRequestHandler<GetDriverQuery, DriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DriverResponse?> Handle(GetDriverQuery request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
        if (driver == null)
        {
            return null;
        }
        var result = _mapper.Map<DriverResponse>(driver);

        return result;
    }
}