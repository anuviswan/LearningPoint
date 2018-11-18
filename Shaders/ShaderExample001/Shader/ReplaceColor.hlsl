sampler2D input: register(s0);
float4 oldColor : register(c0);
float4 newColor : register(c1);

float4 main(float2 uv:TEXCOORD) : COLOR
{
    float4 color = tex2D(input, uv);
    if (color.r == oldColor.r && color.b == oldColor.b && color.g == oldColor.g)
    {
        return newColor;
    }
    return color;
}