namespace CSharp13;

internal class ParamsCollection
{
    private List<string> _list = [];
    public void AddRange(params List<string> values)
    {
        _list.AddRange(values);
    }

    public void Print()
    {
        foreach (var item in _list)
        {
            Console.WriteLine(item);
        }
    }
}
