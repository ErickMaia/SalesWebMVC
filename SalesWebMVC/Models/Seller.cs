using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid Email. ")]
        [Required(ErrorMessage = "Email is required. ")]
        public string Email { get; set; }

        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name="Base Salary")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100, 50000, ErrorMessage = "{0} must be between 100.00 and 50,000.00. ")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        [Display(Name="Department ID")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

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

        public void AddSales (SalesRecord salesRecord)
        {
            Sales.Add(salesRecord); 
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return (from Sale in Sales where Sale.Date >= initialDate && Sale.Date <= finalDate select Sale.Amount).DefaultIfEmpty(0.00).Sum();
        }

    }
}
