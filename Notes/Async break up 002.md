In the earlier part of this series, we reviewed the generic structure of decompiled async code, especially the stub method. In this part, we would continue our explore of async code and look into the State Machine. We would not delve deep into the most important `MoveNext()` method yet, we will first familiar with the different parts of the State Machine first.

- State Machine

Let us go back to the ILSpy and see how State Machine looks like.

```csharp
[StructLayout(LayoutKind.Auto)]
[CompilerGenerated]
private struct <Foo>d__1 : IAsyncStateMachine
{
	public int <>1__state;

	public AsyncTaskMethodBuilder <>t__builder;

	public int delay;

	private TaskAwaiter <>u__1;

	private void MoveNext()
	{
		// To be discussed later
	}

	void IAsyncStateMachine.MoveNext()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
		this.MoveNext();
	}

	[DebuggerHidden]
	private void SetStateMachine(IAsyncStateMachine stateMachine)
	{
		<>t__builder.SetStateMachine(stateMachine);
	}

	void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
		this.SetStateMachine(stateMachine);
	}
}
```

- **IAsyncStateMachine Interface**

One of the first things we would notice is the implementation of `IAsyncStateMachine` interface. The `IAsyncStateMachine` interface, which is defined under the `System.Runtime.CompilerServices` namespace, represents the state machine generated for the async method. The interface itself is a simple one, with just two methods in it.

```csharp
public interface IAsyncStateMachine
{
    /// <summary>Moves the state machine to its next state.</summary>
    void MoveNext();
    /// <summary>Configures the state machine with a heap-allocated replica.</summary>
    /// <param name="stateMachine">The heap-allocated replica.</param>
    void SetStateMachine(IAsyncStateMachine stateMachine);
}
```

The `MoveNext()` as explained earlier, represents the heart of asynchronous code. We would, for time being, delay visiting the method for a bit longer. However, the key point to remember at this point of time is that each time the State Machine is starts or resumes (after a pause), the `MoveNext()` method would be called. The `SetStateMachine()` method associates the builder with the specific state machine.

The importance of the implementation of the interface and how it binds the state machine with the stub method could be understood by looking at the signature of the `AsyncTaskMethodBuilder.Start()`. The method accepts a single generic parameter, which has a constraint of having implemented the `IAsyncStateMachine`.

```csharp
public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
{
	if (stateMachine == null)
	{
		throw new ArgumentNullException("stateMachine");
	}
	ExecutionContextSwitcher ecsw = default(ExecutionContextSwitcher);
	RuntimeHelpers.PrepareConstrainedRegions();
	try
	{
		ExecutionContext.EstablishCopyOnWriteScope(ref ecsw);
		stateMachine.MoveNext();
	}
	finally
	{
		ecsw.Undo();
	}
}
```

We would not go too deep into `AsyncTaskMethodBuilder.Start()`, but key take away would be

- The constraint applied to parameter `where TStateMachine : IAsyncStateMachine`
- The method is responsible for calling `IAsyncStateMachine.MoveNext()`

There is another interesting fact to this look at this point. The generated State Machine has a small but significant difference depending on whether your are looking at debug/release mode code. When in release mode, the compiler optimizes the code and creates a stuct based State Machine, while in debug mode, it creates a class. This is supposed to an optimization done to so that the compiler would skip allocating memory when the awaitable has already been completed awaited. The following code displays the State Machine when decompiled in debug mode.

```csharp
[CompilerGenerated]
private sealed class <Foo>d__1 : IAsyncStateMachine
{
	public int <>1__state;

	public AsyncTaskMethodBuilder <>t__builder;

	public int delay;

	private TaskAwaiter <>u__1;

	private void MoveNext()
	{
		// To be discussed later
	}

	void IAsyncStateMachine.MoveNext()
	{
		//ILSpy generated this explicit interface implementation from .override directive in MoveNext
		this.MoveNext();
	}

	[DebuggerHidden]
	private void SetStateMachine(IAsyncStateMachine stateMachine)
	{
	}

	void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
		this.SetStateMachine(stateMachine);
	}
}

```

- **Fields**
