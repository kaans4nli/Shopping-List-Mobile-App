﻿namespace ShoppingListMobileApp1.Models;

    public class FavoriteItemUser
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }

