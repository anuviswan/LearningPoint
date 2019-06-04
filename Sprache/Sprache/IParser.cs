using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprache
{
    public interface IParser<T>
    {
        IEnumerable<T> Parser(string data);
    }
}
