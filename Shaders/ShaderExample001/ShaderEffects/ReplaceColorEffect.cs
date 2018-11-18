using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderExample001.ShaderEffects
{
    public class ReplaceColorEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ReplaceColorEffect), 0);
        public Brush Input
        {

            get => ((Brush)(GetValue(InputProperty)));
            set => SetValue(InputProperty, value);
        }



        public Color OldColor
        {
            get { return (Color)GetValue(OldColorProperty); }
            set { SetValue(OldColorProperty, value); }
        }

        public static readonly DependencyProperty OldColorProperty =
            DependencyProperty.Register("OldColor", typeof(Color), typeof(ReplaceColorEffect), new PropertyMetadata(Colors.Black,PixelShaderConstantCallback(0)));


        public Color NewColor
        {
            get { return (Color)GetValue(NewColorProperty); }
            set { SetValue(NewColorProperty, value); }
        }

        public static readonly DependencyProperty NewColorProperty =
            DependencyProperty.Register("NewColor", typeof(Color), typeof(ReplaceColorEffect), new PropertyMetadata(Colors.Black, PixelShaderConstantCallback(1)));

        public ReplaceColorEffect()
        {
            PixelShader pixelShader = new PixelShader();

            pixelShader.UriSource = new Uri(@"E:\App Store\GitHub\anuviswan\LearningPoint\Shaders\ShaderExample001\Shader\ReplaceColor.ps", UriKind.Absolute);

            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(OldColorProperty);
            UpdateShaderValue(NewColorProperty);

        }
    }
}
