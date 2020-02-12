using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Awaitable.ExtensionMethods.TaskAWaiter
{
    public static class CommandExtension
    {
        public static TaskAwaiter<string> GetAwaiter(this string command)
        {
            var tcs = new TaskCompletionSource<string>();
            Task.Run(() =>
            {
                var process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {command}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.EnableRaisingEvents = true;
                process.Exited += (s, e) => tcs.TrySetResult(process.StandardOutput.ReadToEnd());

                process.Start();
            });
            return tcs.Task.GetAwaiter();
        }
    }
}

namespace Awaitable.ExtensionMethods.CustomAwaiter
{
    public static class CommandExtension
    {
        public static UIThreadAwaiter GetAwaiter(this string command)
        {
            var tcs = new TaskCompletionSource<string>();
            Task.Run(() =>
            {
                var process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C {command}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.EnableRaisingEvents = true;
                process.Exited += (s, e) => tcs.TrySetResult(process.StandardOutput.ReadToEnd());

                process.Start();
            });

            return new UIThreadAwaiter(tcs.Task.GetAwaiter().GetResult());
        }


    }
    public class UIThreadAwaiter : INotifyCompletion
    {
        bool isCompleted = false;
        string resultFromProcess;

        public UIThreadAwaiter(string result)
        {
            resultFromProcess = result;
        }
        public bool IsCompleted => isCompleted;
        public void OnCompleted(Action continuation)
        {
            if (Application.OpenForms[0].InvokeRequired)
                Application.OpenForms[0].BeginInvoke((Delegate)continuation);
       
        }

        public string GetResult()
        {
            return resultFromProcess;
        }

       
    }
}
