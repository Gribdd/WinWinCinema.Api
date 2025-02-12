using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinWinCinema.ApiClient.Models.ApiModels
{
    public class User
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null;
        public string Lname { get; set; } = null;
        public string Email { get; set; } = null;
        public int Password { get; set; }
        public int Mobile { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
