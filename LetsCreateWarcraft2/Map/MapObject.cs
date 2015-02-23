using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsCreateWarcraft2.Common;
using LetsCreateWarcraft2.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Map
{
    class MapObject
    {
        private static int _idCounter;
        public string Id { get; private set; }

        private Sprite _sprite;
        private bool _selected;
        private Movement _movement; 

        public MapObject(ManagerMouse managerMouse, Sprite sprite, ManagerTiles managerTiles, ManagerUnits managerUnits)
        {
            _idCounter++;
            Id = _idCounter.ToString(); 
            _sprite = sprite;
            _movement = new Movement(Id,_sprite, managerTiles, managerUnits);
            managerMouse.MouseEventHandler += managerMouse_MouseEventHandler;
            managerMouse.MouseClickEventHandler += managerMouse_MouseClickEventHandler;         
        }

        void managerMouse_MouseClickEventHandler(object sender, MyEventArgs.MouseClickEventArgs e)
        {
            if(_selected)
                _movement.Move(e.XTile,e.YTile);
        }

        void managerMouse_MouseEventHandler(object sender, MyEventArgs.MouseEventArgs e)
        {
            if (_sprite.Rectangle.Intersects(e.SelectRectangle))
                _selected = true;
            else
                _selected = false; 
        }

        public void LoadContent(ContentManager content)
        {
            _sprite.LoadContent(content);
        }

        public void Update()
        {
            _sprite.Update();
            _movement.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
            if(_selected)
                SelectRectangle.Draw(spriteBatch,_sprite.Rectangle);
        }

        public Vector2 AtSpace()
        {
            return new Vector2(_sprite.XTilePos,_sprite.YTilePos);
        }
    }
}
