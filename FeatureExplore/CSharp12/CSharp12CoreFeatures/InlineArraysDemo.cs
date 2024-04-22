namespace CSharp12CoreFeatures;

[System.Runtime.CompilerServices.InlineArray(10)]
internal struct CustomBuffer
{
    private int _element;
}


public class InlineArrayDemo
{
    private CustomBuffer _buffer;

    public void Create(List<int> collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        if (collection?.Count != 10) throw new ArgumentOutOfRangeException($"Array size exceeds {nameof(CustomBuffer)}");
                _buffer = new CustomBuffer();

        for(int i=0;i<10;i++)
        {
            _buffer[i] = collection![i];
        }
    }

    public void Print()
    {
        foreach(var item in _buffer)
        {
            Console.Write($"{item},");
        }
    }

}
