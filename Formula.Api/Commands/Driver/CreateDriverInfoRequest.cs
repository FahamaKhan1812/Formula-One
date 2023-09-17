using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;
public class CreateDriverInfoRequest : IRequest<DriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }
    public CreateDriverInfoRequest(CreateDriverRequest driverRequest)
    {
        this.DriverRequest = driverRequest;
    }

}