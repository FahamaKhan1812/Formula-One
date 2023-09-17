using MediatR;

namespace FormulaOne.Api.Commands;
public class DeleteDriverInfoRequest : IRequest<bool>
{
    public Guid DriverId { get; set; }
    public DeleteDriverInfoRequest(Guid driverId)
    {
        DriverId = driverId;
    }

}
