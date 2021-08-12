using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CodeGen
{
    [Generator]
    public class AugmentGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            AugmentSyntaxReciever syntaxReceiver = (AugmentSyntaxReciever)context.SyntaxReceiver;

            // get the recorded user class
            ClassDeclarationSyntax userClass = syntaxReceiver.ClassToAugment;
            if (userClass is null)
            {
                // if we didn't find the user class, there is nothing to do
                return;
            }

            var code = @"
                        using System;
                        namespace Hello {
                            public static class World1 
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
            context.RegisterForSyntaxNotifications(() => new AugmentSyntaxReciever());
        }

        private class AugmentSyntaxReciever : ISyntaxReceiver
        {
            public ClassDeclarationSyntax ClassToAugment { get; private set; }
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
#if DEBUG
                if (!Debugger.IsAttached)
                {
                    Debugger.Launch();
                }
#endif 

                if (syntaxNode is ClassDeclarationSyntax classDecl && classDecl.DescendantNodes().OfType<AttributeSyntax>().Any())
                {
                    var attributes = classDecl.DescendantNodes().OfType<AttributeSyntax>();
                }
            }
        }
    }
}
