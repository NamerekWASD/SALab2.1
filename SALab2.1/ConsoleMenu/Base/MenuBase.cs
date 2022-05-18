using BLL.Service;
using BLL.Service.Base;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SALab2._1.ConsoleMenu.Interfaces;
using System.Text.RegularExpressions;
using ViewModels;

namespace SALab2._1.ConsoleMenu.Base
{
    public abstract class MenuBase : IMenu<int>, IRunableMenu
    {
        protected PlaceViewModel Place { get; set; }
        private readonly string[] options;
        protected enum ConsoleMode
        {
            ERROR = -1,
            QUIT = 0,
            CONTINUE = 1,
        }
        protected struct Message
        {
            public const string ERR_MESSAGE = "Incorrect use of the application.";
            public const string DEFUNCT_OPTION = "Option does not exist.";
            public const string UNDEFINED_OPTIONS = "Empty options list.";
        }
        protected struct Pattern
        {
            public const string NAME = @"^[a-zA-Z]+[\s|-]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            public const string NUMBER = @"^\d$";
        }
        public MenuBase(string[] options = null)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)Thread
                .CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;

            this.options = options ?? new string[] { Message.UNDEFINED_OPTIONS };
        }
        protected abstract ConsoleMode ProcessOption(int option);

        protected IPlaceService PlaceService;
        protected IRequestService RequestService;
        protected virtual string ReadDataInput(string message, string pattern = "")
        {
            if (pattern != "")
            {
                while (true)
                {
                    Console.Write(message);
                    string input = Console.ReadLine();

                    bool isValidInput = ValidateInput(input, pattern);
                    if (isValidInput)
                    {
                        return input.Trim();
                    }
                }
            }
            else
            {
                Console.Write(message);
                return Console.ReadLine().Trim();
            }
        }
        protected virtual bool ValidateInput(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
        public virtual void Run()
        {
            while (true)
            {
                RenderOptions();
                ConsoleMode mode = SetMode();

                if (mode == ConsoleMode.ERROR ||
                    mode == ConsoleMode.QUIT)
                {
                    break;
                }
            }
        }

        public virtual void RenderOptions()
        {
            foreach (var option in options)
            {
                Console.WriteLine(option);
            }
        }
        private ConsoleMode SetMode()
        {
            try
            {
                int option = ReadOption();
                return ProcessOption(option);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return ConsoleMode.ERROR;
            }
        }
        public virtual int ReadOption()
        {
            string input = Console.ReadLine();
            bool Valid = ValidateInput(input, @"[1-9]");
            if (!Valid)
            {
                throw new NotFoundException(Message.ERR_MESSAGE);
            }
            return int.Parse(input);
        }
        protected bool ChoiceToBool(string message = "")
        {
            string choice;
            while (true)
            {
                Console.Write($"{message} (y/n): ");
                choice = Console.ReadLine();
                if (choice == "y")
                    return true;
                else if (choice == "n")
                    return false;
            }
        }
    }
}
