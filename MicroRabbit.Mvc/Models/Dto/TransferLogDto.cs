﻿namespace MicroRabbit.Mvc.Models.Dto
{
    public class TransferLogDto
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}