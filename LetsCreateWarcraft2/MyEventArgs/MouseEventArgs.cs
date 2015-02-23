using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LetsCreateWarcraft2.MyEventArgs
{
    class MouseEventArgs : EventArgs
    {
        public Rectangle SelectRectangle { get; set; }

        public MouseEventArgs(Rectangle selectRectangle)
        {
            SelectRectangle = selectRectangle;
        }
    }
}
