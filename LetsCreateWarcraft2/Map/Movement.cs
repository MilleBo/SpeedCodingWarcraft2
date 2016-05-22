using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Common;
using LetsCreateWarcraft2.Manager;
using Microsoft.Xna.Framework;

namespace LetsCreateWarcraft2.Map
{
    class Movement
    {
        private Pathfinding _pathfinding; 
        private Sprite _sprite;
        private bool _transitionOn;
        private List<Vector2> _path;  
        private int _speed;

        private int _goalX;
        private int _goalY; 

        public Movement(string id, Sprite sprite, ManagerTiles managerTiles, ManagerUnits managerUnit)
        {
            _sprite = sprite;
            _speed = 2; 
            _pathfinding = new Pathfinding(id,sprite,managerTiles, managerUnit);
        }

        public void Move(int xTile, int yTile)
        {
            if (_sprite.XTilePos == xTile && _sprite.YTilePos == yTile)
                return;
            _path =_pathfinding.FindPath(xTile, yTile);
            _goalX = (int)_path.Last().X;
            _goalY = (int)_path.Last().Y;
            _transitionOn = true; 
        }

        public void Update()
        {
            if (!_transitionOn)
                return;

            UpdateTransition(); 
        }

        private void UpdateTransition()
        {
            if (_sprite.TransitionOn)
                return;

            if (_path.Count > 0)
            {
                var wantedXTile = (int) _path[0].X;
                var wantedYTile = (int) _path[0].Y;


                if (_sprite.XTilePos < wantedXTile)
                {
                    _sprite.Move(1, 0, _speed);
                }
                else if (_sprite.XTilePos > wantedXTile)
                {
                    _sprite.Move(-1, 0, _speed);
                }
                else if (_sprite.YTilePos < wantedYTile)
                {
                    _sprite.Move(0, 1, _speed);
                }
                else if (_sprite.YTilePos > wantedYTile)
                {
                    _sprite.Move(0, -1, _speed);
                }

                _path.RemoveAt(0);
                if (_path.Count > 0)
                    _path = _pathfinding.FindPath(_goalX, _goalY);
            }
            else
            {
                _transitionOn = false; 
            }
        }


    }
}
