using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LetsCreateWarcraft2.Map
{
    class Tile
    {
        public int XTilePos { get; protected set; }
        public int YTilePos { get; protected set; }

        public Vector2 Position { get { return new Vector2(XTilePos * _width, YTilePos * _height); } }

        protected int _width;
        protected int _height;
    }
}
