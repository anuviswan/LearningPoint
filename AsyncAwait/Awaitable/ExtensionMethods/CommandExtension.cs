using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Awaitable.ExtensionMethods
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
            if (process.HasExited) tcs.TrySetResult(process.StandardOutput.ReadToEnd());
            return tcs.Task.GetAwaiter();
        }
    }
}
