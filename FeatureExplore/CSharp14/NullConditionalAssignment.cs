namespace CSharp14;

internal class NullConditionalAssignment
{
    public event EventHandler? DemoEvent;

    public int DemoProperty { get; set; }
    public void Assign(int value)
    {
        var foo = new Foo();

        /* 
         * // C# 8.0 or earlier
        if(foo is not null)
        {
            foo.Bar = value;
        }
        
        */

        foo?.Bar = 10;
    }
    private class Foo
    {
        public int Bar { get; set; }
    }
}
