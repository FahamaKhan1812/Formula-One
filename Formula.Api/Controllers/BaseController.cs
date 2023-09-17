﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IMediator _mediator;
  
    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
