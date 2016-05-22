using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Map;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Manager
{
    class ManagerTiles
    {
        private List<TileGraphic> _layerOne;
        private List<TileGraphic> _layerTwo;
        private List<TileCollision> _collisionLayer;

        public ManagerTiles()
        {
            _collisionLayer = new List<TileCollision>();
            //For test
            _layerOne = new List<TileGraphic>();
            for (int n = 0; n < 800/32; n++)
            {
                for (int i = 0; i < 480/32; i++)
                {
                    _layerOne.Add(new TileGraphic(n, i, 1, 0));
                }       
            }
            _layerTwo = new List<TileGraphic>();
            for (int n = 0; n < 6; n++)
            {
                _layerTwo.Add(new TileGraphic(5,n,0,0));
                _collisionLayer.Add(new TileCollision(5,n,true));
            }
            for (int n = 0; n < 10; n++)
            {
                _layerTwo.Add(new TileGraphic(10, n + 5, 0, 0));
                _collisionLayer.Add(new TileCollision(10, n + 5, true));
            }
            for (int n = 0; n < 9; n++)
            {
                _layerTwo.Add(new TileGraphic(12, n, 0, 0));
                _collisionLayer.Add(new TileCollision(12, n, true));
            }
        }

        public void LoadContent(ContentManager content)
        {
            _layerOne.ForEach(t => t.LoadContent(content));
            _layerTwo.ForEach(t => t.LoadContent(content));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _layerOne.ForEach(t => t.Draw(spriteBatch));
            _layerTwo.ForEach(t => t.Draw(spriteBatch));
        }

        public bool CheckCollision(int xTilePos, int yTilePost)
        {
            return _collisionLayer.Any(t => t.XTilePos == xTilePos && t.YTilePos == yTilePost && t.Collision); 
        }
    }
}
