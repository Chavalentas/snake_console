using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeTest
{
    public class KeyboardWatcher
    {
        private Thread watcherThread;

        private KeyboardWatcherThreadArgs watcherArgs;

        public KeyboardWatcher()
        {
            this.watcherArgs = new KeyboardWatcherThreadArgs();
        }

        public event EventHandler<OnPressedKeyEventArgs> OnPressedKey;

        public void Start()
        {
            if (this.watcherThread != null && !this.watcherArgs.Exited)
            {
                return;
            }

            this.watcherArgs.Exited = false;
            this.watcherThread = new Thread(this.Watch);
            this.watcherThread.Start(this.watcherArgs);
        }

        public void Stop()
        {
            if (this.watcherThread == null || this.watcherArgs.Exited)
            {
                return;
            }

            this.watcherArgs.Exited = true;
            this.watcherThread.Join(100);
        }

        protected virtual void FireOnPressedKey(OnPressedKeyEventArgs args)
        {
            this.OnPressedKey?.Invoke(this, args);
        }

        private void Watch(object data)
        {
            if (!(data is KeyboardWatcherThreadArgs))
            {
                return;
            }

            KeyboardWatcherThreadArgs args = (KeyboardWatcherThreadArgs)data;

            while (!args.Exited)
            {
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    this.FireOnPressedKey(new OnPressedKeyEventArgs(keyInfo));
                }
            }
        }
    }
}
