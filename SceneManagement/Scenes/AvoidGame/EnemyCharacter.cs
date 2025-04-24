using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SceneManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.AvoidGame
{
    internal class EnemyCharacter : GameCharacter
    {
        private Random random = new Random();
        private EnemyTypeEnum enemyType;
        private int gravety = -1;

        public EnemyCharacter(ContentManager cm, string imgPath, EnemyTypeEnum et) : base(cm, imgPath)
        {
            enemyType = et;
            Respawn();
        }

        
        public void MoveEnemy(float delta)
        {
            switch (enemyType)
            {
                case EnemyTypeEnum.BASE:
                    position.Y = position.Y + (gravety * delta);
                    break;
            }
        }
        public void Respawn()
        {
            position.X = random.Next(0, (int)MyUtils.BackBufferSize.X); 
            position.Y = 0-charimg.Height;
            isCollisionOn = true;
            SetTypeSettings();
        }
        public void SetTypeSettings()
        {
            switch (enemyType)
            {
                case EnemyTypeEnum.BASE:
                    gravety = 250;
                    break;
            }
        }

        public EnemyTypeEnum GetEnemyType() 
        { 
            return enemyType; 
        }

    }
}
