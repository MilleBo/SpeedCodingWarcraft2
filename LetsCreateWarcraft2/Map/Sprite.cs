using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Map
{
    class Sprite
    {
        private Texture2D _texture;
        private Vector2 _positon;
        private int _width;
        private int _height;

        public int XTilePos { get; set; }
        public int YTilePos { get; set; }

        private int _wantedXPos;
        private int _wantedYPos;

        public bool TransitionOn { get; set; }

        private int _speed; 

        public Sprite(int xTilePos, int yTilePos)
        {
            XTilePos = xTilePos;
            YTilePos = yTilePos; 
            _positon = new Vector2(XTilePos*32,YTilePos*32);
            _width = 32;
            _height = 32; 
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int) (_positon.X - 2.5),(int)(_positon.Y - 2.5),_width+5,_height+5);}
        }

        public void Update()
        {
            if(TransitionOn)
                UpdateTransition();

        }

        private void UpdateTransition()
        {
            if (_wantedXPos < XTilePos)
            {
                _positon.X -= _speed;
                if ((_positon.X - _wantedXPos*_width) == 0)
                {
                    XTilePos--; 
                }
            }
            else if (_wantedXPos > XTilePos)
            {
                _positon.X += _speed;
                if ((_positon.X - _wantedXPos * _width) == 0)
                {
                    XTilePos++;
                }
            }
            else if (_wantedYPos < YTilePos)
            {
                _positon.Y -= _speed;
                if ((_positon.Y - _wantedYPos * _height) == 0)
                {
                    YTilePos--;
                }
            }
            else if (_wantedYPos > YTilePos)
            {
                _positon.Y += _speed;
                if ((_positon.Y - _wantedYPos*_height) == 0)
                {
                    YTilePos++;
                }
            }
            else
            {
                TransitionOn = false; 
            }
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("worker"); 
        }

        public void Move(int x, int y, int speed)
        {
            _wantedXPos = XTilePos + x;
            _wantedYPos = YTilePos + y;
            TransitionOn = true;
            _speed = speed; 
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,new Rectangle((int)_positon.X,(int)_positon.Y,_width,_height), Color.White);
        }
    }
}
