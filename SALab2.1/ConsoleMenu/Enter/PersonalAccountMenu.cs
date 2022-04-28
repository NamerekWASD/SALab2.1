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
            ADD_VISITED_PLACE = 1,
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
                case Option.ADD_VISITED_PLACE:
                    AddVisitedPlace();
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
        private void AddVisitedPlace()
        {
            string name = ReadDataInput("PlaceModel name: ", Pattern.NAME);
            List<PlaceViewModel> placesFound = new();
            try
            {
                placesFound = PlaceService.GetPlacesByKeyWord(name)
                    .ToList()
                    .ToViewModel()
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            for (int i = 0; i < placesFound.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {placesFound[i].Name}");
            }
            Console.Write("Chose place via id: ");
            PlaceViewModel place = new();
            while (true)
            {
                try
                {
                    int index = int.Parse(Console.ReadLine());
                    place = placesFound[index - 1];
                    break;
                }
                catch (Exception) { }
            }
            User.VisitedPlaces.Add(place);
            UserService.UpdateUser(User.ToDTO());
        }

        private void GoToPlaceMenu()
        {
            placeMenu.User = User;
            placeMenu.Run();
        }
    }
}
