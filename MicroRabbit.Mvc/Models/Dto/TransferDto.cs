namespace MicroRabbit.Mvc.Models.Dto
{
    public class TransferDto
    {
        public int From { get; set; }
        
        public int To { get; set; }
        
        public decimal Amount { get; set; }
    }
}