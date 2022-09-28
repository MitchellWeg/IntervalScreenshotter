﻿using IntervalScreenshotter;
using CommandLine;
using CommandLine.Text;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

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

            [Option('v', "verbose", Required = false, HelpText = "Set to verbose mode")]
            public bool Verbose { get; set; }

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

            foreach(int shot in screenshotter.TakeScreenshots())
            {
                if (opts.Verbose)
                {
                    Console.WriteLine(shot);
                }
            }
        }

        static void DisplayHelp<T>(ParserResult<T> result, IEnumerable< Error> errs)
        {  
          string copyRightNotice = "Copyright (c) MitchellWeg 2022";
          string programName = "IntervalScreenshotter";
          string programVersion = "1.0.0";

          var helpText = HelpText.AutoBuild(result, h =>
          {
            h.AdditionalNewLineAfterOption = false;
            h.Heading = String.Format("{0} version {1}", programName, programVersion); 
            h.Copyright = copyRightNotice; 
            return HelpText.DefaultParsingErrorsHandler(result, h);
          }, e => e);
          Console.WriteLine(helpText);
        }

    }
}
