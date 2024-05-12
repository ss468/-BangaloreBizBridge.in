using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Dto;
using MongoDB.Bson;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvestHub.Core.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string LinkedIn { get; set; }
        public string StageofBusiness { get; set; }
        public string Website { get; set; }
        public string TypeOfInvestor { get; set; }
        public string InvestmentIntrest { get; set; }
        public double? InvestmentRange { get; set; }
        public string InvestorDetails { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        Entrepreneur,
        Investor
    }
}
