using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoxesAndChickens
{
    class Bot
    {
        private struct Position
        {
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private Cell[] _fox;
        private Cell _currentFox;

        private Random _random;
        public Bot(Map map)
        {
            _map = map;
            _fox = new Cell[2];

            _random = new Random();

            int count = 0;

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    if (map[j, i]?.Visitor == CellVisitor.Fox) _fox[count++] = map[j, i];
                }
            }
        }

        private Map _map;

        private int Max(params int[] nums)
        {
            if (nums.Length == 0) return 0;
            int tmp = nums[0];
            foreach (int item in nums)
            {
                if (item > tmp) tmp = item;
            }

            return tmp;
        }

        private void MoveUp(int foxIndex)
        {
            if(CanEat(_fox[foxIndex], Direction.Up))
            {
                if (_map.MoveUp(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Top.Top;
            }
            else
            {
                if (_map.MoveUp(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Top;
            }
        }
        private void MoveDown(int foxIndex)
        {
            if (CanEat(_fox[foxIndex], Direction.Down))
            {
                if (_map.MoveDown(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Bottom.Bottom;
            }
            else
            {
                if (_map.MoveDown(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Bottom;
            }
        }

        private void MoveLeft(int foxIndex)
        {
            if (CanEat(_fox[foxIndex], Direction.Left))
            {
                if (_map.MoveLeft(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Left.Left;
            }
            else
            {
                if (_map.MoveLeft(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Left;
            }
        }

        private void MoveRight(int foxIndex)
        {
            if (CanEat(_fox[foxIndex], Direction.Right))
            {
                if (_map.MoveRight(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Right.Right;
            }
            else
            {
                if (_map.MoveRight(_fox[foxIndex]))
                    _fox[foxIndex] = _fox[foxIndex].Right;
            }
        }

        public void Step()
        {
            int up;
            int down;
            int left;
            int right;
            int max1, max2;

            int foxIndex;

            _currentFox = _fox[0];
            up = DirectionWeight(_fox[0], Direction.Up);
            down = DirectionWeight(_fox[0], Direction.Down);
            left = DirectionWeight(_fox[0], Direction.Left);
            right = DirectionWeight(_fox[0], Direction.Right);
            max1 = Max(up, down, left, right);

            _currentFox = _fox[1];
            up = DirectionWeight(_fox[1], Direction.Up);
            down = DirectionWeight(_fox[1], Direction.Down);
            left = DirectionWeight(_fox[1], Direction.Left);
            right = DirectionWeight(_fox[1], Direction.Right);
            max2 = Max(up, down, left, right);


            foxIndex = (max1 > max2) ? 0 : (max1 != max2)? 1: _random.Next(2);
            

            _currentFox = _fox[foxIndex];
            Move(foxIndex);
        }

        private void Move(int foxIndex)
        {
            int up;
            int down;
            int left;
            int right;

            int max;

            bool eat;

            do
            {
                up = DirectionWeight(_fox[foxIndex], Direction.Up);
                down = DirectionWeight(_fox[foxIndex], Direction.Down);
                left = DirectionWeight(_fox[foxIndex], Direction.Left);
                right = DirectionWeight(_fox[foxIndex], Direction.Right);
                max = Max(up, down, left, right);

                int maxCount = 0;

                maxCount += (max == up) ? 1 : 0;
                maxCount += (max == down) ? 1 : 0;
                maxCount += (max == left) ? 1 : 0;
                maxCount += (max == right) ? 1 : 0;

                if(maxCount > 1)
                {
                    Direction[] direction = new Direction[maxCount];
                    if(max == up)
                        direction[--maxCount] = Direction.Up;
                    if(max == down && maxCount > 0)
                        direction[--maxCount] = Direction.Down;
                    if(max == left && maxCount > 0)
                        direction[--maxCount] = Direction.Left;
                    if (max == right && maxCount > 0)
                        direction[--maxCount] = Direction.Right;

                    switch (direction[_random.Next(direction.Length)])
                    {
                        case Direction.Up:
                            max = int.MaxValue;
                            up = int.MaxValue;
                            break;
                        case Direction.Down:
                            max = int.MaxValue;
                            down = int.MaxValue;
                            break;
                        case Direction.Left:
                            max = int.MaxValue;
                            left = int.MaxValue;
                            break;
                        case Direction.Right:
                            max = int.MaxValue;
                            right = int.MaxValue;
                            break;
                        default:
                            break;
                    }
                }

                Thread.Sleep(1000);

                eat = CanEat(_fox[foxIndex]);

                if (up == max && !(eat ^ CanEat(_fox[foxIndex], Direction.Up)))
                {
                    MoveUp(foxIndex);
                }
                else if (down == max && !(eat ^ CanEat(_fox[foxIndex], Direction.Down)))
                {
                    MoveDown(foxIndex);
                }
                else if (left == max && !(eat ^ CanEat(_fox[foxIndex], Direction.Left)))
                {
                    MoveLeft(foxIndex);
                }
                else if (right == max && !(eat ^ CanEat(_fox[foxIndex], Direction.Right)))
                {
                    MoveRight(foxIndex);
                }
            } while (eat && CanEat(_fox[foxIndex]));
        }

        private Cell JumpCell(Cell cell, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (cell.Top == null) return null;
                    return cell.Top.Top;
                case Direction.Down:
                    if (cell.Top == null) return null;
                    return cell.Bottom.Bottom;
                case Direction.Left:
                    if (cell.Top == null) return null;
                    return cell.Left.Left;
                case Direction.Right:
                    if (cell.Right == null) return null;
                    return cell.Right.Right;
                default:
                    return null;
            }
        }


        private int DirectionWeight(Cell cell, Direction direction)
        {
            if (cell == null) return 0;

            int weight = 0;
            if (CanEat(cell, direction))
            {
                weight++;
                int up, down, left, right;
                switch (direction)
                {
                    case Direction.Up:
                        up = DirectionWeight(JumpCell(cell, direction), Direction.Up);
                        left = DirectionWeight(JumpCell(cell, direction), Direction.Left);
                        right = DirectionWeight(JumpCell(cell, direction), Direction.Right);
                        weight += Max(left, right, up);
                        break;
                    case Direction.Down:
                        down = DirectionWeight(JumpCell(cell, direction), Direction.Down);
                        left = DirectionWeight(JumpCell(cell, direction), Direction.Left);
                        right = DirectionWeight(JumpCell(cell, direction), Direction.Right);
                        weight += Max(left, right, down);
                        break;
                    case Direction.Left:
                        down = DirectionWeight(JumpCell(cell, direction), Direction.Down);
                        left = DirectionWeight(JumpCell(cell, direction), Direction.Left);
                        up = DirectionWeight(JumpCell(cell, direction), Direction.Up);
                        weight +=Max(left, down, up);
                        break;
                    case Direction.Right:
                        down = DirectionWeight(JumpCell(cell, direction), Direction.Down);
                        right = DirectionWeight(JumpCell(cell, direction), Direction.Right);
                        up = DirectionWeight(JumpCell(cell, direction), Direction.Up);
                        weight += Max(right, down, up);
                        break;
                    default:
                        break;
                }
                return weight;
            }

            switch (direction)
            {
                case Direction.Up:
                    if (cell.Top == _currentFox) return 0;
                    if (cell.Top == null) return -1;
                    if (cell.Top.Visitor != CellVisitor.None) return -1;
                    break;
                case Direction.Down:
                    if (cell.Bottom == _currentFox) return 0;
                    if (cell.Bottom == null) return -1;
                    if (cell.Bottom.Visitor != CellVisitor.None) return -1;
                    break;
                case Direction.Left:
                    if (cell.Left == _currentFox) return 0;
                    if (cell.Left == null) return -1;
                    if (cell.Left.Visitor != CellVisitor.None) return -1;
                    break;
                case Direction.Right:
                    if (cell.Right == _currentFox) return 0;
                    if (cell.Right == null) return -1;
                    if (cell.Right.Visitor != CellVisitor.None) return -1;
                    break;
                default:
                    break;
            }

            return 0;
        }



        private bool CanEat(Cell cell, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:

                    if (cell.Top == null) return false;
                    if (cell.Top.Visitor != CellVisitor.Chicken) return false;
                    if (cell.Top.Top == null) return false;
                    if (cell.Top.Top == _currentFox) return true;
                    if (cell.Top.Top.Visitor != CellVisitor.None) return false;
                    return true;
                case Direction.Down:
                    if (cell.Bottom == null) return false;
                    if (cell.Bottom.Visitor != CellVisitor.Chicken) return false;
                    if (cell.Bottom.Bottom == null) return false;
                    if (cell.Bottom.Bottom == _currentFox) return true;
                    if (cell.Bottom.Bottom.Visitor != CellVisitor.None) return false;
                    return true;
                case Direction.Left:
                    if (cell.Left == null) return false;
                    if (cell.Left.Visitor != CellVisitor.Chicken) return false;
                    if (cell.Left.Left == null) return false;
                    if (cell.Left.Left == _currentFox) return true;
                    if (cell.Left.Left.Visitor != CellVisitor.None) return false;
                    return true;
                case Direction.Right:
                    if (cell.Right == null) return false;
                    if (cell.Right.Visitor != CellVisitor.Chicken) return false;
                    if (cell.Right.Right == null) return false;
                    if (cell.Right.Right == _currentFox) return true;
                    if (cell.Right.Right.Visitor != CellVisitor.None) return false;
                    return true;
                default:
                    return false;
            }
        }

        private bool CanEat(Cell cell)
        {
            if (CanEat(cell, Direction.Up)) return true;
            if (CanEat(cell, Direction.Down)) return true;
            if (CanEat(cell, Direction.Left)) return true;
            if (CanEat(cell, Direction.Right)) return true;
            return false;
        }
    }
}
