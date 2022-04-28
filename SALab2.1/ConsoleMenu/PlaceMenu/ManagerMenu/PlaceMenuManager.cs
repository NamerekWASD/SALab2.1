using SALab2._1.ConsoleMenu.PlaceMenu.Base;

namespace SALab2._1.ConsoleMenu.PlaceMenu.ManagerMenu
{
    internal class PlaceMenuManager : PlaceMenuBase
    {
        private static string[] options =
        {
            
            "5. Add Comment;",
            "6. Attach file;",
            "7. Show place info;",
            "8. back."
        };

        private enum Option
        {
            ADD_COMMENT = 1,
            ATTACH_FILE,
            SHOW_PLACE_INFO,
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
                case Option.ADD_COMMENT:
                    LeaveComment();
                    return ConsoleMode.CONTINUE;
                case Option.ATTACH_FILE:
                    AttachFile();
                    return ConsoleMode.CONTINUE;
                case Option.SHOW_PLACE_INFO:
                    ShowPlaceInfo();
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
