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
        
        public PlaceMenuBase(string[] options)
            : base(options)
        {
        }
        protected override ConsoleMode ProcessOption(int option)
        {
            throw new NotImplementedException();
            
        }

        protected void AttachFile()
        {
            PlaceViewModel place = UsePreviousPlaceOrGetAnother();
            FileBaseViewModel file = null;
            Console.WriteLine("What attach?" +
                "\n1. Video" +
                "\n2. Photo");
            while (file is null)
            {
                switch (int.Parse(ReadDataInput("")))
                {
                    case 1:
                        try
                        {
                            file = new VideoViewModel()
                            {
                                Path = ReadDataInput("Path: "),
                            };
                        }
                        catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
                        break;
                    case 2:
                        try
                        {
                            file = new PhotoViewModel()
                            {
                                Path = ReadDataInput("Path: "),
                            };
                        }
                        catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }

                        break;
                    default:
                        Console.WriteLine(Message.DEFUNCT_OPTION);
                        break;
                }
            }

            PlaceService.AttachFile(
                place.ToDTO(),
                User.ToDTO(),
                file.ToDTO());
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
            Console.WriteLine("PlaceModel info: ");
            Console.WriteLine(place);
            Console.WriteLine(place.GetMedia());
            Console.WriteLine(place.GetComments());
        }
        private PlaceViewModel FindByKeyWord()
        {
            List<PlaceViewModel> placesFound = new();
            do
            {
                string keyword = ReadDataInput("Key word: ");
                try
                {
                    placesFound = PlaceService.
                        GetPlacesByKeyWord(keyword).
                        ToList().ToViewModel().ToList();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);

            for (int i = 0; i < placesFound.Count; i++)
            {
                PlaceViewModel? p = placesFound[i];
                Console.WriteLine($"{i + 1}. {p.Name}");
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
                catch (Exception ex) { }
            }
            return place;
        }
        protected PlaceViewModel UsePreviousPlaceOrGetAnother()
        {
            if (Place.Name is null || Place.Name.Length is 0)
            {
                return FindByKeyWord();
            }
            Console.WriteLine("Use previous place?");
            if (ChoiceToBool())
            {
                return Place;
            }
            else
            {
                return FindByKeyWord();
            }
        }
    }
}
