using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePatternSearch
{
    public class PatternResponse
    {
        public string Pattern { get; set; }
        public IEnumerable<string> WordsFound { get; set; }
        public Action OnMatchAction { get; set; }
    }
}
