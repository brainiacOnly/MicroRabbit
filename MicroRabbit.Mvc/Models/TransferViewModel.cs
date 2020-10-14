using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Mvc.Models
{
    public class TransferViewModel
    {
        public string Notes { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }
}