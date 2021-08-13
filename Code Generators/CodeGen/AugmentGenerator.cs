using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using SharedDemo;
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


            var code = $@"
                        namespace Client {{
                            public partial class {userClass.Identifier.Text}
                            {{
                                public string ToSqlString()=>""test"";
                            }}
                        }}";
            context.AddSource(
                $"{userClass.Identifier.Text}.generated",
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
                if (syntaxNode is ClassDeclarationSyntax classDecl && classDecl.DescendantNodes().OfType<AttributeSyntax>().Any())
                {
                    var attributes = classDecl.DescendantNodes().OfType<AttributeSyntax>();
                    var found = attributes.First(); //attributes.FirstOrDefault(x => x.DescendantTokens()?.OfType<IdentifierNameSyntax>().FirstOrDefault()?.Identifier.Text == "AutoToString");
                    if (found != null)
                    {
                        ClassToAugment = classDecl;
                    }
                }
            }
        }
    }
}
