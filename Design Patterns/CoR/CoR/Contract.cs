using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoR
{
    public interface IWaterfall
    {
        void Execute();
        IWaterfall NextStage { get; set; }
    }
}
