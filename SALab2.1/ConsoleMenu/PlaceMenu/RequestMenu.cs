using SALab2._1.ConsoleMenu.Base;
using Services.GeneralMappers;
using ViewModels;

namespace SALab2._1.ConsoleMenu.PlaceMenu
{
    internal class RequestMenu : MenuBase
    {
        private new static string[] options =
           {
            "1. Show Requests",
            "2. back."
        };

        public RequestMenu() :
            base(options)
        {
        }

        private enum Option
        {
            SHOW_REQUESTS = 1,
            BACK,
        }
        protected override ConsoleMode ProcessOption(int option)
        {
            Console.Clear();
            Option action = (Option)option;
            switch (action)
            {
                case Option.SHOW_REQUESTS:
                    ShowRequests();
                    return ConsoleMode.CONTINUE;
                case Option.BACK:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }
        }

        private void ShowRequests()
        {
            var requests = RequestService
                .GetRequests()
                .ToViewModel(); 
            foreach (var request in requests)
            {
                Console.WriteLine(request);
                AcceptOrDecline(request.Id);
            }
        }
        private void AcceptOrDecline(int? id)
        {
            switch(ReadDataInput("Do you want to accept, decline or hold the request? (a/d/h)"))
            {
                case "a":
                    RequestService.AcceptRequest(id);
                    break;
                case "d":
                    RequestService.DeclineRequest(id);
                    break;
                case "h":
                    break;
                default:
                    AcceptOrDecline(id);
                    break;
            }
        }
    }
}
