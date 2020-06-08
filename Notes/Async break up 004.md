During this series of deep dive into the asynchronous calls, we have so far looked into

- [x] General Structure of generated code.
- [x] Role of Stub/Worker method.
- [x] Structure of State Machine and role of Fields.
- [x] Implementation of the `SetStateMachine` method.
- [ ] Implementation of the `MoveNext` method.

It is now time to look at the most important piece of the puzzle - the `MoveNext()` method.

Before we begin exploring the `MoveNext()`, let us remind ourself that the method is called when the async method is first invoked and then, each time it is resumed. The Method would be responsible for the following.

- Ensure the method starts/resumes execution at the right place when it starts for the first time or resumes after a pause.
- Preserve the state of State Machine when it needs to pause.
- Schedule a continuation when the awaited expression hasn't been completed yet.
- Retrieve values from the awaiter.
- Propagate the return values or method completion via the Builder.
- Propagate the exceptions if any via the Builder.

The last 2 points are curious if you were to consider that the `MoveNext` method has a void return Type. So how does the `MoveNext` return the result or exceptions ? Of course via the Builder instance. It is the role of the `Stub` method to return the Task to the Caller method.

Without taking any time longer, let us take a peek at the generated code. We will then proceed to split it into parts and find how it works

**The Whole Code**

```csharp
private void MoveNext()
{
    int num = <>1__state;
    try
    {
        TaskAwaiter awaiter;
        if (num != 0)
        {
            if (num == 1)
            {
                awaiter = <>u__1;
                <>u__1 = default(TaskAwaiter);
                num = (<>1__state = -1);
                goto IL_00cc;
            }
            awaiter = Task.Delay(delay).GetAwaiter();
            if (!awaiter.IsCompleted)
            {
                num = (<>1__state = 0);
                <>u__1 = awaiter;
                <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                return;
            }
        }
        else
        {
            awaiter = <>u__1;
            <>u__1 = default(TaskAwaiter);
            num = (<>1__state = -1);
        }
        awaiter.GetResult();
        Console.WriteLine(delay);
        awaiter = Bar().GetAwaiter();
        if (!awaiter.IsCompleted)
        {
            num = (<>1__state = 1);
            <>u__1 = awaiter;
            <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
            return;
        }
        goto IL_00cc;
        IL_00cc:
        awaiter.GetResult();
    }
    catch (Exception exception)
    {
        <>1__state = -2;
        <>t__builder.SetException(exception);
        return;
    }
    <>1__state = -2;
    <>t__builder.SetResult();
}
```

That does look a bit scary to begin with. But, have no worries. We will break it down and understand it better.

**Exception Handling**

Now we already know that the associated `Task` object returned by the `async` method would contain any exception if any. It also sets the status to faulted. So how does the State Machine help in doing so ? That's the first part we will explore. Let us have birds-eye view of the `MoveNext()` method - for time being, we will ignore all code within the `try` block.

```csharp
private void MoveNext()
{
    int num = <>1__state;
    try
    {
        // Ignore this code for the moment
    }
    catch (Exception exception)
    {
        <>1__state = -2;
        <>t__builder.SetException(exception);
        return;
    }
    <>1__state = -2;
    <>t__builder.SetResult();
}
```

As you can observe the entire `MoveNext()` method has a big try catch wrapping the code within. The interesting part for the moment would be the `catch` block. If any exceptions occurs in the `try` block, the `MoveNext()` method sets the state to `-2` to indicate the method has completed (_-2 indicates completion, irrespective of success or failure_). It then uses the Builder to set the exception using the `Builder.SetException` method.

> Only special exceptions like the ThreadAbortException or the StackOverflowException can cause the `MoveNext()` method to end with an exception.

**High Level Flow of State Machine**

At a higher level, one can observe that the `MoveNext()` method returns if any of the following are true

- Each time the state machine needs to be pause (for an await statement to complete).
- Execution reaches the end of the method
- Exception is thrown, but not caught in the async method.

A High level flow of the State Machine could be summarized as follows.

1. The Stub Method (Worker Method) initiates the State Machine using the Builder Object (`AsyncTaskMethodBuilder`).
2. Jump to the correct place in State Machine based on the State Field.
3. Execute the State Machine until the code reaches await statement or end of the method (return statement).
4. Fetch the awaiter.
5. - If the awater is completed, go back to the Step 2.
   - If not, attach a continuation to the awaiter.
   - If this is the first awaiter, return the Task.
6. The Task returned in Step 5, would be returned the caller via the Builder.

**The Try Block**

The Try blocks starts with a `switch/if` condition depending on the number of await statements within the method. If it has 3 or more awaits, usually one could notice a `switch` case, in all other cases, an `if` statement is used.

