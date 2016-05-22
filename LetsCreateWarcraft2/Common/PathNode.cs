using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsCreateWarcraft2.Common
{
    class PathNode
    {
        public int XTilePos { get; set; }
        public int YTilePos { get; set; }
        public PathNode Parent { get; set; }

        //Movement cost from starting potin to here (10 points per tile)
        public int H { get; set; }
        /// <summary>
        /// Movement cost from here to final destination (an estimation)
        /// </summary>
        public int G { get; set; }

        public int F { get { return H + G; } }

        public PathNode(int xTilePos, int yTilePos, PathNode parent, int goalXTile, int goalYTile)
        {
            XTilePos = xTilePos;
            YTilePos = yTilePos;
            Parent = parent;
            var distanceX = Math.Abs(xTilePos - goalXTile);
            var distanceY = Math.Abs(yTilePos - goalYTile);

            G = (distanceX + distanceY)*10;
            if (parent != null)
                H = 10 + parent.H;
            else
                H = 0; 
        }


    }

    class PathNodeComparer : IComparer<PathNode>
    {
        public int Compare(PathNode x, PathNode y)
        {
            if (x.F == y.F)
                return x.G.CompareTo(y.G);

            return x.F.CompareTo(y.F);
        }  
    }
}
