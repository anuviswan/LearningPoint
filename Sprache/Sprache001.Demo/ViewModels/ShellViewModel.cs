using Caliburn.Micro;
using Sprache;
using System.ComponentModel.Composition;
using System.Data;

namespace Sprache001.Demo.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel:Screen
    {
        public string InputString { get; set; }
        public DataTable ParsedTable { get; set; }

        public void Convert()
        {
            var parsedData = TableParser.Table.Parse(InputString);

            ParsedTable = new DataTable();
            foreach (var item in parsedData.Headers)
            {
                ParsedTable.Columns.Add(item);
            }

            foreach (var item in parsedData.ValueList)
            {
                var row = ParsedTable.NewRow();
                foreach (var key in item.Keys)
                {

                    row[key] = item[key];
                }
                ParsedTable.Rows.Add(row);
            }

            NotifyOfPropertyChange(nameof(ParsedTable));
        }
    }


}