Irrespective of the approach, the condition to check resolves around the State of the State Machine. If the state is negative, it indicates the first call to the `MoveNext()` method. If the value of State is a positive number, then it indicates the State Machine is resuming from a pause.

```csharp
public int <>1__state;
public AsyncTaskMethodBuilder <>t__builder;
public int delay;
private TaskAwaiter <>u__1;

private void MoveNext()
{
    int num = <>1__state;
    try
    {
        TaskAwaiter awaiter;
        if (num != 0)
        {
            if (num == 1)
            {
                awaiter = <>u__1;
                <>u__1 = default(TaskAwaiter);
                num = (<>1__state = -1);
                goto IL_00cc;
            }
            awaiter = Task.Delay(delay).GetAwaiter();
            if (!awaiter.IsCompleted)
            {
                num = (<>1__state = 0);
                <>u__1 = awaiter;
                <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                return;
            }
        }
        else
        {
            awaiter = <>u__1;
            <>u__1 = default(TaskAwaiter);
            num = (<>1__state = -1);
        }
        awaiter.GetResult();
        Console.WriteLine(delay);
        awaiter = Bar().GetAwaiter();
        if (!awaiter.IsCompleted)
        {
            num = (<>1__state = 1);
            <>u__1 = awaiter;
            <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
            return;
        }
        goto IL_00cc;
        IL_00cc:
        awaiter.GetResult();
    }
    catch (Exception exception)
    {
        // Not displayed for clarity
    }
    <>1__state = -2;
    <>t__builder.SetResult();
}
```

One of the first things you notice in the code above is that State is stored in a local variable. I guess this is done for optimization purposes. We could use a dedicated post later for understanding different optimizations techniques used by compiler here, for now let us stick to the task in hand.

As one can observe, when the Method is invoked for the first time, as the state would be -1, the code would proceed and hit the first await statement.

``` csharp
awaiter = Task.Delay(delay).GetAwaiter();
if (!awaiter.IsCompleted)
{
    num = (<>1__state = 0);
    <>u__1 = awaiter;
    <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
    return;
}
```

It fetches the Awaiter using the GetAwaiter method. If the awaiter is already completed, it would proceed to the next step in the original method. If not, it would set the State to 0 (indicating the first instance where the `MoveNext()` method had to await - zero based index), store the awaiter in the field and schedules the state machine to proceed to the next action when the specified awaiter completes using the `Builder.AwaitUnsafeOnCompleted` method.

On resumption after the pause, it moves to else part (remember, the state is having a value 0 now). It restores the awaiter stored in the field and clears the fields so that GC could take care of it. It also sets the State to -1.

``` csharp
else
{
    awaiter = <>u__1;
    <>u__1 = default(TaskAwaiter);
    num = (<>1__state = -1);
}
awaiter.GetResult();
Console.WriteLine(delay);
awaiter = Bar().GetAwaiter();
if (!awaiter.IsCompleted)
{
    num = (<>1__state = 1);
    <>u__1 = awaiter;
    <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
    return;
}
```

It then proceeds to fetch the Result using the `TaskAwaiter.GetResult()` method and then executes the remaining steps untill it hits the next await or the method completes. On completion (either finished or faulted), it sets the State to -2 and sets the Result using the Builder.

``` csharp
<>1__state = -2;
<>t__builder.SetResult();
```

Over the last few posts, we have traced through the generated source code behind the asynchronous methods. We noticed how the method gets translated to a pair of Stub/Working method and a State Machine. We also explored the State Machine in detail and understood how the MoveNext method method navigates the original method while maitaining the states.

The whole process, starting from the moment your code hits the `await` expression could be summarized as,
1. Get the awaiter from the awaitable expression using the `GetAwaiter()` method.
2. Check if the awaiter has been comepleted
    - If Yes, Go to Step 8. (Fast Path)
    - If No, remember where you have reached using the State Field. (Slow Path)
3. Store the awaiter in a field.
4. Schedule a continuation with the awaiter, such that when the continuation is executed, you are back at the right place.
5. Return from the MoveNext, either to the original caller if it is the first pause, or to whatever has scheduled the continuation.
6. When the continuation fires, set the State to -1 to indicate running.
7. Restore the Awaiter from the field and store it back in the Stack. Remember to reset the field so that GC could take care of it.
8. Fetch the result using `GetResult()` method.
9. Continue with rest of the code.


This, was a simple asynchornous method devoid of any controls methodologies like the loops. In the next part of this series, we will use the knowledge we have gained so far to understand more complex scenarios in depth. 

Once again, I would like to thank the wonderful Jon Skeets for his brillant book - C# in Depth. You ought to rename it to "C# Bible" Jon !!

