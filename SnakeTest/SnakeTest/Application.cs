using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class Application
    {
        private Menu menu;

        private ConsolePrinter consolePrinter;

        private GameScoreTable gameScoreTable;

        private GameScoreTableLoader tableLoader;

        private GameScoreTableSaver tableSaver;

        private KeyboardWatcher menuKeyboardWatcher;

        public Application()
        {
            this.consolePrinter = new ConsolePrinter();
            this.tableLoader = new GameScoreTableLoader();
            this.tableSaver = new GameScoreTableSaver();
            this.menuKeyboardWatcher = new KeyboardWatcher();
            this.SetGameScoreTable(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "scores.dat");
            this.SetMenu();
        }

        public GameScoreTable GameScoreTable
        {
            get
            {
                return this.gameScoreTable;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the game score table cannot be null!");
                }

                this.gameScoreTable = value;
            }
        }

        public Menu Menu
        {
            get
            {
                return this.menu;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value of the menu cannot be null!");
                }

                this.menu = value;
            }
        }

        public void Start()
        {
            Console.CursorVisible = false;
            this.menuKeyboardWatcher.Start();
            this.Menu.Draw();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        private void SetGameScoreTable(string path)
        {
            try
            {
                this.gameScoreTable = this.tableLoader.LoadFrom(path);
            }
            catch (DeserializationErrorException)
            {
                this.gameScoreTable = new GameScoreTable();
            }
            catch (Exception)
            {
                this.Exit();
            }
        }

        private void StoreGameScoreTable(string path)
        {
            try
            {
                this.tableSaver.Save(path, this.GameScoreTable);
            }
            catch (Exception)
            {
                this.Exit();
            }
        }

        private void SetMenu()
        {
            StartGameOption startGameOption = new StartGameOption("New game", 0, 2);
            startGameOption.OnFinishedGame += this.FinishedGameCallback;
            startGameOption.OnFinishedExecution += this.FinishedOptionExecutionCallback;
            ViewScoresOption scoresOption = new ViewScoresOption("View scores", 0, 3, this.GameScoreTable);
            scoresOption.OnFinishedExecution += this.FinishedOptionExecutionCallback;
            QuitApplicationOption quitApplicationOption = new QuitApplicationOption("Quit", 0, 4);
            quitApplicationOption.OnFinishedExecution += this.FinishedOptionExecutionCallback;

            List<MenuOption> menuOptions = new List<MenuOption>()
            {
                startGameOption,
                scoresOption, 
                quitApplicationOption
            };


            Menu menu = new Menu(this.consolePrinter, menuOptions, this.menuKeyboardWatcher);
            this.Menu = menu;
        }

        private void FinishedOptionExecutionCallback(object sender, OnFinishedOptionExecutionEventArgs args)
        {
            if (args.ExitRequested)
            {
                this.StoreGameScoreTable(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "scores.dat");
                this.Exit();
                return;
            }

            Console.Clear();
            this.menuKeyboardWatcher.Start();
            this.Menu.SetPointerTo(0);
            this.Menu.Draw();
        }

        private void FinishedGameCallback(object sender, OnFinishedGameEventArgs args)
        {
            this.GameScoreTable.GameScores.Add(args.GameScore);
        }
    }
}
