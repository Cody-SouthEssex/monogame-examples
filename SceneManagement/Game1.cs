﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SceneManagement.Scenes;
using SceneManagement.Scenes.AvoidGame;
using SceneManagement.Utils;
using System;

namespace SceneManagement
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //SceneMenu menuScene;
        //SceneManager sceneManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            MyUtils.Init( _graphics);
            // TODO: Add your initialization logic here
            SceneManager.AddScene(SceneEnum.MENU, new MenuScene(Content));
            SceneManager.AddScene(SceneEnum.LEVEL, new LevelScene(Content));
            SceneManager.AddScene(SceneEnum.AVOID_GAME, new AvoidGameScene(Content));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //menuScene.Load();
            
            SceneManager.SetCurrentScene(SceneEnum.AVOID_GAME);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            MyUtils.Update(gameTime, _graphics);
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            // TODO: Add your update logic here
            SceneManager.GetCurrentScene().Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront );

            //menuScene.Draw(_spriteBatch);
            SceneManager.GetCurrentScene().Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
