using EntityLayer.Concrete;
using ShoppingListMobileApp1.ViewModels;
using ShoppingListMobileApp1;
using ShoppingListMobileApp1.Services;

namespace ShoppingListMobileApp1;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileService _profileService = new ProfileService();
    private readonly MainPage _mainPage = new MainPage();
    private User LoggedInUser;

    ProfilePageViewModel viewModel;

    public ProfilePage()
	{
		InitializeComponent();

        LoggedInUser = _mainPage.getUser();
        GetUserInformation();
        BindingContext = viewModel;        
    }

    public void GetUserInformation()
    {
        // ViewModel olu�turup, i�eri�i doldurun.
        viewModel = new ProfilePageViewModel();
        // �rnek bir User modeli olu�turup ViewModel'e atay�n.
        viewModel.User = LoggedInUser;
        //{
        //    UserName = LoggedInUser.UserName,
        //    Password = LoggedInUser.Password,
        //    Email = LoggedInUser.Email
        //    // Di�er �zellikleri de burada doldurabilirsiniz.
        //};
    }

    private void LogoutBtn1_Clicked(object sender, EventArgs e)
    {
        _mainPage.setUserNull();
        Navigation.PushAsync(new MainPage());
    }
}