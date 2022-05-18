using BLL.Service;
using DAL.Contexts;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using SALab2._1.ConsoleMenu.Base;
using Services.GeneralMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace SALab2._1.ConsoleMenu.PlaceMenu
{
    internal class PlaceMain : MenuBase
    {
        private new static string[] options =
           {
            "1. Add place",
            "2. Edit place",
            "3. delete place",
            "4. back."
        };

        public PlaceMain()
            : base(options)
        {
        }

        private enum Option
        {
            ADD_PLACE = 1,
            EDIT_PLACE,
            REMOVE_PLACE,
            BACK,
        }
        protected override ConsoleMode ProcessOption(int option)
        {
            Console.Clear();
            Option action = (Option)option;
            switch (action)
            {
                case Option.ADD_PLACE:
                    AddPlace();
                    return ConsoleMode.CONTINUE;
                case Option.EDIT_PLACE:
                    EditPlace();
                    return ConsoleMode.CONTINUE;
                case Option.REMOVE_PLACE:
                    RemovePlace();
                    return ConsoleMode.CONTINUE;
                case Option.BACK:
                    return ConsoleMode.QUIT;
                default:
                    Console.WriteLine(Message.DEFUNCT_OPTION);
                    return ConsoleMode.CONTINUE;
            }

        }
        private void RemovePlace()
        {
            var place = UsePreviousPlaceOrGetAnother();
            if (ChoiceToBool("Confirm delete?"))
            {
                PlaceService.DeletePlace(place.Id);
            }
            else
            {
                Place = place;
            }
        }

        private void EditPlace()
        {
            PlaceViewModel place = new();
            while (place == null || place.Name == null)
            {
                place = UsePreviousPlaceOrGetAnother();
            }
            

            if (ChoiceToBool("Do you want to change name?"))
            {
                place.Name = ReadDataInput("Name: ", Pattern.NAME);
            }

            if (ChoiceToBool("Do you want to change Category?"))
            {
                place.Category = ReadDataInput("Category: ", Pattern.NAME);
            }

            if (ChoiceToBool("Do you want to change country?"))
            {
                place.Country = ReadDataInput("Unique name: ", Pattern.NAME);
            }

            if (ChoiceToBool("Do you want to change city place?"))
            {
                place.City = ReadDataInput("Location: ", Pattern.NAME);
            }

            Place = PlaceService.EditPlace(place.ToDTO())
                .ToViewModel();
        }

        private void AddPlace()
        {

            string name = ReadDataInput("Name: ", Pattern.NAME);

            string category = ReadDataInput("Category: ", Pattern.NAME);

            string Country = ReadDataInput("Country: ", Pattern.NAME);

            string City = ReadDataInput("City: ", Pattern.NAME);

            Place = PlaceService.AddPlace(name,
                category,
                Country,
                City)
                .ToViewModel();
        }

        private PlaceViewModel UsePreviousPlaceOrGetAnother()
        {
            if(Place != null && ChoiceToBool("Use Previous place?"))
            {
                return Place;
            }
            if(ChoiceToBool("Narrow search circle by entering keyword? (in other case you'll get all places)"))
            {
                try
                {
                    return GetById(PlaceService
                   .GetPlacesByKeyWord(ReadDataInput("Keyword: "))
                   .ToViewModel());
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    return GetById(PlaceService
                        .GetAll()
                        .ToViewModel());
                }catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
        private PlaceViewModel GetById(List<PlaceViewModel> places)
        {
            foreach(var place in places)
            {
                Console.WriteLine(place);
            }
            int index = int.Parse(ReadDataInput("Type id place to return: ", Pattern.NUMBER));
            while(true){
                try
                {
                    return PlaceService
                        .GetPlaceById(index)
                        .ToViewModel();
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
