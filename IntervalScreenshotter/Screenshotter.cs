using Screenshotter;
using System.Security.Principal;
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

        /// <summary>
        /// Directory where to write the screenshots to
        /// </summary>
        public string outputDirectory { get; private set; }

        public Screenshotter(int interval, TypeOfSeconds type, String outputDirectory)
        {
            this.interval = ParseSeconds(interval, type);
            this.outputDirectory = outputDirectory;
        }

        /// <summary>
        /// Take the screenshots.
        /// </summary>
        public void TakeScreenshots()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(this.outputDirectory);
            PrintScreen printScreen = new PrintScreen();

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