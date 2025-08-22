using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; } // Նոր
        public string Email { get; set; } // Նոր
        public string PasswordHash { get; set; }
    }
}