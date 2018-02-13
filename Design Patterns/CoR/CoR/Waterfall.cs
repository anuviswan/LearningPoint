using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoR
{
    internal class Requirements : IWaterfall
    {
        public IWaterfall NextStage {get;set;}

        public void Execute()
        {
            Console.WriteLine(nameof(Requirements));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }

    internal class Design : IWaterfall
    {
        public IWaterfall NextStage { get; set; }

        public void Execute()
        {
            Console.WriteLine(nameof(Design));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }

    internal class Implementation : IWaterfall
    {
        public IWaterfall NextStage { get; set; }

        public void Execute()
        {
            Console.WriteLine(nameof(Implementation));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }

    internal class Verification : IWaterfall
    {
        public IWaterfall NextStage { get; set; }

        public void Execute()
        {
            Console.WriteLine(nameof(Verification));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }

    internal class Deployment : IWaterfall
    {
        public IWaterfall NextStage { get; set; }

        public void Execute()
        {
            Console.WriteLine(nameof(Deployment));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }

    internal class Maintenance : IWaterfall
    {
        public IWaterfall NextStage { get; set; }

        public void Execute()
        {
            Console.WriteLine(nameof(Maintenance));

            if (NextStage is IWaterfall)
                NextStage.Execute();
        }
    }
}
