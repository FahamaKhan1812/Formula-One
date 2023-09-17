using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.Driver;
public class GetDriverQuery : IRequest<DriverResponse>
{
    public Guid DriverId { get; }

    public GetDriverQuery(Guid driverId)
    {
        DriverId = driverId;
    }
}