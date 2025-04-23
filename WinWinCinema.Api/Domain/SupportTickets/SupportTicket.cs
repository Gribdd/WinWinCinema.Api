using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain.SupportTickets;

public class SupportTicket : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }
    public User? User { get; set; } 
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public string Subject { get; set; } = string.Empty;
}
