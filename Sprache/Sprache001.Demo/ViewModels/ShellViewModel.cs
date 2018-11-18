using Caliburn.Micro;
using Sprache;
using System.ComponentModel.Composition;
using System.Data;
using System.Text;

namespace Sprache001.Demo.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel:Screen
    {
        private string _sample = @"                                           21/2/2018 12:21:11

              Wt D              Fv
              23            3.4             2.3
              12.3         3.21           12.3";
        public ShellViewModel()
        {
            InputString = _sample;
        }
        public string InputString { get; set; }
        public DataTable ParsedTable { get; set; }

        public void Convert()
        {
            var parsedData = TableParser.Data.Parse(InputString);

            var info = new StringBuilder();
            info.AppendLine($"TimeStamp : {parsedData.TimeStamp.ToString()}");
            ParsedInformation = info.ToString();


            ParsedTable = new DataTable();
            foreach (var item in parsedData.Table.Headers)
            {
                ParsedTable.Columns.Add(item);
            }

            foreach (var item in parsedData.Table.ValueList)
            {
                var row = ParsedTable.NewRow();
                foreach (var key in item.Keys)
                {

                    row[key] = item[key];
                }
                ParsedTable.Rows.Add(row);
            }

            NotifyOfPropertyChange(nameof(ParsedTable));
            NotifyOfPropertyChange(nameof(ParsedInformation));
        }

        public string ParsedInformation { get;set;}
    }

    
}
