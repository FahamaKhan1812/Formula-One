using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repository.Interfaces;
using MediatR;

namespace FormulaOne.Api.Handlers;
public class DeleteDriverInfoHandler : IRequestHandler<DeleteDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDriverInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
        if (driver == null)
        {
            return false;
        }
        await _unitOfWork.Drivers.Delete(request.DriverId);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
