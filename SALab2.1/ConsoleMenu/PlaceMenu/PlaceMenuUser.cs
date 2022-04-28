using SALab2._1.ConsoleMenu.PlaceMenu.Base;

namespace SALab2._1.ConsoleMenu.PlaceMenu
{
    internal class PlaceMenuUser : PlaceMenuBase
    {
        private static string[] options =
        {
        "1. Add Comment;",
        "2. Attach file;",
        "3. Show place info;",
        "4. back."
    };
        public PlaceMenuUser()
            : base(options)
        {

        }
        private enum Option
        {
            ADD_COMMENT = 1,
            ATTACH_FILE,
            SHOW_PLACE_INFO,
            BACK
        }
        protected override ConsoleMode ProcessOption(int option)
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