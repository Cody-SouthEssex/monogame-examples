using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SceneManagement.Input;

namespace SceneManagement.Scenes
{
    
    internal class MenuScene : Scene
    {
        private ContentManager contentManager;
        private Texture2D imgBall;


        public MenuScene(ContentManager contentManager) { this.contentManager = contentManager; }
        public void Load() 
        {
            imgBall = contentManager.Load<Texture2D>("ball");
        
        }
        public void Update(GameTime gameTime) 
        {
            
            if (KeyManager.IsKeyPressed(Keys.Space))
            {
                SceneManager.SetCurrentScene(SceneEnum.LEVEL);
            }
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(imgBall, new Rectangle(10, 10, 400, 400), Color.White);
        }

    }
}
