using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SceneManagement.Scenes.AvoidGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.ShootGame
{
    internal class ShootGameScene : Scene
    {
        
        private ContentManager contentManager;
       

        public ShootGameScene(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }


        public void Load()
        {

            
        }
        public void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!Player.GetIsDead())
            {
                Player.Update(gameTime);
                enemyManager.Update(delta);
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            enemyManager.DrawEnemies(spriteBatch);
            Player.Draw(spriteBatch);

        }

    }
}
