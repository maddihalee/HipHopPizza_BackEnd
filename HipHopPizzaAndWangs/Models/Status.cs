namespace HipHopPizzaAndWangs.Models;

    public class Status
    {
    public int Id { get; set; }
    public string StatusType { get; set; }
    public ICollection<Order> Order { get; set; }
    }

