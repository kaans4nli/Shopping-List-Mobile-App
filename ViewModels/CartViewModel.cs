using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp1.ViewModels
{
    public class CartViewModel : BindableObject
    {
        //private ObservableCollection<CartItem> _cartItems;
        //public ObservableCollection<CartItem> CartItems
        //{
        //    get { return _cartItems; }
        //    set
        //    {
        //        _cartItems = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ObservableCollection<CartItem> CartItems { get; set; }

        public CartViewModel()
        {
            // Örnek ürünleri ekleyelim.
            CartItems = new ObservableCollection<CartItem>
            {
                new CartItem { ProductName = "Ürün 1", Description = "ürün 1", Quantity = 2, Price = "100", ProductImage = "airpods.jpeg" },
                new CartItem { ProductName = "Ürün 2", Description = "ürün 2", Quantity = 1, Price = "200", ProductImage = "telefon.jpg" },
                new CartItem { ProductName = "Ürün 3", Description = "ürün 3", Quantity = 3, Price = "300", ProductImage = "watch.jpeg"},
                new CartItem { ProductName = "Ürün 3", Description = "ürün 3", Quantity = 3, Price = "300", ProductImage = "watch.jpeg"},
                new CartItem { ProductName = "Ürün 3", Description = "ürün 3", Quantity = 3, Price = "300", ProductImage = "watch.jpeg"}
            };

            IncreaseQuantityCommand = new Command<CartItem>(OnIncreaseQuantity);
            DecreaseQuantityCommand = new Command<CartItem>(OnDecreaseQuantity);
        }

        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }

        private string newTotalPrice;
        public string NewTotalPrice
        {
            get 
            {
                int total_price = 0;
                for (int i = 0; i < CartItems.Count; i++)
                {
                    total_price += int.Parse(CartItems[i].Price);
                }
                newTotalPrice = total_price.ToString();
                return newTotalPrice; 
            }
            set
            {
                newTotalPrice = value;
                OnPropertyChanged();
            }
        }

        private CartItem selectedCartItem;
        public CartItem SelectedCartItem
        {
            get { return selectedCartItem; }
            set
            {
                selectedCartItem = value;
                OnPropertyChanged();
                //IsAddressSelected = selectedAddress != null;
            }
        }

        private void OnIncreaseQuantity(CartItem item)
        {
            item.Quantity += 1;
        }

        private void OnDecreaseQuantity(CartItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
        }
    }

    public class CartItem
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string ProductImage { get; set; }
    }
}
