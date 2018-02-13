using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class AlgorithmA : BaseAlgorithm
    {
        protected override void Step1() => Console.WriteLine($"{nameof(AlgorithmA)} - {nameof(Step1)}");
        protected override void Step2() => Console.WriteLine($"{nameof(AlgorithmA)} - {nameof(Step2)}");
        protected override void Step3() => Console.WriteLine($"{nameof(AlgorithmA)} - {nameof(Step3)}");
    }

    public class AlgorithmB : BaseAlgorithm
    {
        protected override void Step1() => Console.WriteLine($"{nameof(AlgorithmB)} - {nameof(Step1)}");
        protected override void Step2() => Console.WriteLine($"{nameof(AlgorithmB)} - {nameof(Step2)}");
        protected override void Step3() => Console.WriteLine($"{nameof(AlgorithmB)} - {nameof(Step3)}");
    }

    public class AlgorithmC : BaseAlgorithm
    {
        protected override void Step1() => Console.WriteLine($"{nameof(AlgorithmC)} - {nameof(Step1)}");
        protected override void Step2() => Console.WriteLine($"{nameof(AlgorithmC)} - {nameof(Step2)}");
        protected override void Step3() => Console.WriteLine($"{nameof(AlgorithmC)} - {nameof(Step3)}");
    }
}
