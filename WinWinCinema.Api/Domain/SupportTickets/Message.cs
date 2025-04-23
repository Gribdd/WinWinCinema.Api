using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain.SupportTickets;

public class Message : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid Sender { get; set; }
    public string MessageContent { get; set; } = null!;
}
