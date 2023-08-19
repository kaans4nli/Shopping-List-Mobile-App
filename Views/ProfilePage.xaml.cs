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
        // ViewModel oluþturup, içeriði doldurun.
        viewModel = new ProfilePageViewModel();
        // Örnek bir User modeli oluþturup ViewModel'e atayýn.
        viewModel.User = LoggedInUser;
        //{
        //    UserName = LoggedInUser.UserName,
        //    Password = LoggedInUser.Password,
        //    Email = LoggedInUser.Email
        //    // Diðer özellikleri de burada doldurabilirsiniz.
        //};
    }

    private void LogoutBtn1_Clicked(object sender, EventArgs e)
    {
        _mainPage.setUserNull();
        Navigation.PushAsync(new MainPage());
    }
}