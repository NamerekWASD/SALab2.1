using SALab2._1.ConsoleMenu.Base;
using SALab2._1.ConsoleMenu.PlaceMenu;
using SALab2._1.ConsoleMenu.PlaceMenu.Base;
using SALab2._1.ConsoleMenu.PlaceMenu.ManagerMenu;
using Services.GeneralMappers;
using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace SALab2._1.ConsoleMenu.Enter
{
    internal class PersonalAccountMenu : MenuBase
    {
        public UserProfileViewModel User { get; set; }

        private static string[] options =
       {
            "1. Add visited place;",
            "2. Go to place;",
            "3. Back."
        };
        private enum Option
        {
            SETTINGS = 1,
            GO_TO_PLACE,
            BACK
        }
        private readonly PlaceMenuBase placeMenu;
        public PersonalAccountMenu(string email, string pass)
            : base(options)
        {
            User = UserService.LogIn(email, pass).ToViewModel();

            if (User.Status == "Manager")
            {
                placeMenu = new PlaceMenuManager();
            }
            else
            {
                placeMenu = new PlaceMenuUser();
            }
        }
        protected sealed override ConsoleMode ProcessOption(int option)
        {
            Console.Clear();


            Option action = (Option)option;
            switch (action)
            {
                case Option.SETTINGS:
                    Settings();
                    return ConsoleMode.CONTINUE;
                case Option.GO_TO_PLACE:
                    GoToPlaceMenu();
                    return ConsoleMode.CONTINUE;
                case Option.BACK:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }
        }
        private void Settings()
        {
            
        }

        private void GoToPlaceMenu()
        {
            placeMenu.User = User;
            placeMenu.Run();
        }
    }
}
