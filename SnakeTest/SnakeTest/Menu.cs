using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Menu
    {
        private List<MenuOption> menuOptions;

        private ConsolePrinter consolePrinter;

        private OptionCursor optionCursor;

        private KeyboardWatcher menuKeyboardWatcher;

        public Menu(ConsolePrinter consolePrinter, List<MenuOption> menuOptions, KeyboardWatcher keyboardWatcher)
        {
            this.MenuOptions = menuOptions;
            this.OptionCursor = new OptionCursor(0, this.MenuOptions.Count - 1);
            this.OptionCursor.OnChosenOption += this.ChosenOptionCallback;
            this.OptionCursor.OnNewSelectedOption += this.SelectedOptionCallback;
            this.consolePrinter = consolePrinter ?? throw new ArgumentNullException("The value of the console printer cannot be null!");
            this.menuKeyboardWatcher = keyboardWatcher ?? throw new ArgumentNullException("The value of the keyboard watcher cannot be null!");
            this.menuKeyboardWatcher.OnPressedKey += this.OptionCursor.PressedKeyCallback;
        }

        public OptionCursor OptionCursor
        {
            get
            {
                return this.optionCursor;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the option cursor cannot be null!");
                }

                this.optionCursor = value;
            }
        }

        public List<MenuOption> MenuOptions
        {
            get
            {
                return this.menuOptions;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the menu options cannot be null!");
                }

                this.menuOptions = value;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Snake");
            Console.WriteLine("---------");
            this.PrintOptions(this.MenuOptions);
            this.consolePrinter.Print(this.MenuOptions[0].X, this.MenuOptions[0].Y, this.MenuOptions[0].OptionText, ConsoleColor.Gray, ConsoleColor.Blue);
        }

        public void SetPointerTo(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The value of the pointer cannot be less than 0!");
            }

            if (value > this.MenuOptions.Count - 1)
            {
                throw new ArgumentOutOfRangeException("The value of the pointer cannot be greater than the highest option index!");
            }

            this.OptionCursor.OptionIndex = value;
        }

        private void SelectedOptionCallback(object sender, OnNewSelectedOptionEventArgs args)
        {
            MenuOption previousMenuOption = this.MenuOptions[args.PreviousOptionIndex];
            MenuOption currentMenuOption = this.MenuOptions[args.CurrentOptionIndex];
            this.consolePrinter.Print(previousMenuOption.X, previousMenuOption.Y, previousMenuOption.OptionText, ConsoleColor.Gray, ConsoleColor.Black);
            this.consolePrinter.Print(currentMenuOption.X, currentMenuOption.Y, currentMenuOption.OptionText, ConsoleColor.Gray, ConsoleColor.Blue);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void ChosenOptionCallback(object sender, OnChosenOptionEventArgs args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            MenuOption menuOption = this.MenuOptions[args.OptionIndex];
            this.menuKeyboardWatcher.Stop();
            menuOption.Perform();
        }

        private void PrintOptions(List<MenuOption> options)
        {
            foreach (var option in options)
            {
                this.consolePrinter.Print(option.X, option.Y, option.OptionText, ConsoleColor.Gray, ConsoleColor.Black);
            }
        }
    }
}