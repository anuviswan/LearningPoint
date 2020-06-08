Okay, I wasn't quite realistic in the earlier post when I mentioned we would look at MoveNext in this one. I missed an important clog of the wheel. The `SetStateMachine()` method.

**IAsyncStateMachine.SetStateMachine**

We will only breifly visit the `SetStateMachine` method here, as the complete picture becomes more clear when we look to details of the `MoveNext()` method.

So how does the `SetStateMachine` method looks like in the generated code. Interestingly, it has two different implementation depending on whether you are in Release or Debug mode.

```csharp
// Release Mode
[DebuggerHidden]
private void SetStateMachine(IAsyncStateMachine stateMachine)
{
    <>t__builder.SetStateMachine(stateMachine);
}

void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
{
    this.SetStateMachine(stateMachine);
}


// Debug Mode
[DebuggerHidden]
private void SetStateMachine(IAsyncStateMachine stateMachine)
{
}

void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
{
    this.SetStateMachine(stateMachine);
}
```

As one can observe, in the Debug Mode, the method is empty. Hence the following explanation is more relavant for the Release mode.

Let's go back a bit and think about our little Stub method.

```csharp
private static Task Bar()
{
	<Bar>d__2 stateMachine = new <Bar>d__2();
	stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
	stateMachine.<>1__state = -1;
	stateMachine.<>t__builder.Start(ref stateMachine);
	return stateMachine.<>t__builder.Task;
}
```

When the State Machine is started by the Stub Method, it is residing on the Stack as a local variable of the Stub Method.

This is where the whole crazy stuff starts. When the State Machine pauses and resumes again, it needs a lot of information. For this to happen, when it pauses, the state machine has to box itself and store in heap, so that when it resumes, it has all the necessary informations. After it is boxed, the state machine is called on the box value using box value as arguement.

Do note that the boxing happens only once. The State machine also ensures that the builder has a reference to the single boxed version of the state machine.

This can be noticed if you dig a deep into the code of `AsyncMethodBuilderCore.SetStateMachine`

```csharp
public void SetStateMachine(IAsyncStateMachine stateMachine)
{
	if (stateMachine == null)
	{
		throw new ArgumentNullException("stateMachine");
	}
	if (m_stateMachine != null)
	{
		throw new InvalidOperationException(Environment.GetResourceString("AsyncMethodBuilder_InstanceNotInitialized"));
	}
	m_stateMachine = stateMachine;
}
```

We will leave the SetStateMachine here because that's all it does. Its role would be more visible once we examine the `MoveNext` method in detail.
