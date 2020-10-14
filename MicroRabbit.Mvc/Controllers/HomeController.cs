using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroRabbit.Mvc.Models;
using MicroRabbit.Mvc.Models.Dto;
using MicroRabbit.Mvc.Services;

namespace MicroRabbit.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGatewayService gatewayService;

        public HomeController(IGatewayService gatewayService)
        {
            this.gatewayService = gatewayService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetLogs());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDto dto = new TransferDto
            {
                From = model.From,
                To = model.To,
                Amount = model.Amount
            };

            await gatewayService.Transfer(dto);

            return Redirect("Index");
        }

        private async Task<IEnumerable<TransferViewModel>> GetLogs()
        {
            var data = await gatewayService.GetLogs();
            var logs = data.Select(m => new TransferViewModel
            {
                From = m.FromAccount, 
                To = m.ToAccount, 
                Amount = m.TransferAmount
                
            }).ToList();
            return logs;
        }
    }
}