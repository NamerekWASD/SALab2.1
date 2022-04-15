using DAL.Entities.CommentEntity;
using DAL.Entities.MediaEntity;
using DAL.Entities.MediaEntity.Base;
using DAL.Entities.MediaEntity.MatchingToPlace;
using DAL.Entities.PersonEntity;
using DAL.Entities.PlaceEntity;
using SALab2._1.ConsoleMenu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.ConsoleMenu.PlaceMenu.Base
{
    internal class PlaceMenuBase : MenuBase
    {
        public User User { get; set; } = new();
        public Place Place { private get; set; } = new ();
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
                            file = new Video(ReadDataInput("Path: ", Pattern.PATH));
                        }
                        catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
                        break;
                    case 2:
                        try
                        {
                            file = new Photo(ReadDataInput("Path: ", Pattern.PATH));
                        }catch (FileNotFoundException ex) { Console.WriteLine(ex.Message); }
                        
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
            string keyword = ReadDataInput("Key word: ");
            List<Place> placesFound = new();
            try
            {
                placesFound = PlaceService.GetPlacesByKeyWord(keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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
            if(Place.Name is null || Place.Name.Length is 0)
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
