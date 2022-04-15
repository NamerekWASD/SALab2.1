using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;
using SALab2._1.ConsoleMenu.Base;
using SALab2._1.ConsoleMenu.PlaceMenu;
using SALab2._1.ConsoleMenu.PlaceMenu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.ConsoleMenu.Enter
{
    internal class PersonalAccountMenu : MenuBase
    {
        public User User { get; set; } = new User();

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
            User = UserService.LogIn(email, pass);

            if (User.IsManager)
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
            string name = ReadDataInput("Place name: ", Pattern.NAME);
            List<Place> placesFound = new();
            try
            {
                placesFound = PlaceService.GetPlacesByKeyWord(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            for (int i = 0; i < placesFound.Count; i++)
            {
                Place p = placesFound[i];
                Console.WriteLine($"{i + 1}. {p}");
            }
            Console.Write("Chose place via id: ");
            Place place = new();
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
            UserService.UpdateUser(User);
        }

        private void GoToPlaceMenu()
        {
            placeMenu.User = User;
            placeMenu.Run();
        }
    }
}
