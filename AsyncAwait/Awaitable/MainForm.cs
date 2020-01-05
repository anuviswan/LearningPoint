using Awaitable.ExtensionMethods.TaskAwaiter;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Awaitable
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDemoUsingTaskAwaiter_Click(object sender, EventArgs e)
        {
            AppendToLog($"Started Method {nameof(btnDemoUsingTaskAwaiter_Click)}");
            Task.Run(()=> InvokeAsyncCall());
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
            try
            {
                logText.Text += $"{Environment.NewLine}{message}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
           

        }
    }
}
