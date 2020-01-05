using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Awaitable.ExtensionMethods.TaskAwaiter
{
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
}
