﻿namespace ShoppingListMobileApp1.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CategoryDetail> CategoryDetail { get; set; }


    }
}
