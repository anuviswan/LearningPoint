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
    class g : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
    [Generator]
    public class AutoToStringGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            AutoToStringSyntaxReciever syntaxReceiver = (AutoToStringSyntaxReciever)context.SyntaxReceiver;

            // get the recorded user class
            ClassDeclarationSyntax userClass = syntaxReceiver.IdentifiedClass;
            if (userClass is null)
            {
                // if we didn't find the user class, there is nothing to do
                return;
            }


            var properties = userClass.DescendantNodes().OfType<PropertyDeclarationSyntax>();
            var code = GetSource(userClass.Identifier.Text, properties);
            
            context.AddSource(
                $"{userClass.Identifier.Text}.generated",
                SourceText.From(code, Encoding.UTF8)
            );
        }

        private string GetSource(string className,IEnumerable<PropertyDeclarationSyntax> properties)
        {
            var toStringContend = string.Join(",", properties.Select(x => $"{x.Identifier.Text}={{{x.Identifier.Text}}}"));
            var code = $@"
                        namespace Client {{
                            public partial class {className}
                            {{
                                public string ToString()=>$""{toStringContend}"";
                            }}
                        }}";
            return code;
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new AutoToStringSyntaxReciever());
        }

        private class AutoToStringSyntaxReciever : ISyntaxReceiver
        {
            public ClassDeclarationSyntax IdentifiedClass { get; private set; }
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is ClassDeclarationSyntax classDeclaration)
                {
                    var attributes = classDeclaration.DescendantNodes().OfType<AttributeSyntax>();
                    if (attributes.Any())
                    {
                        var autoToStringAttribute = attributes.FirstOrDefault(x => ExtractName(x.Name) == "AutoToString");
                        if (autoToStringAttribute != null)
                            IdentifiedClass = classDeclaration;
                    }
                }
            }

            private static string ExtractName(TypeSyntax type)
            {
                while (type != null)
                {
                    switch (type)
                    {
                        case IdentifierNameSyntax ins:
                            return ins.Identifier.Text;

                        case QualifiedNameSyntax qns:
                            type = qns.Right;
                            break;

                        default:
                            return null;
                    }
                }

                return null;
            }
        }
    
    }
}
