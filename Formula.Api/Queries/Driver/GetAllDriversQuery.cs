using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries.Driver;
public class GetAllDriversQuery : IRequest<IEnumerable<DriverResponse>>
{
}