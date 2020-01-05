using Awaitable.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void btnExecuteOnDifferentThread_Click(object sender, EventArgs e)
        {
            AppendToLog($"Started Method {nameof(btnExecuteOnDifferentThread_Click)}");
            Task.Run(() => InvokeAsyncCall());
            AppendToLog($"Continuing Method {nameof(btnExecuteOnDifferentThread_Click)}");
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
                txtLog.Text += $"{Environment.NewLine}{message}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private async void btnExecuteOnSameThread_Click(object sender, EventArgs e)
        {
            AppendToLog($"Started Method {nameof(btnExecuteOnDifferentThread_Click)}");
            await InvokeAsyncCall();
            AppendToLog($"Continuing Method {nameof(btnExecuteOnDifferentThread_Click)}");
        }
    }
}
