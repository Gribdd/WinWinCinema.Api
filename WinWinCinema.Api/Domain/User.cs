
namespace WinWinCinema.Api.Domain
{
    [Table("user")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Fname { get; set; } = null;
        public string Lname { get; set; } = null;
        public string Email { get; set; } = null;
        public int Password { get; set; }
        public int Mobile { get; set; }
        public DateTime BirthDate { get; set; } 
    }
}
