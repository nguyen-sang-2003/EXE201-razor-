﻿namespace exe201.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }

}
