namespace WinWinCinema.Api.DTOs.Request.CompletedOrder
{
    public record UpdateCompletedOrderRequest(
        Guid Id,
        bool IsDeleted,
        Guid ScheduleId);
}
