using SalesWeb.Asp.NET.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesWeb.Asp.NET.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        [Display(Name = "Valor")]
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        [Display(Name = "Vendedor")]
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
