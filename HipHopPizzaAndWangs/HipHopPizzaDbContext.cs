using Microsoft.EntityFrameworkCore;
using HipHopPizzaAndWangs.Models;

namespace HipHopPizzaAndWangs;

    public class HipHopPizzaDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        public HipHopPizzaDbContext(DbContextOptions<HipHopPizzaDbContext> context) : base(context) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order{ Id = 1, UserId = 1, Email = "email@email.com", Name = "Madds", Phone = 9094444444, OrderType = "Open", Tip = 2.99M },
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
            new PaymentType{ Id = 1, Type = "Cash"},
            new PaymentType{ Id = 2, Type = "Debit Card"},
            new PaymentType{ Id = 3, Type = "Credit Card"},
            new PaymentType{ Id = 4, Type = "Apple Pay"}
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product{ Id = 1, Name = "Pepperoni Pizza", Price = 24.99M },
            new Product{ Id = 2, Name = "Pineapple Pizza", Price = 24.99M },
            new Product{ Id = 3, Name = "Dr. Pepper", Price = 3.99M },
            new Product{ Id = 4, Name = "Hot Buffalo Wings", Price = 15.99M }
        });

        modelBuilder.Entity<Status>().HasData(new Status[]
        {
            new Status{ Id = 1, StatusType = "Open"},
            new Status{ Id = 2, StatusType = "Closed"}
        });

        modelBuilder.Entity<User>().HasData(new User[] {
            new User{ Id = 1, Email = "maddi@email.com", Password = "password", Uid = "123"}
        });


    }

}

