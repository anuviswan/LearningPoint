using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Text;

namespace CodeGen
{
    [Generator]
    public class HelloWorldGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var code = @"
                        using System;
                        namespace Hello {
                            public static class World 
                            {
                                public const string Name = ""Anu"";
                                public static void Hi() => Console.WriteLine($""Hi, {Name}!"");
                            }
                        }";
            context.AddSource(
                "hello.world.generator",
                SourceText.From(code, Encoding.UTF8)
            );
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            
        }
    }
}
