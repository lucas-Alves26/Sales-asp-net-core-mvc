using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Asp.NET.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } // Data de Nascimento
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Adicionar uma Venda a Lista
        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }
        //Remover uma venda da lista
        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }
        /*Calcula um total de vendas de um vendedor a partir de uma data inicial e uma data final
         Utilizando o LINQ e uma expressão LAMBIDA*/
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(salesRecord => salesRecord.Date >= initial && salesRecord.Date <= final).Sum(salesRecord => salesRecord.Amount);
        }
    }
}
