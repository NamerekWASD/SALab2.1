using Mappers.GeneralMappers;
using SALab2._1.ConsoleMenu.PlaceMenu.Base;

namespace SALab2._1.ConsoleMenu.PlaceMenu.ManagerMenu
{
    internal class RequestMenu : PlaceMenuBase
    {
        private static string[] options =
           {
            "1. Add place",
            "2. Edit place",
            "3. Remove place",
            "4. back."
        };

        public RequestMenu()
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
            Console.WriteLine("Are you sure?");
            if (ChoiceToBool())
            {
                PlaceService.DeletePlace(place.ToDTO());
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
            Place = PlaceService.EditPlace(place.ToDTO())
                .ToViewModel();
        }

        private void AddPlace()
        {

            string name = ReadDataInput("Name: ", Pattern.NAME);

            string category = ReadDataInput("Category: ", Pattern.NAME);

            string uniqueName = ReadDataInput("Unique name: ", Pattern.NAME);

            string location = ReadDataInput("Location: ", Pattern.NAME);

            Place = PlaceService.AddPlace(name,
                category,
                uniqueName,
                location)
                .ToViewModel();
        }
    }
}
