using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.AvoidGame
{
    internal class PlayerCharacter : GameCharacter
    {
        private readonly Queue<EnemyCharacter> collisionObjects;
        private int health = 2;
        private bool isDead = false;
        public PlayerCharacter(ContentManager cm, String imgPath, Queue<EnemyCharacter> collisionObjects) :base(cm, imgPath)
        {
            this.collisionObjects = collisionObjects;
        }

        override public void Update(GameTime gameTime)
        {

            SetPosToMouse();
            CheckCollision();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(charimg , position, Color.White);
        }

        public void SetPosToMouse()
        {
            position.X = Mouse.GetState().X - (charimg.Width / 2);
            position.Y = Mouse.GetState().Y - (charimg.Height / 2);   
        }
        public void CheckCollision() 
        {
            foreach (EnemyCharacter enemy in collisionObjects)
            {
                if (enemy.GetCollisionBox().Intersects(this.GetCollisionBox()))
                {
                    health--;
                    enemy.SetIsCollisionOn(false);
                    if (health < 1)
                    {
                        isDead = true;  
                    }
                    else if (health < 2)
                    {
                        SetImage("AG_PlayerDmg");
                    }
                }
            }
        }

        public bool GetIsDead()
        {
            return isDead;
        }

    }
}
