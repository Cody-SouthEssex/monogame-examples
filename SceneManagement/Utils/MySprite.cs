using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Utils
{
    internal class MySprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 size;
        public Color colour;
        public Rectangle Rect
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)size.X , (int)size.Y); }
        }

        public MySprite(Texture2D texture, Vector2 size, Color colour)
        {
            this.texture = texture;
            this.colour = colour;
            if (size == Vector2.Zero)
            {
                this.size = new Vector2(texture.Width, texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            this.position = position;
            spriteBatch.Draw(texture, Rect, colour);
            
        }
    }
}
