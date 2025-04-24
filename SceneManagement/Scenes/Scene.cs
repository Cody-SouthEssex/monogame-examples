using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes
{
    /// <summary>
    /// Interface to ensure to apply these functions to the scenes that will extend it
    /// </summary>
    internal interface Scene
    {
        /// <summary>
        /// Load function for loading content. this matches the load in the main Game1 file
        /// </summary>
        public void Load();

        /// <summary>
        /// Update function which will handle general game logic. this matches the Update function in the main Game1 file
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime);

        /// <summary>
        /// Draw function used to draw to screen. this matches the Draw fuction in the main Game1 file
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch);

    }
}
