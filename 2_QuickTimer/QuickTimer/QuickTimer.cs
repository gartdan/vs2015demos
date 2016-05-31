using System;
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

        //TODO 3: Null-conditional operators
        public long ElapsedMilliseconds
        {
            get
            { 
                if (this._sw != null)
                    return _sw.ElapsedMilliseconds;
                else return 0;
                //return _sw?.ElapsedMilliseconds ?? 0;
            }
        }

        //3. Null Propogating operator simplifies event triggering
        //no need to copy the delegate to a local variable and check for null before triggering
        public virtual void OnStart(EventArgs e)
        {
            var evt = StartEvent;
            if(evt != null)
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
            var evt = TickEvent;
            if (evt != null)
            {
                evt(this, e);
            }
        }

        public void OnReset(EventArgs e)
        {
            ResetEvent?.Invoke(this, e);
        }

        public void OnQuit(EventArgs e)
        {
            QuitEvent?.Invoke(this, e);
        }

        private void Log(string message)
        {
            Debug.WriteLine(message);
        }


        //Can be simplified to with a combination of the null propagating operator and Expression 
        // bodied properties
        //TODO 4: -- Single statement Expression Bodied properties  (also for methods)
        public long ElapsedMinutes => ElapsedSeconds / 60L;


        public long ElapsedSeconds => this._sw?.ElapsedMilliseconds ?? 0L / 1000L;


        public void Start(int? delay = null)
        {
            //TODO 5: Nameof Operator. Rename refactoring, the string changes too.
            Log($"--- Entering the {nameof(Start)} method. The value of {nameof(delay)} is {delay}---");
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
            //TODO 6: Exception filters
            try
            {
                if (!Paused)
                {
                    _ev.Reset();
                    _sw.Stop();
                }
                else
                {
                    _ev.Set();
                    _sw.Start();
                }
                Paused = !Paused;
            } catch (Exception ex) //when (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            { }

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
