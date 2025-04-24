using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SceneManagement.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SceneManagement.Scenes.AvoidGame
{
    internal class AvoidGameScene : Scene
    {
        private PlayerCharacter Player;
        private ContentManager contentManager;
        private EnemyManager enemyManager;

        public AvoidGameScene(ContentManager contentManager) 
        { 
            this.contentManager = contentManager; 
        }
        

        public void Load()
        {
            
            enemyManager = new EnemyManager(contentManager);            
            Player = new PlayerCharacter(contentManager, "AG_Player" , enemyManager.GetActiveEnemies());
        }
        public void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
           
            if(!Player.GetIsDead())
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
