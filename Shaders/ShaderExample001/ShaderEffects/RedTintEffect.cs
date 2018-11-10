using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderExample001.ShaderEffects
{
    public class RedTintEffect: ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RedTintEffect), 0);
        public Brush Input
        {

            get => ((Brush)(GetValue(InputProperty)));
            set => SetValue(InputProperty, value);
        }

        public RedTintEffect()
        {
            PixelShader pixelShader = new PixelShader();

            pixelShader.UriSource = new Uri(@"E:\App Store\GitHub\anuviswan\LearningPoint\Shaders\ShaderExample001\Shader\RedTint.ps", UriKind.Absolute);

            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);


        }
    }
}
