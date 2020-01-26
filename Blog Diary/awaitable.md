How do you determine what types could be awaited ? That is one question that often comes to mind and the most common answer would be 
* `Task`
* `Task<TResult>`

However, are we truely restricted to them ? What are the other Types that could be awaited ? The anwer lies in the `awaitable pattern`.  

### Awaitable Pattern

The awaitable pattern requires to have a parameterless instance or static non-void method `GetAwaiter` that returns an Awaitable Type.
```csharp
public T GetAwaiter()
```
Where T, the awaiter Type implements
* `INotifyCompletion` or `ICriticallyNotifyCompletion`
* Has a boolean instance property `IsCompleted`
* Non-generic parameterless instance method `GetResult`

### Approach 01 - Use TaskAwaiter

Let's begin by an example that reusing `Task` or `Task<TResult>`  awaiter instead of creating our own awaiter. For demonstration purpose, we assume a requirement where in we should be able to use the Process Class to execute given command asynchronously and return the result. Ideally, we should be able to do the following.

```csharp
var result = await "dir"
```

The above command should be able to execute "dir" command using Process and return the result. We will begin by writing the GetAwaiter extension method for string.

``` csharp
public static class CommandExtension
    {
        public static TaskAwaiter<string> GetAwaiter(this string command)
        {
            var tcs = new TaskCompletionSource<string>();
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(process.StandardOutput.ReadToEnd());
            process.Start();
            return tcs.Task.GetAwaiter();
        }
    }
```

The above code reuses the Awaiter for `Task<TResult>`. The method initiates the Process and use TaskCompletionSource to set the result in the Exited event of Process. If you examine the source code of [TaskAwaiter](https://referencesource.microsoft.com/#mscorlib/system/runtime/compilerservices/TaskAwaiter.cs) , you can observe that it implements the ICriticallyNotifyCompletion interface and has the IsCompleted Property as well as GetResult method.

Let us now write some demonstrative code and examine the output.

```csharp
private async void btnDemoUsingTaskAwaiter_Click(object sender, EventArgs e)
{
	AppendToLog($"Started Method {nameof(btnDemoUsingTaskAwaiter_Click)}");
	await InvokeAsyncCall();
	AppendToLog($"Continuing Method {nameof(btnDemoUsingTaskAwaiter_Click)}");
}
private async Task InvokeAsyncCall()
{
	AppendToLog($"Starting Method {nameof(InvokeAsyncCall)}");
	var result = await "dir";
	AppendToLog($"Recieved Result, Continuing Method {nameof(InvokeAsyncCall)}");
	AppendToLog(result);
	AppendToLog($"Ending Method {nameof(InvokeAsyncCall)}");
}
public void AppendToLog(string message)
{
	logText.Text += $"{Environment.NewLine}{message}";
}
```

Output
```
Started Method btnDemoUsingTaskAwaiter_Click
Starting Method InvokeAsyncCall
Recieved Result, Continuing Method InvokeAsyncCall
<Output from command>
Ending Method InvokeAsyncCall
Continuing Method btnDemoUsingTaskAwaiter_Click

```

### Approach 02 - Implement Custom Awaiter

Let us now assume another situation where-in, the 


