using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class ValuePattern : ISwitchExpression<Direction>, ISwitchStatement<Direction>
    {
        public string EvaluateSwitchExpression(Direction criteria) => criteria switch
        {
            Direction.Up => $"Direction : {nameof(Direction.Up)}",
            Direction.Down => $"Direction : {nameof(Direction.Down)}",
            Direction.Left => $"Direction : {nameof(Direction.Left)}",
            Direction.Right => $"Direction : {nameof(Direction.Right)}",
            _ => throw new NotImplementedException(),
        };

        public string EvaluateSwitchStatement(Direction criteria)
        {
            switch (criteria)
            {
                case Direction.Up: return $"Direction : {nameof(Direction.Up)}";
                case Direction.Down: return $"Direction : {nameof(Direction.Down)}";
                case Direction.Left: return $"Direction : {nameof(Direction.Left)}";
                case Direction.Right: return $"Direction : {nameof(Direction.Right)}";
                default: return "Unknown";
            };
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
