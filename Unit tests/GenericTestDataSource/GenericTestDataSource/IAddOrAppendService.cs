namespace GenericTestDataSource;
public interface IAddOrAppendService<T>
{
    T Execute(T firstItem, T secondItem);
}


public class StringAddOrAppendService : IAddOrAppendService<string>
{
    public string Execute(string firstItem, string secondItem) => $"{firstItem}{secondItem}";
}

public class IntAddOrAppendService : IAddOrAppendService<int>
{
    public int Execute(int firstItem, int secondItem) => firstItem + secondItem;
}