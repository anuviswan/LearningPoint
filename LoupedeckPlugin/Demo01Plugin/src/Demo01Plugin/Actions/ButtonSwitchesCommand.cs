namespace Loupedeck.Demo01Plugin.Actions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ButtonSwitchesCommand: PluginDynamicCommand
    {
        private readonly Boolean[] _switches = new Boolean[12];
        public ButtonSwitchesCommand() : base()
        {
            for(var i = 0; i < 12; i++)
            {
                // parameter is the switch index
                var actionParameter = i.ToString();

                // add parameter
                this.AddParameter(actionParameter, $"Switch {i}", "Switches");
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            if (Int32.TryParse(actionParameter, out var i))
            {
                // turn the switch
                this._switches[i] = !this._switches[i];

                // inform Loupedeck that command display name and/or image has changed
                this.ActionImageChanged(actionParameter);
            }
        }

        protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize)
        {
            if (Int32.TryParse(actionParameter, out var i))
            {
                return $"Switch {i}: {this._switches[i]}";
            }
            else
            {
                return null;
            }
        }
    }
}
