using System;
using Microsoft.EntityFrameworkCore;
using exe201.Models;

namespace exe201
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EcommerceContext(
                serviceProvider.GetRequiredService<DbContextOptions<EcommerceContext>>()))
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Check if database is already seeded
                if (context.Categories.Any())
                {
                    return; // Database has been seeded
                }

                // Seed Categories
                var categories = new Category[]
                {
                    new Category { Name = "Electronics", CreatedAt = DateTime.UtcNow },
                    new Category { Name = "Clothing", CreatedAt = DateTime.UtcNow },
                    new Category { Name = "Accessories", CreatedAt = DateTime.UtcNow }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                // Seed Users
                var users = new User[]
                {
                    new User
                    {
                        Username = "admin",
                        Email = "admin@example.com",
                        Password = "hashed_password_1", // In production, use proper password hashing
                        Role = "Admin",
                        CreatedAt = DateTime.UtcNow
                    },
                    new User
                    {
                        Username = "customer1",
                        Email = "customer1@example.com",
                        Password = "hashed_password_2",
                        Role = "Customer",
                        CreatedAt = DateTime.UtcNow
                    }
                };
                context.Users.AddRange(users);
                context.SaveChanges();

                // Seed UserProfiles
                var userProfiles = new UserProfile[]
                {
                    new UserProfile
                    {
                        UserId = users[0].Id,
                        FullName = "Admin User",
                        Address = "123 Admin Street",
                        Phone = "123-456-7890",
                        AvatarUrl = "https://example.com/avatars/admin.jpg"
                    },
                    new UserProfile
                    {
                        UserId = users[1].Id,
                        FullName = "John Doe",
                        Address = "456 Customer Road",
                        Phone = "987-654-3210",
                        AvatarUrl = "https://example.com/avatars/customer1.jpg"
                    }
                };
                context.UserProfiles.AddRange(userProfiles);
                context.SaveChanges();

                // Seed Products
                var products = new Product[]
                {
                    new Product
                    {
                        Name = "Smartphone",
                        Description = "Latest model smartphone",
                        Price = 699.99m,
                        ImageUrl = "https://example.com/images/smartphone.jpg",
                        Camera360Url = "https://example.com/360/smartphone",
                        VirtualGift = false,
                        CreatedAt = DateTime.UtcNow,
                        CategoryId = categories[0].Id
                    },
                    new Product
                    {
                        Name = "T-Shirt",
                        Description = "Comfortable cotton t-shirt",
                        Price = 29.99m,
                        ImageUrl = "https://example.com/images/tshirt.jpg",
                        Camera360Url = "https://example.com/360/tshirt",
                        VirtualGift = false,
                        CreatedAt = DateTime.UtcNow,
                        CategoryId = categories[1].Id
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();

                // Seed Carts
                var carts = new Cart[]
                {
                    new Cart { UserId = users[1].Id, CreatedAt = DateTime.UtcNow }
                };
                context.Carts.AddRange(carts);
                context.SaveChanges();

                // Seed CartItems
                var cartItems = new CartItem[]
                {
                    new CartItem
                    {
                        CartId = carts[0].Id,
                        ProductId = products[0].Id,
                        Quantity = 1
                    },
                    new CartItem
                    {
                        CartId = carts[0].Id,
                        ProductId = products[1].Id,
                        Quantity = 2
                    }
                };
                context.CartItems.AddRange(cartItems);
                context.SaveChanges();

                // Seed Orders
                var orders = new Order[]
                {
                    new Order
                    {
                        UserId = users[1].Id,
                        TotalAmount = 759.97m,
                        CreatedAt = DateTime.UtcNow,
                        Status = "Pending"
                    }
                };
                context.Orders.AddRange(orders);
                context.SaveChanges();

                // Seed OrderDetails
                var orderDetails = new OrderDetail[]
                {
                    new OrderDetail
                    {
                        OrderId = orders[0].Id,
                        ProductId = products[0].Id,
                        Quantity = 1,
                        Price = 699.99m
                    },
                    new OrderDetail
                    {
                        OrderId = orders[0].Id,
                        ProductId = products[1].Id,
                        Quantity = 2,
                        Price = 29.99m
                    }
                };
                context.OrderDetails.AddRange(orderDetails);
                context.SaveChanges();

                // Seed ProductComments
                var productComments = new ProductComment[]
                {
                    new ProductComment
                    {
                        ProductId = products[0].Id,
                        UserId = users[1].Id,
                        Content = "Great smartphone, very fast!",
                        Rate = 5,
                        CreatedAt = DateTime.UtcNow
                    }
                };
                context.ProductComments.AddRange(productComments);
                context.SaveChanges();

                // Seed ChatMessages
                var chatMessages = new ChatMessage[]
                {
                    new ChatMessage
                    {
                        UserId = users[1].Id,
                        Message = "Do you have this in blue?",
                        Response = "Yes, the smartphone is available in blue.",
                        CreatedAt = DateTime.UtcNow
                    }
                };
                context.ChatMessages.AddRange(chatMessages);
                context.SaveChanges();
            }
        }
    }
}