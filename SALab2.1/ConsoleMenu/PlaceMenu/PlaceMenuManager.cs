﻿using DAL.Entities.PlaceEntity;
using SALab2._1.ConsoleMenu.PlaceMenu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SALab2._1.ConsoleMenu.PlaceMenu
{
    internal class PlaceMenuManager : PlaceMenuBase
    {
        private static string[] options =
        {
            "1. Add place",
            "2. Edit place",
            "3. Remove place",
            "4. Add question;",
            "5. Add Comment;",
            "6. Attach file;",
            "7. Show place info;",
            "7. back."
        };

        private enum Option
        {
            ADD_PLACE = 1,
            EDIT_PLACE,
            REMOVE_PLACE,
            ADD_QUESTION,
            ADD_COMMENT,
            ATTACH_FILE,
            SHOW_PLACE_INFO,
            BACK
        }

        public PlaceMenuManager() 
            : base(options)
        {

        }

        protected sealed override ConsoleMode ProcessOption(int option)
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
                case Option.ADD_QUESTION:
                    AddQuestion();
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

        private void RemovePlace()
        {
            var place = UsePreviousPlaceOrGetAnother();
            Console.WriteLine("Are you sure?");
            if (ChoiceToBool())
            {
                PlaceService.DeletePlace(place);
            }
            else
            {
                return;
            }
        }

        private void EditPlace()
        {
            var place = UsePreviousPlaceOrGetAnother();
            Console.WriteLine("Do you want to change name?");
            if (ChoiceToBool())
            {
                place.Name = ReadDataInput("Name: ", Pattern.NAME);
            }
            Console.WriteLine("Do you want to change Category?");
            if (ChoiceToBool())
            {
                place.Category = ReadDataInput("Category: ", Pattern.NAME);
            }
            Console.WriteLine("Do you want to change unique name?");
            if (ChoiceToBool())
            {
                place.UniqueName = ReadDataInput("Unique name: ", Pattern.NAME);
            }

            Console.WriteLine("Do you want to change location?");
            if (ChoiceToBool())
            {
                place.Location = ReadDataInput("Location: ", Pattern.NAME);
            }
            PlaceService.UpdatePlace(place);
            Place = place;
        }

        private void AddPlace()
        {

            string name = ReadDataInput("Name: ", Pattern.NAME);

            string category = ReadDataInput("Category: ", Pattern.NAME);

            string uniqueName = ReadDataInput("Unique name: ", Pattern.NAME);

            string location = ReadDataInput("Location: ", Pattern.NAME);

            PlaceService.AddPlace(name, category, uniqueName, location);

            Place = new Place()
            {
                Name = name,
                Category = category,
                UniqueName = uniqueName,
                Location = location
            };
        }

        private void AddQuestion()
        {
            var place = UsePreviousPlaceOrGetAnother();
            var content = ReadDataInput("Question: ");

            PlaceService.AddQuestion(place, User, content);
        }
    }
}