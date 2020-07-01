using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class ValuePattern : IEvaluate<Direction>
    {
        public string Evaluate(Direction criteria) => criteria switch
        {
            Direction.Up => $"Direction : {nameof(Direction.Up)}",
            Direction.Down => $"Direction : {nameof(Direction.Down)}",
            Direction.Left => $"Direction : {nameof(Direction.Left)}",
            Direction.Right => $"Direction : {nameof(Direction.Right)}",
        };
        
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
