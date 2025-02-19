using WinWinCinema.Api.Domain.Common;

namespace WinWinCinema.Api.Domain.SupportTickets;

public class Message : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid Sender { get; set; }
    public string MessageContent { get; set; }
}

public class SupportTicket : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Guid UserId { get; set; }
    public ICollection<Message> Messages { get; set; }
    public string Subject { get; set; }
}
