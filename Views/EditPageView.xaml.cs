using EntityLayer.Concrete;
using EntityLayer.DTOs;
using ShoppingListMobileApp1.ViewModels;
using ShoppingListMobileApp1.Services;

namespace ShoppingListMobileApp1;

public partial class EditPageView : ContentPage
{
    private readonly ProfileService _profileService = new ProfileService();
    private readonly MainPage _mainPage = new MainPage();
    private User LoggedInUser;

    private UserDTO newUserDTO;
    
    public EditPageView(UserDTO user)
	{
		InitializeComponent();
        LoggedInUser = _mainPage.getUser();

        BindingContext = new ProfilePageViewModel(user);
        newUserDTO = user;
    }

    void BackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();
    }

    void SaveBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        LoggedInUser.UserName = newUserDTO.UserName;
        LoggedInUser.Name = newUserDTO.Name;
        LoggedInUser.Surname = newUserDTO.Surname;
        LoggedInUser.Email = newUserDTO.Email;
        LoggedInUser.PhoneNumber = newUserDTO.PhoneNumber;
        LoggedInUser.BirthDate = newUserDTO.BirthDate;
        LoggedInUser.Gender = newUserDTO.Gender;
        LoggedInUser.Password = newUserDTO.Password;

        //updateUser(newUserDTO);
        //Navigation.PushAsync(new ItemPageView());

        (BindingContext as ProfilePageViewModel).clearInput();
        Navigation.PopAsync();
    }

    public async Task<UserDTO> updateUser(UserDTO user)
    {
        UserDTO updateUser = await _profileService.UpdateUser(user);
        (BindingContext as ProfilePageViewModel).EditedUser = updateUser;

        return updateUser;
    }
}
