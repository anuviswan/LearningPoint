namespace Loupedeck.Demo01Plugin.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static VirtualKeyCode;

    public class ToggleMuteCommand: PluginDynamicCommand
    {
        public ToggleMuteCommand() : base("Toggle Mute","Toggles mute state", "Audio")
        {
                
        }

        protected override void RunCommand(String actionParameter) => this.Plugin.ClientApplication.SendKeyboardShortcut(VolumeMute);
    }
}
