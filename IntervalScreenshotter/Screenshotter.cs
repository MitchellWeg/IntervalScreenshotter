using System.Threading;

namespace IntervalScreenshotter
{
    public class Screenshotter
    {
        public enum TypeOfSeconds
        {
            Seconds,
            Milliseconds
        }

        /// <summary>
        /// The interval of which we takes screenshots
        /// (in milliseconds)
        /// </summary>
        public int interval { get; private set; }

        public Screenshotter(int interval, TypeOfSeconds type)
        {
            this.interval = ParseSeconds(interval, type);
        }

        /// <summary>
        /// Take the screenshots.
        /// </summary>
        public void TakeScreenshots()
        {
            while(true)
            {
                Thread.Sleep(interval);
                Console.WriteLine("Taken");
            }
        }

        /// <summary>
        /// Parse the amount of seconds passed in.
        /// The original amount is passed in as milliseconds.
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ParseSeconds(int seconds, TypeOfSeconds type)
        {
            switch(type)
            {
                case TypeOfSeconds.Milliseconds:
                {
                    return seconds;
                }
                case TypeOfSeconds.Seconds:
                {
                    return seconds * 1000;
                }
            }

            return 0;
        }
    }
}