using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsCreateWarcraft2.Map
{
    class TileCollision : Tile
    {
        public bool Collision { get; private set; }

        public TileCollision(int xTilePos, int yTilePos, bool collision)
        {
            XTilePos = xTilePos;
            YTilePos = yTilePos;
            _width = 32;
            _height = 32;
            Collision = true; 
        }
    }
}
