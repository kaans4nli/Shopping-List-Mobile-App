﻿using Microsoft.Maui.Devices;
using ShoppingListMobileApp1.Models;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp1;

public partial class CartPageView : ContentPage
{
    int clickCountTotal = 1;

    public ObservableCollection<Products> product { get; set; }
    public CartPageView()
    {
        InitializeComponent();
        Products();
    }


    private void Products()
    {
        product = new ObservableCollection<Products>()
        {
            new Products() {Name = "Apple", Description="Iphone 14 Pro Max", Image="telefon.jpg", Price="1199$"},
            new Products() {Name = "Monster", Description="Abra A5", Image="laptop.jpeg", Price="999$"},
            new Products() {Name = "Apple", Description="AirPods", Image="airpods.jpeg", Price="300$"},
            new Products() {Name = "Apple", Description="Watch Series8", Image="watch.jpeg", Price="259$"},
            new Products() {Name = "Princes", Description="Cinderella", Image="cinderella.jpg", Price="-$"}
        };
    }

    private void checkoutbtn_Clicked(object sender, EventArgs e)
    {
        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new ProfilePage());

    }

    private void Button_Clicked_Home(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ItemPageView());
    }

    private void Button_Clicked_Search(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ItemPageView());
    }

    private void Button_Clicked_Checkout(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CheckoutPageView());
    }

    private void ImageButton_Decrease(object sender, EventArgs e)
    {
        //clickCountTotal -= 1;
        //count.Text = $"{clickCountTotal}";
        //if (clickCountTotal == 0)
        //{
        //    ImageFrame.IsVisible = false;
        //    DetailFrame.IsVisible = false;
        //}
    }

    private void ImageButton_Increase(object sender, EventArgs e)
    {
        //clickCountTotal += 1;
        //count.Text = $"{clickCountTotal}";
    }

    private void ImageButton_Close(object sender, EventArgs e)
    {
        //ImageFrame.IsVisible = false;
        //DetailFrame.IsVisible = false;
    }
}
