using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.Api.Commands;
public class UpdateDriverInfoRequest : IRequest<bool>
{
    public UpdateDriverRequest UpdateDriver {  get; }
    public UpdateDriverInfoRequest(UpdateDriverRequest updateDriver)
    {
        this.UpdateDriver = updateDriver;
    }

}
