namespace Loupedeck.Demo2Plugin.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OpenNotepadCommand : PluginDynamicCommand
    {
        private int counter = 0;
        public OpenNotepadCommand() : base("NotePad","Notepad invocation","Demo Notepad")
        {
                
        }

        protected override void RunCommand(string actionParameter)
        {
            this.counter++;
            Process.Start(@"C:\Windows\system32\notepad.exe");
            this.ActionImageChanged();
        }

        protected override String GetCommandDisplayName(string actionParameter, PluginImageSize imageSize)
        {
            return $"Notepad Invoked {this.counter}";
        }
    }
}
