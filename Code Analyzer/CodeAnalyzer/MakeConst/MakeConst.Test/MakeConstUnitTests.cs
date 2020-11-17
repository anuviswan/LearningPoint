using Microsoft.CodeAnalysis.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyCS = MakeConst.Test.CSharpCodeFixVerifier<
    MakeConst.MakeConstAnalyzer,
    MakeConst.MakeConstCodeFixProvider>;

namespace MakeConst.Test
{
    [TestClass]
    public class MakeConstUnitTest
    {
        //No diagnostics expected to show up
        [TestMethod]
        [DynamicData(nameof(GetValidData),DynamicDataSourceType.Method)]
        public async Task ValidCode_NoChangeExpected(string source)
        {
            await VerifyCS.VerifyAnalyzerAsync(source);
        }

        private static IEnumerable<object[]> GetValidData()
        {
            var codeWithImplicitDeclaration = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        class Foo
        {   
            public void Bar()
            {
                var i = 4;
                Console.WriteLine(i);
            }
        }
    }";

            yield return new object[] { @"" };
            yield return new object[] { codeWithImplicitDeclaration };
        }

        //Diagnostic and CodeFix both triggered and checked for
        [TestMethod]
        [DynamicData(nameof(GetInvalidData), DynamicDataSourceType.Method)]
        public async Task InvalidCode_ChangeExpected(string testSource,string fixedSource)
        {
            
            //var expected1 = new DiagnosticResult()
            //{
            //    Id = MakeConstAnalyzer.DiagnosticId,
            //    Message = new LocalizableResourceString(nameof(MakeConst.Resources.AnalyzerMessageFormat), MakeConst.Resources.ResourceManager, typeof(MakeConst.Resources)).ToString(),
            //    Severity = DiagnosticSeverity.Warning,
            //    Locations =
            //new[] {
            //        new DiagnosticResultLocation("Test0.cs", line, column)
            //    }
            //};

            var expected = VerifyCS.Diagnostic("MakeConst").WithLocation(15,17).WithArguments("TypeName");
            await VerifyCS.VerifyCodeFixAsync(testSource, expected, fixedSource);
        }

        private static IEnumerable<object[]> GetInvalidData()
        {
            var codeWithExplicitDeclaration = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        class Foo
        {   
            public void Bar()
            {
                int i = 4;
                Console.WriteLine(i);
            }
        }
    }";

            var fixtest = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        class Foo
        {   
            public void Bar()
            {
            const int i = 4;
            Console.WriteLine(i);
            }
        }
    }";

            yield return new object[] { codeWithExplicitDeclaration, fixtest };
        }
    }
}
