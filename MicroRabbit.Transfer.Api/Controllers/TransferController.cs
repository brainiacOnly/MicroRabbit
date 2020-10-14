﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Transfer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService transferService;
        
        public TransferController(ITransferService transferService)
        {
            this.transferService = transferService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(transferService.GetTransferLogs());
        }
    }
}