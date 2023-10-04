namespace HipHopPizzaAndWangs.Models;

    public class Order
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PaymentTypeId { get; set; }
    public int StatusId { get; set; }
    public ICollection<Product> products { get; set; }
    }

