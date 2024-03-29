﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetinaOnlineServer.Application.Features.AppFeatures.AppUserFeatures.Login;
using RetinaOnlineServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetinaOnlineServer.Presentation.Controller
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
