using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LetsCreateWarcraft2.Common
{
    class SelectRectangle
    {
        private static Texture2D _texture;

        public static void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("select2"); 
        }

        public static void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            if (_texture == null)
                return;

            spriteBatch.Draw(_texture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 2), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, 2, rectangle.Height), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width, 2), Color.White);
            spriteBatch.Draw(_texture, new Rectangle(rectangle.X, rectangle.Y, 2, rectangle.Height), Color.White);

        }

    }
}
