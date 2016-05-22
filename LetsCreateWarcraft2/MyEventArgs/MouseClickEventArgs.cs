using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LetsCreateWarcraft2.MyEventArgs
{
    class MouseClickEventArgs : EventArgs
    {
        public Vector2 Position { get; set; }

        public int XTile { get { return (int)Position.X/32; } }
        public int YTile { get { return (int)Position.Y / 32; } }

        public MouseClickEventArgs(Vector2 position)
        {
            Position = position; 
        }
    }
}
