using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class BaseAlgorithm
    {
        public void Execute()
        {
            Step1();
            Step2();
            Step3();
        }
        protected abstract void Step1();
        protected abstract void Step2();
        protected abstract void Step3();
    }
}
