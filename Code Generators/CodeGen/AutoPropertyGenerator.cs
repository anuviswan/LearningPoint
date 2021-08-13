using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGen
{
    public class AutoPropertyGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            FieldSyntaxReciever syntaxReceiver = (FieldSyntaxReciever)context.SyntaxReceiver;

            // get the recorded user class
            ClassDeclarationSyntax userClass = syntaxReceiver.IdentifiedClass;


        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new FieldSyntaxReciever());
        }

        private class FieldSyntaxReciever : ISyntaxReceiver
        {
            public ClassDeclarationSyntax IdentifiedClass { get; set; }
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if(syntaxNode is ClassDeclarationSyntax classDeclaration)
                {
                    if (classDeclaration.DescendantNodes().OfType<AttributeSyntax>().Any())
                    {
                        var attributes = classDeclaration.DescendantNodes().OfType<AttributeSyntax>();
                        var g = attributes.FirstOrDefault(x => ExtractName(x.Name) == "AutoGenerateProperty");
                        if(g!=null)
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
