using DAL.Models.MediaEntity;
using DAL.Models.MediaEntity.Base;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;
using SALab2._1.ConsoleMenu.Base;

namespace SALab2._1.ConsoleMenu.PlaceMenu.Base
{
    internal class PlaceMenuBase : MenuBase
    {
        public User User { get; set; } = new User();
        public Place Place { private get; set; } = new();
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
            Place place = UsePreviousPlaceOrGetAnother();
            FileBase file = null;
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
                            file = new Video(ReadDataInput("Path: "));
                        }
                        catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
                        break;
                    case 2:
                        try
                        {
                            file = new Photo(ReadDataInput("Path: "));
                        }
                        catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }

                        break;
                    default:
                        Console.WriteLine(Message.DEFUNCT_OPTION);
                        break;
                }
            }

            PlaceService.AttachFile(place, User, file);
        }

        protected void LeaveComment()
        {
            var place = UsePreviousPlaceOrGetAnother();
            var content = ReadDataInput("");
            PlaceService.AddComment(place, User, content);
        }

        protected void ShowPlaceInfo()
        {
            var place = UsePreviousPlaceOrGetAnother();
            Console.WriteLine("Place info: ");
            Console.WriteLine(place);
            Console.WriteLine(place.GetMedia());
            Console.WriteLine(place.GetComments());
        }
        private Place FindByKeyWord()
        {
            List<Place> placesFound = new List<Place>();
            do
            {
                string keyword = ReadDataInput("Key word: ");
                try
                {
                    placesFound = PlaceService.GetPlacesByKeyWord(keyword);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!Equals(Console.ReadKey(), 'b'));
            for (int i = 0; i < placesFound.Count; i++)
            {
                Place? p = placesFound[i];
                Console.WriteLine($"{i + 1}. {p.Name}");
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
                catch (Exception ex) { }
            }
            return place;
        }
        protected Place UsePreviousPlaceOrGetAnother()
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
