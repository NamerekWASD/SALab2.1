using Models.MediaModel.Base;
using SALab2._1.ConsoleMenu.Base;
using Services.GeneralMappers;
using ViewModels.MediaViewModels;
using ViewModels.PlaceViewModels;
using ViewModels.UserViewModels;

namespace SALab2._1.ConsoleMenu.PlaceMenu.Base
{
    internal class PlaceMenuBase : MenuBase
    {
        public UserProfileViewModel User { get; set; } = new ();
        public PlaceViewModel Place { private get; set; } = new();

        protected static string[] options =
        {
            "1. Add visited place",
            "2. Add Comment;",
            "3. Attach file;",
            "4. Show place info;",
            "5. back."
        };
        public PlaceMenuBase(string[] anotherOptions)
            : base(options)
        {
        }
        private enum Option
        {
            ADD_VISITED_PLACE = 1,
            ADD_COMMENT ,
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
                case Option.BACK:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }

        }

        protected void AttachFile()
        {
            PlaceViewModel place = UsePreviousPlaceOrGetAnother();

            var fileList = new List<FileBaseViewModel>()
            {
                new VideoViewModel(),
                new PhotoViewModel(),
            };

            FileBaseViewModel file;

            try
            {
                file = fileList[
                    int.Parse(ReadDataInput
                    ("What attach?" +
                "\n1. Video" +
                "\n2. Photo" +
                "\nPress any key to back"))
                    ];
                file.Path = ReadDataInput("Path: ");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }


            Place = PlaceService.AttachFile(
                place.ToDTO(),
                User.ToDTO(),
                file.ToDTO()).ToViewModel();
        }

        protected void LeaveComment()
        {
            var place = UsePreviousPlaceOrGetAnother();

            var content = ReadDataInput("");

            PlaceService.AddComment(place.ToDTO(),
                User.ToDTO(),
                content);
        }

        protected void ShowPlaceInfo()
        {
            var place = UsePreviousPlaceOrGetAnother();
            Console.WriteLine("Place info: \n" 
                + place
                + place.GetMedia()
                + place.GetComments()
                );            
        }
        private PlaceViewModel FindByKeyWord()
        {
            List<PlaceViewModel> foundPlaces = new();

            string keyword = ReadDataInput("Key word: ");

            try
            {
                foundPlaces = PlaceService.
                    GetPlacesByKeyWord(keyword)
                    .ToViewModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return IterateAndChoose(foundPlaces);
            
        }

        private PlaceViewModel IterateAndChoose(List<PlaceViewModel> foundPlaces)
        {
            for (int i = 0; i < foundPlaces.Count; i++)
            {
                PlaceViewModel? p = foundPlaces[i];
                Console.WriteLine($"{i + 1}. {p.Name}");
            }

            Console.Write("Chose place via id: ");

            PlaceViewModel place = new();

            int index = int.Parse(Console.ReadLine()!);

            try
            {
                place = foundPlaces[index - 1];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return place;
        }
        protected PlaceViewModel UsePreviousPlaceOrGetAnother()
        {
            if (Place.Name is null || Place.Name.Length is 0)
            {
                return FindByKeyWord();
            }

            if (ChoiceToBool("Use previous place?"))
            {
                return Place;
            }
            else
            {
                return FindByKeyWord();
            }
        }
        protected void AddVisitedPlace()
        {
            Place = UsePreviousPlaceOrGetAnother();

            User.VisitedPlaces!.Add(Place);

            UserService.Edit(User.ToDTO());
        }
    }
}
