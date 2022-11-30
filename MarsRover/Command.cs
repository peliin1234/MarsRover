using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Command
    {
        Point position;
        Directions direction;
        Point boardSize;
        public Command(int x, int y, Directions direction, int maxBoardX, int maxBoardY)
        {
            maxBoardX = maxBoardX > 0 ? maxBoardX : 1;
            maxBoardY = maxBoardY > 0 ? maxBoardY : 1;
            x = (x < 0 || x > maxBoardX) ? 0 : x;
            y = (y < 0 || y > maxBoardY) ? 0 : y;

            boardSize = new Point(maxBoardX, maxBoardY);
            position = new Point(x, y);
            this.direction = direction;
        }
        private void RotateLeft()
        {
            switch (this.direction)
            {
                case Directions.N:
                    this.direction = Directions.W;
                    break;
                case Directions.S:
                    this.direction = Directions.E;
                    break;
                case Directions.E:
                    this.direction = Directions.N;
                    break;
                case Directions.W:
                    this.direction = Directions.S;
                    break;
            }
        }
        private void RotateRight()
        {
            switch (this.direction)
            {
                case Directions.N:
                    this.direction = Directions.E;
                    break;
                case Directions.S:
                    this.direction = Directions.W;
                    break;
                case Directions.E:
                    this.direction = Directions.S;
                    break;
                case Directions.W:
                    this.direction = Directions.N;
                    break;
            }
        }
        private bool Move()
        {
            switch (this.direction)
            {
                case Directions.N:
                    this.position.Y += 1;
                    break;
                case Directions.S:
                    this.position.Y -= 1;
                    break;
                case Directions.E:
                    this.position.X += 1;
                    break;
                case Directions.W:
                    this.position.X -= 1;
                    break;
            }

            if (position.X > boardSize.X || position.Y > boardSize.Y || position.X < 0 || position.Y < 0)
            {
                return false;
            }
            return true;
        }
        public string ApplyCommands(string commands)
        {
            int commandCount = 0;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'M':
                        if (!Move())
                            return $"The rover couldnt execute the move command with index : {commandCount} (Rovers new position is : {position.X} {position.Y} but the board is : {boardSize.X} X {boardSize.Y})";
                        break;
                    default:
                        return $"The rover doesn't know the command with index {commandCount} Which is : {command}";
                }
                commandCount++;
            }
            return $"{position.X} {position.Y} {direction}";
        }
    }
}
