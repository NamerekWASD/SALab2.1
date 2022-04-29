using SALab2._1.ConsoleMenu.PlaceMenu.Base;

namespace SALab2._1.ConsoleMenu.PlaceMenu.ManagerMenu
{
    internal class PlaceMenuManager : PlaceMenuBase
    {
        private new static readonly string[] options =
        {
            "1. Add visited place;",
            "2. Add Comment;",
            "3. Attach file;",
            "4. Show place info;",
            "5. Request menu",
            "6. back."
        };

        private enum Option
        {
            ADD_VISITED_PLACE = 1,
            ADD_COMMENT,
            ATTACH_FILE,
            SHOW_PLACE_INFO,
            GO_TO_REQUEST_MENU,
            BACK
        }
        private readonly RequestMenu requestMenu;

        public PlaceMenuManager()
            : base(options)
        {
            requestMenu = new RequestMenu();
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
                case Option.ADD_COMMENT:
                    LeaveComment();
                    return ConsoleMode.CONTINUE;
                case Option.ATTACH_FILE:
                    AttachFile();
                    return ConsoleMode.CONTINUE;
                case Option.SHOW_PLACE_INFO:
                    ShowPlaceInfo();
                    return ConsoleMode.CONTINUE;
                case Option.GO_TO_REQUEST_MENU:
                    requestMenu.Run();
                    return ConsoleMode.CONTINUE;
                case Option.BACK:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }
        }

    }
}
