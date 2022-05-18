using BLL.Service;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using SALab2._1.ConsoleMenu.Base;
using SALab2._1.ConsoleMenu.PlaceMenu;

namespace SALab2._1.ConsoleMenu
{
    public class MainMenu : MenuBase
    {
        private static string[] options =
        {
            "1. Go to place menu;",
            "2. Go to request menu;",
            "3. Quit.",
        };

        private enum Option
        {
            GOTO_PLACE_MENU = 1,
            GOTO_REQUEST_MENU,
            QUIT,
        }
        private readonly PlaceMain placeMenu;
        private readonly RequestMenu requestMenu;
        public MainMenu()
            : base(options)
        {
            placeMenu = new PlaceMain();
            requestMenu = new RequestMenu();
        }

        protected sealed override ConsoleMode ProcessOption(int option)
        {
            Console.Clear();
            Option action = (Option)option;
            switch (action)
            {
                case Option.GOTO_PLACE_MENU:
                    PlaceMenu();
                    return ConsoleMode.CONTINUE;
                case Option.GOTO_REQUEST_MENU:
                    Requests();
                    return ConsoleMode.CONTINUE;
                case Option.QUIT:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }
        }

        private void PlaceMenu()
        {
            placeMenu.Run();
        }
        private void Requests()
        {
            requestMenu.Run();
        }

    }
}
