namespace HipHopPizzaAndWangs.Models;

    public class Order
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PaymentTypeId { get; set; }
    public int StatusId { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string OrderType { get; set; }
    public string Name { get; set; }
    public decimal Tip { get; set; }
    public List<Product> products { get; set; }
    public PaymentType PaymentType { get; set; }
    public Status Status { get; set; }
    }

