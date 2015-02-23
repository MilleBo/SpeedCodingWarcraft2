using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Common;
using LetsCreateWarcraft2.MyEventArgs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Mouse = Microsoft.Xna.Framework.Input.Mouse;

namespace LetsCreateWarcraft2.Manager
{
    class ManagerMouse
    {

        private Vector2 _position;
        private Vector2 _selectCorner;
        private Rectangle _selectRectangle;
        private bool _mouseDown;


        private event EventHandler<MouseEventArgs> _mouseEventHandler;
        private event EventHandler<MouseClickEventArgs> _mouseClickEventHandler;  

        public event EventHandler<MouseEventArgs> MouseEventHandler
        {
            add { _mouseEventHandler += value; }
            remove { _mouseEventHandler -= value;  }
        }

        public event EventHandler<MouseClickEventArgs> MouseClickEventHandler
        {
            add { _mouseClickEventHandler += value; }
            remove { _mouseClickEventHandler -= value;  }
        }

        public void Update()
        {
            var mouse = Mouse.GetState();

            if (mouse.RightButton == ButtonState.Pressed)
            {
                if(_mouseClickEventHandler != null)
                    _mouseClickEventHandler(this,new MouseClickEventArgs(new Vector2(mouse.X,mouse.Y)));
            }

            if (mouse.LeftButton == ButtonState.Pressed && !_mouseDown)
            {
                _mouseDown = true; 
                _position = new Vector2(mouse.X,mouse.Y);
                _selectCorner = _position; 
               _selectRectangle = new Rectangle((int)_position.X,(int)_position.Y,0,0);
            }
            else if (mouse.LeftButton == ButtonState.Pressed)
            {
                _selectCorner = new Vector2(mouse.X, mouse.Y);
                if (_selectCorner.X > _position.X)
                {
                    _selectRectangle.X = (int) _position.X;
                }
                else
                {
                    _selectRectangle.X = (int) _selectCorner.X;
                }


                if (_selectCorner.Y > _position.Y)
                {
                    _selectRectangle.Y = (int) _position.Y;
                }
                else
                {
                    _selectRectangle.Y = (int) _selectCorner.Y;
                }

                _selectRectangle.Width = (int) Math.Abs(_position.X - _selectCorner.X);
                _selectRectangle.Height = (int) Math.Abs(_position.Y - _selectCorner.Y);
            }
            else
            {
                if(_mouseEventHandler != null)
                    _mouseEventHandler(this,new MouseEventArgs(_selectRectangle));
                _mouseDown = false; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_mouseDown)
            {
                //spriteBatch.Draw(_texture,_selectRectangle, new Color(255,255,255,180));
                SelectRectangle.Draw(spriteBatch,_selectRectangle);
            }
        }


    }
}
