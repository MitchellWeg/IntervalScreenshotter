using IntervalScreenshotter;
using CommandLine;
using CommandLine.Text;

namespace Screenshotter 
{
    internal class Program
    {
        public class Options
        {
            [Option('i', "interval", Required = true, HelpText = "Set interval (in milliseconds)")]
            public int Interval { get; set; }

            [Option('s', "seconds", Required = false, HelpText = "Set interval to seconds")]
            public bool Seconds { get; set; }

            [Option('o', "output-dir", Required = false, HelpText = "Full directory path of which to write the screenshots to. If unset, 'MyDocuments' will be used. ")]
            public string? OutputDirectory { get; set; }
        }
    
        static void Main(string[] args)
        {
             var parser = new CommandLine.Parser(with => with.HelpWriter = null);
             var parserResult = parser.ParseArguments<Options>(args);
             parserResult.WithParsed<Options>(options => Run(options))
                         .WithNotParsed(errs => DisplayHelp(parserResult, errs));
        }


        private static void Run(Options opts)
        {
            IntervalScreenshotter.Screenshotter.TypeOfSeconds _type = IntervalScreenshotter.Screenshotter.TypeOfSeconds.Milliseconds;

            if (opts.Seconds)
            {
                _type = IntervalScreenshotter.Screenshotter.TypeOfSeconds.Seconds;
            }

            if(opts.OutputDirectory == null)
            {
                var documentsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                opts.OutputDirectory = documentsDir;
            }

            IntervalScreenshotter.Screenshotter screenshotter = new IntervalScreenshotter.Screenshotter(opts.Interval, _type, opts.OutputDirectory);

            screenshotter.TakeScreenshots();
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable< Error> errs)
        {  
          var helpText = HelpText.AutoBuild(result, h =>
          {
            h.AdditionalNewLineAfterOption = false;
            h.Heading = "IntervalScreenshotter 0.0.1"; 
            h.Copyright = "Copyright (c) MitchellWeg 2022"; 
            return HelpText.DefaultParsingErrorsHandler(result, h);
          }, e => e);
          Console.WriteLine(helpText);
        }

    }
}
