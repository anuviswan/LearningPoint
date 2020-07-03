namespace SwitchExpressions
{
    interface IIfCondition<T>
    {
        string Evaluate(T criteria);
    }
}
