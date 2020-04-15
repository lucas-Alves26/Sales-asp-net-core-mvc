using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWeb.Asp.NET.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)] //Deixa o email com o link para abrir em sua caixa de email padrão
        public string Email { get; set; }

        [Display(Name = "Data de Nascimeto")]
        [DataType(DataType.Date)] //dd/MM/yyyy
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; } // Data de Nascimento

        [Display(Name ="Salário base")]
        [DisplayFormat(DataFormatString = "{0:f2}")]// adiciona duas casas decimais
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
