namespace CSharp13;

internal class Field
{
    // No more backing fields, and autoproperties
    // only available when <LangVersion>preview<LangVersion>
    public int Foo
    {
        get => field;
        set
        {
            field = value;
            // Do something Else
        }
    }
}
