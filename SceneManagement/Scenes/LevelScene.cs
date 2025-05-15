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
    internal class LevelScene : Scene
    {
        private ContentManager contentManager;
        private Texture2D imgMonogameLogo;

        public LevelScene(ContentManager contentManager) { this.contentManager = contentManager; }

        public void Load()
        {
            imgMonogameLogo = contentManager.Load<Texture2D>("mgimg");
        }
        public void Update(GameTime gameTime)
        {
            if (KeyManager.IsKeyPressed(Keys.Space))
            {
                SceneManager.SetCurrentScene(SceneEnum.MENU);
            }
            if (KeyManager.IsKeyPressed(Keys.D))
            {
                SceneManager.SetCurrentScene(SceneEnum.MENU);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imgMonogameLogo, new Rectangle(10, 10, 400, 400), Color.White);
        }
    }
}
