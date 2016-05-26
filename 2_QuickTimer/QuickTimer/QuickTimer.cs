﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickTimer
{
    public class QuickTimer
    {
        public event EventHandler TickEvent;
        public event EventHandler PauseEvent;
        public event EventHandler ResetEvent;
        public event EventHandler StartEvent;
        public event EventHandler QuitEvent;

        private bool Paused = false;
        private bool Quit = false;
        private ManualResetEvent _ev = new ManualResetEvent(true);
        private Stopwatch _sw = new Stopwatch();

        //3. Null Conditional Operator
        //If the left hand side is null, the whole thing is null. Only if the left hand side is not null do we do the other side of the operation.
        //The Elvis Operator ?.
        // Great for triggering events

        //TODO 3: Null-conditional operators
        public long? ElapsedMilliseconds
        {
            get
            {
                if (this._sw != null)
                    return _sw.ElapsedMilliseconds;
                return 0;
                //return _sw?.ElapsedMilliseconds;
            }
        }

        //3. Null Propogating operator simplifies event triggering
        //no need to copy the delegate to a local variable and check for null before triggering
        public virtual void OnStart(EventArgs e)
        {
            var evt = StartEvent;
            if (evt != null)
            {
                evt(this, e);
            }
        }

        public void OnPause(EventArgs e)
        {
            var evt = PauseEvent;
            if (evt != null)
            {
                evt(this, e);
            }
        }

        public void OnTick(EventArgs e)
        {
            TickEvent?.Invoke(this, e);
        }

        public void OnReset(EventArgs e)
        {
            ResetEvent?.Invoke(this, e);
        }

        public void OnQuit(EventArgs e)
        {
            //Only gets invoked if the event isn't null;
            QuitEvent?.Invoke(this, e);
        }

        private void Log(string message)
        {
            Debug.WriteLine(message);
        }


        //Can be simplified to with a combination of the null propagating operator and Expression 
        // bodied properties
        //TODO 4: -- Single statement Expression Bodied properties  (also for methods)
        public long ElapsedMinutes => ElapsedSeconds.GetValueOrDefault(0) / 60L;



        public long? ElapsedSeconds
        {
            get {
                return this._sw?.ElapsedMilliseconds / 1000L;
            }
        }



        //public long? ElapsedSeconds => this._sw?.ElapsedMilliseconds / 1000L;

        


        public void Start()
        {
            //TODO 5: Nameof Operator. Rename refactoring, the string changes too.
            Log($"--- Entering the Start method.---");
            OnStart(EventArgs.Empty);
            ThreadPool.QueueUserWorkItem(ReadInput);
            _sw.Start();
            while (true)
            {
                if (Quit) break;
                OnTick(EventArgs.Empty);
                Thread.Sleep(100);
                _ev.WaitOne();
            };
            Log($"--- Exiting the {nameof(Start)} method.---");
        }

        void ReadInput(Object stateInfo)
        {
            while (true)
            {
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case 'q':
                        QuitTimer();
                        break;
                    case 'r':
                        ResetTimer();
                        TogglePause();
                        break;
                    default:
                        TogglePause();
                        break;
                }
            }
        }

        private void TogglePause()
        {
            if (!Paused)
            {
                _ev.Reset();
                _sw.Stop();
            }
            else {
                _ev.Set();
                _sw.Start();
            }
            Paused = !Paused;
        }

        private void ResetTimer()
        {
            _sw.Reset();
            OnReset(EventArgs.Empty);
        }

        private void QuitTimer()
        {
            Quit = true;
            _ev.Set();
            OnQuit(EventArgs.Empty);
        }
    }
}
