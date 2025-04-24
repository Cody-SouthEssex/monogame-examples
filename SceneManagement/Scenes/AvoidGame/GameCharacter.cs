using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.AvoidGame
{
    internal abstract class GameCharacter
    {
        protected Texture2D charimg;
        private ContentManager contentManager;
        protected Vector2 position = new Vector2();
        protected bool isCollisionOn = true;

        public GameCharacter(ContentManager cm, string imgPath) 
        {
            contentManager = cm;
            SetImage(imgPath);
            position.X = 0;
            position.Y = 0;
        }

        public void SetImage(string imgPath)
        {
            charimg = contentManager.Load<Texture2D>(imgPath);
        }
        public Texture2D GetImage()
        {
            return charimg;
        }
        public Vector2 GetPosition() 
        { 
            return position;  
        }

        public Rectangle GetCollisionBox()
        {

            return isCollisionOn ? new Rectangle((int)position.X, (int)position.Y, charimg.Width, charimg.Height) :
                new Rectangle(0, 0, 0, 0);
        }

        public void SetIsCollisionOn(bool collison)
        {
            isCollisionOn = collison;
        }
        virtual public void Update(GameTime gameTime) { }
        virtual public void Draw(SpriteBatch spriteBatch) { }
        
    }
}
