# Asynchronous Code - Behind the Scenes - 001

If you were to ask me what was the biggest milestone in .Net development, then my choice would definetly be .Net 5.0 - especially the introduction of the `async/await`. The more you learn about the underlying working, you cannot but stop and admire the efforts done by the lang uage developers to make our life easier.

In this mini series on asynchronous programming in .Net, we will delve deeper into the fascinating world of `async await` and learn more about what happens behind the scenes. I thought i would structure it as a mini-series rather than a single monolythic post as this is a vast topic (at least for an average developer like me).

**Setting the Stage**

Let us begin by writing a simple async method, which we would then decompile using ILSpy to know what happens beneath. We will keep the base code as simple as possible.

```csharp
class Program
{
    static void Main(string[] args)
    {
        Foo(10);
    }

    static async Task Foo(int delay)
    {
        await Task.Delay(delay);
        Console.WriteLine(delay);
        await Bar();
    }

    static async Task Bar()
    {
        await Task.Delay(100);
    }
}
```

For the demonstration purpose, we will use ILSpy for decompiling our code, but please feel free to choose any decompiler you are comfortable with. In case you are using ILSpy, please ensure you have the following settings `unchecked`.

```
View->Options->Decompiler->C# 5.0-> Decompile async methods
```

This would ensure we could view the decompiled async code and the associated state machine. Okay, now let us see what ILSpy has to offer us after decompiling our code. We will read the code in parts, so that it is easier for us to understand the whole structure.

1. Stub Method
2. State Machine structure
3. MoveNext Method method

**Stub Method**

As you would be already aware, the async methods are implemented with the help of _State Machines_ internally.

Stubs are methods which has the same signature as your original async method and is responsible for creating the state machine. Let us check the decompiled stub method.

```csharp
[AsyncStateMachine(typeof(<Foo>d__1))]
[DebuggerStepThrough]
private static Task Foo(int delay)
{
	<Foo>d__1 stateMachine = new <Foo>d__1();
	stateMachine.delay = delay;
	stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
	stateMachine.<>1__state = -1;
	stateMachine.<>t__builder.Start(ref stateMachine);
	return stateMachine.<>t__builder.Task;
}

[AsyncStateMachine(typeof(<Bar>d__2))]
[DebuggerStepThrough]
private static Task Bar()
{
	<Bar>d__2 stateMachine = new <Bar>d__2();
	stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
	stateMachine.<>1__state = -1;
	stateMachine.<>t__builder.Start(ref stateMachine);
	return stateMachine.<>t__builder.Task;
}
```

Let us skip the attributes for a moment (we will come back to very shortly), and first concentrate on signature of both Stub methods. As mentioned earlier, both shares the same signature with their original async methods.

The Stub Method is responbile for creating/initializing the State Machine and Starting it. The state machines are initialized with following

- Parameters as Fields
  Any parameter in the original async method are added as Fields in the State Machine. For example, if you inspect the following code from `Foo` Stub Method.

```csharp
stateMachine.delay = delay;
```

The `Foo` method, if you remember, accepted a single parameter of Type int and was called delay. This parameter would be now added a field in the State Machine.

- Type of Builder

The type of Builder varies depending on the return type of the Method in question.

| Return Type      | Builder                                                |
| ---------------- | ------------------------------------------------------ |
| Task             | AsyncTaskMethodBuilder                                 |
| Task<TResult>    | AsyncTaskMethodBuilder<TResult>                        |
| void             | AsyncVoidMethodBuilder                                 |
| Custom Task Type | Builder specified by `AsyncTaskMethodBuilderAttribute` |

In the above scenario, both methods returns Task. For the same reason, the both uses an `AsyncTaskMethodBuilder`. Please note that the Custom Task Type was introduced only with C# 7. Prior to C# 7, only the first 3 builders were applicable.

The attribute `AsyncStateMachine` points to the method's particular state machine and aids in tooling.

- State of the State Machine

A async method could be in either the following states - Not Started - Executing - Paused - Completed (Successfully or Faulted)

Out of these, the most important state for the State Machine is the Paused State. While in the Executing State, the async method is pretty much like synchronous code as it passes through each instruction. The CPU would keep track of the currently executing step via Instruction Pointer.

However, the state machine comes into picture immediately as the method _pauses_ when it reaches an await (incomplete) expression. Please note that this is applicable only for async expression that has not been completed. In case the awaited expression is completed, the code works similiar to synchronous code and the state machine would not be brought into picture.

Each time the state has to be paused, the state is recorded so that once the operation awaited is completed, the method could be continued.

As one can expected, the Stub method would like to set the initial state of the state machine to `Not Started`.

The State Property of the state machine handles the current state with following value codes - -1 : Not Started - -2 : Completed (Sucessfully/Faulted) - Any other value : Paused

As one can observe, these are the values which the Stub method initializes the State Machine with.

```csharp
<Foo>d__1 stateMachine = new <Foo>d__1();
stateMachine.delay = delay;
stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
stateMachine.<>1__state = -1;
stateMachine.<>t__builder.Start(ref stateMachine);
```

Additional, it also starts the State Machine using the Builder.Start method, passing a reference to the State Machine created. The important point to note here is that the `stateMachine` is passed as reference to the method. This is because both StateMachine and AsyncTaskBuilder are mutable value types, and passing the instance by reference ensures no local copy are created. One can notice a lot of optimization done by the compiler.

The final step of the Stub method is of course, to return the Task object. The Task object is created by the Builder, who also ensures the Task's state is changed accordingly as the method execution progresses.

When the Builder.Start method is invoked, it begins executing the MoveNext method (we will discuss it later) untill the method reaches an incomplete await expression. At this point, the MoveNext would return the Task, following up which, the Start method also returns. The task is then returned to the Caller method.

That's it for the Stub Method, in the next section, we will look into the State Machine structure.

PS: One cannot thank John Skeet enough for his wonderful book , C# in Depth. It should be probably called "_ C# Bible_" instead.
