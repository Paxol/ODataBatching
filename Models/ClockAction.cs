namespace ODataBatching.Models;

public class ClockAction
{
    public Guid Id { get; set; }
    public string Operator { get; set; }
    public DateTimeOffset Time { get; set; }
}