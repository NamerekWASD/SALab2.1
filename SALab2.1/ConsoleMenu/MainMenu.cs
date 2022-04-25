using DAL.Models.PersonEntity;
using SALab2._1.ConsoleMenu.Base;
using SALab2._1.ConsoleMenu.Enter;
using SALab2._1.Exceptions;

namespace SALab2._1.ConsoleMenu
{
    public class MainMenu : MenuBase
    {
        private static string[] options =
        {
            "1. SignIn;",
            "2. LogIn;",
            "3. Quit.",
        };

        private enum Option
        {
            GOTO_SIGNIN = 1,
            GOTO_LOGIN,
            QUIT,
        }

        private PersonalAccountMenu personalAccountMenu;

        public MainMenu()
            : base(options)
        {
        }

        protected sealed override ConsoleMode ProcessOption(int option)
        {
            Console.Clear();
            Option action = (Option)option;
            switch (action)
            {
                case Option.GOTO_SIGNIN:
                    SignIn();
                    return ConsoleMode.CONTINUE;
                case Option.GOTO_LOGIN:
                    LogIn();
                    return ConsoleMode.CONTINUE;
                case Option.QUIT:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }
        }

        private void LogIn()
        {
            string email = string.Empty;
            string password = string.Empty;

            email = ReadDataInput("Email: ");

            password = ReadDataInput("Password: ");

            personalAccountMenu = new PersonalAccountMenu(email, password);
            personalAccountMenu.Run();
        }

        private void SignIn()
        {

            string email = ReadDataInput("Email: ", Pattern.EMAIL);
            string password = string.Empty;
            while (true)
            {
                password = ReadDataInput("Password: ", Pattern.PASSWORD);
                if (password == ReadDataInput("Confirm password: "))
                {
                    break;
                }
            }

            string name = ReadDataInput("Name: ", Pattern.NAME);
            string surname = ReadDataInput("Surname: ", Pattern.NAME);
            
            Console.WriteLine("Are you manager? ");
            Role role = null;
            if (ChoiceToBool())
            {
                role = new Manager();
            }
            else
            {
                role = new UserWithoutPermission();
            }
            try
            {
                UserService.SignIn(name, surname, email, password, role);
            }
            catch (IncorrectEmailOrPasswordException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            personalAccountMenu = new PersonalAccountMenu(email, password);
            personalAccountMenu.Run();
        }
    }
}
