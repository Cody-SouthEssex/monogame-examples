using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Utils
{
    static class MyUtils
    {
        static public Vector2 backBuffer  = new Vector2();
        static public Vector2 BackBufferSize { get; private set; }
        static public float Delta { get; private set; }
        static public float TotalGameTime { get; private set; }

        static public void Init(GraphicsDeviceManager graphics)
        {
            BackBufferSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }
        static public void Update(GameTime gameTime , GraphicsDeviceManager graphics)
        {
            TotalGameTime =  (float)gameTime.TotalGameTime.TotalSeconds;
            Delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            BackBufferSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }
    }
}
