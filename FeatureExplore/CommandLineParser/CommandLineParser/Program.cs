using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Measurement, Templates, RebuildIndex>(args)
                .MapResult(
                (Measurement m) => 
                    {
                        return -1;
                    }, 
                    (Templates tm) => 
                    {
                        return -2;
                    },

                (RebuildIndex inde)=>{
                    return -1;
                },
                    err => 1
                );
        }
    }

    [Verb("import", HelpText = "Import Measurements or templates")]
    public class Measurement
    {
        [Option('t',"template", HelpText = "Import Template Measurement", SetName = "Template" )]
        public bool IsTemplateMeasurement { get; set; }

        [Option('m', "measurement", HelpText = "Import Measurement", SetName = "Measurement")]
        public bool IsMeasurement { get; set; }

        [Option('d', "database", HelpText = "Import Database", SetName = "Database")]
        public bool IsDatabase { get; set; }

        [Option('s', "src", Required = true, HelpText = "Source Directory")]
        public string SourceDirectory { get; set; }

        [Option('d', "dest", Required = true, HelpText = "Destination Directory")]
        public string DestinationDirectory { get; set; }

    }
    [Verb("tm", HelpText = "Import Templates")]
    public class Templates
    { 
    }

    [Verb("rebuildindex")]
    public class RebuildIndex
    {

    }

}
