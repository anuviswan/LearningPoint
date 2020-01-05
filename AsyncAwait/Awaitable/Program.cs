using Awaitable.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Awaitable
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"Started Method {nameof(Main)}");
        //    InvokeAsyncCall();
        //    Console.WriteLine($"Continuing Method {nameof(Main)}");
        //    Console.ReadLine();
        //}

        //static async Task InvokeAsyncCall()
        //{
        //    Console.WriteLine($"Starting Method {nameof(InvokeAsyncCall)}");
        //    var result = await "dir";
        //    Console.WriteLine($"Continuing Method {nameof(InvokeAsyncCall)}");
        //    Console.WriteLine(result);
        //    Console.WriteLine($"Ending Method {nameof(InvokeAsyncCall)}");
        //}
    }
}
