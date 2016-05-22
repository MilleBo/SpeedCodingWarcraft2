using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Map
{
    class TileGraphic : Tile
    {
      
        private Texture2D _texture;
        private int _textureX;
        private int _textureY; 

        public TileGraphic(int xTilePos, int yTilePos, int textureX, int textureY)
        {
            _width = 32;
            _height = 32;
            XTilePos = xTilePos;
            YTilePos = yTilePos;
            _textureX = textureX;
            _textureY = textureY; 
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("tileset"); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,new Rectangle((int)Position.X,(int)Position.Y,_width,_height),new Rectangle(_textureX*_width,_textureY*_height,_width,_height),Color.White);
        }
        
    }
}
