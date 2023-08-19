using EntityLayer.Concrete;
using EntityLayer.DTOs;
using ShoppingListMobileApp1;
using ShoppingListMobileApp1.ViewModels;
using System.Windows.Input;

namespace ShoppingListMobileApp1.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel(UserDTO user)
        {
            EditedUser = user;
        }

        public ProfilePageViewModel()
        {
            EditCommand = new Command(OnEdit);
        }

        public ICommand EditCommand { get; }

        public UserDTO EditedUser { get; set; }

        private UserDTO _user;
        public UserDTO User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string newName;
        public string NewName
        {
            get { return newName; }
            set
            {
                newName = value;
                OnPropertyChanged();
            }
        }

        private string newSurname;
        public string NewSurname
        {
            get { return newSurname; }
            set
            {
                newSurname = value;
                OnPropertyChanged();
            }
        }

        private string newUserName;
        public string NewUserName
        {
            get { return newUserName; }
            set
            {
                newUserName = value;
                OnPropertyChanged();
            }
        }

        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged();
            }
        }

        private string newEmail;
        public string NewEmail
        {
            get { return newEmail; }
            set
            {
                newEmail = value;
                OnPropertyChanged();
            }
        }

        private int newPhonenumber;
        public int NewPhonenumber
        {
            get { return newPhonenumber; }
            set
            {
                newPhonenumber = value;
                OnPropertyChanged();
            }
        }

        private string newBirthdate;
        public string NewBirthdate
        {
            get { return newBirthdate; }
            set
            {
                newBirthdate = value;
                OnPropertyChanged();
            }
        }

        private bool newGender;
        public bool NewGender
        {
            get 
            {
                if(IsGenderMale)
                    newGender = true;
                else if(IsGenderFemale)
                    newGender = false;
                return newGender;
            }
            set
            {
                newGender = value;
                OnPropertyChanged();
            }
        }

        private bool isGenderMale;
        public bool IsGenderMale
        {
            get { return isGenderMale; }
            set
            {
                isGenderMale = value;
                OnPropertyChanged();
            }
        }

        private bool isGenderFemale;
        public bool IsGenderFemale
        {
            get { return isGenderFemale; }
            set
            {
                isGenderFemale = value;
                OnPropertyChanged();
            }
        }

        public void clearInput()
        {
            NewName = string.Empty;
            NewSurname = string.Empty;
            NewUserName = string.Empty;
            NewPassword = string.Empty;
            NewEmail = string.Empty;
            NewPhonenumber = 0;
            NewBirthdate = (DateTime.Today).ToString();
            IsGenderMale = false;
            IsGenderFemale = false;
        }

        private void OnEdit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new EditPageView(User));
        }

        // Diğer ViewModel özellikleri ve yöntemleri eklenebilir.
    }
}