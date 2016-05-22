using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Manager;
using LetsCreateWarcraft2.Map;
using Microsoft.Xna.Framework;
using OpenTK.Graphics.OpenGL;

namespace LetsCreateWarcraft2.Common
{
    class Pathfinding
    {
        private List<Vector2> _path;
        private List<PathNode> _openList;
        private List<PathNode> _closedList;
        private ManagerTiles _managerTiles;
        private ManagerUnits _managerUnits; 
        private int _xTilePos;
        private int _yTilePos;
        private int _goalX;
        private int _goalY;
        private int _deep;
        private Sprite _sprite;
        private bool _checkForUnit;
        private string _id; 

        public Pathfinding(string id, Sprite sprite, ManagerTiles managerTiles, ManagerUnits managerUnits)
        {
            _id = id; 
            _sprite = sprite;
            _managerTiles = managerTiles; 
            _path = new List<Vector2>();
            _managerUnits = managerUnits;
            _checkForUnit = true; 
        }

        public List<Vector2> FindPath(int xTilePos, int yTilePos)
        {
            _path = new List<Vector2>();

            _xTilePos = _sprite.XTilePos;
            _yTilePos = _sprite.YTilePos;

            _goalX = xTilePos;
            _goalY = yTilePos;

            if (_goalX == _xTilePos && _goalY == _yTilePos)
                return new List<Vector2>();

            _openList = new List<PathNode>();
            _closedList = new List<PathNode>();

            if (CheckCollision(_goalX, _goalY))
            {
                var newGoal = PickNextBest();
                if(newGoal == null)
                    return new List<Vector2>();
                _goalX = newGoal.XTilePos;
                _goalY = newGoal.YTilePos;
                _openList.Clear();
                _openList.Clear();
            }

            _openList.Add(new PathNode(_xTilePos,_yTilePos,null,_goalX,_goalY));
            _deep = 0;
            CheckNodesClose(_openList[0],_goalX,_goalY);

            var node = _closedList[_closedList.Count - 1];
            while (node.Parent != null)
            {
                _path.Add(new Vector2(node.XTilePos,node.YTilePos));
                node = node.Parent; 
            }

            _path.Reverse(); 

            return _path;
        }


        private void CheckNodesClose(PathNode node, int goalX, int goalY)
        {
            _deep++;

            if (_deep > 2500)
                return; 

            _openList.Remove(node);
            _closedList.Add(node);

            if (node.XTilePos == goalX && node.YTilePos == goalY)
                return;


            CheckNode(node.XTilePos, node.YTilePos - 1,node,goalX,goalY);
            CheckNode(node.XTilePos, node.YTilePos + 1, node,goalX,goalY);
            CheckNode(node.XTilePos + 1, node.YTilePos, node,goalX,goalY);
            CheckNode(node.XTilePos - 1, node.YTilePos, node,goalX,goalY);

            //_openList = _openList.OrderBy(n => n.F).ToList(); 

            _openList.Sort(new PathNodeComparer());

            if(_openList.Count > 0)
                CheckNodesClose(_openList[0],goalX,goalY);

        }

        private void CheckNode(int xTilePos, int yTilePos, PathNode node, int goalX, int goalY)
        {
            if (!CheckCollision(xTilePos, yTilePos) &&
              !ClosedNode(xTilePos, yTilePos))
            {
                var oldNode = _openList.FirstOrDefault(n => n.XTilePos == xTilePos && n.YTilePos == yTilePos);
                if (oldNode == null)
                {
                    _openList.Add(new PathNode(xTilePos, yTilePos, node, goalX, goalY));
                }
                else
                {
                    if (node.H + 10 < oldNode.H)
                    {
                        oldNode.Parent = node;
                        oldNode.H = node.H + 10; 
                    }
                } 
            }
        }

        private bool ClosedNode(int xTilePos, int yTilePos)
        {
            return _closedList.Any(p => p.XTilePos == xTilePos && p.YTilePos == yTilePos); 
        }

        public bool CheckCollision(int x, int y)
        {
            return _managerTiles.CheckCollision(x, y) || (_checkForUnit && _managerUnits.CheckCollision(x, y,_id)) || x < 0 || y < 0;
        }

        private PathNode PickNextBest()
        {
            _checkForUnit = false; 
            var node = new PathNode(_goalX,_goalY, null, _xTilePos, _yTilePos);
            CheckNodesClose(node,_xTilePos,_yTilePos);
            //_openList.Reverse();
            _checkForUnit = true;
            if (_openList.Count == 0)
                return null; 
            return _openList[0];
        }


    }
}
