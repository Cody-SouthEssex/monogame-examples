using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SceneManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.AvoidGame
{
    internal class EnemyManager
    {
        private const int BASE_ENEMY_QUEUE_SIZE = 100;
        private readonly Dictionary<EnemyTypeEnum, string> enemyImgs = new Dictionary<EnemyTypeEnum, string>();

        //Queue is a reference type not a value type
        private readonly Queue<EnemyCharacter> basicEnemies = new Queue<EnemyCharacter>();
        private readonly Queue<EnemyCharacter> activeEnemies = new Queue<EnemyCharacter>();
        private MyTimer enemySpawnTimer;
      
        private ContentManager contentManager;

        public EnemyManager(ContentManager cm)
        {
            contentManager = cm;
            enemyImgs.Add(EnemyTypeEnum.BASE, "AG_Enemy");
            FillEnemies();
            enemySpawnTimer = new MyTimer(0.2f);


        }

        public void FillEnemies()
        {
            string imgPath = enemyImgs.TryGetValue(EnemyTypeEnum.BASE, out string value) ? value : "AG_EnemyErr";

            for (int i = 0; i < BASE_ENEMY_QUEUE_SIZE; i++)
            {
                basicEnemies.Enqueue(new EnemyCharacter(contentManager,imgPath,EnemyTypeEnum.BASE));
            }
        }

        public void Update(float delta)
        {
            SpawnEnemy();

            if (activeEnemies.Any())
            {
                foreach (EnemyCharacter enemy in activeEnemies)
                {
                    enemy.MoveEnemy(delta);
                }
            }

            ClearActivveAndRefillEnemy();
        }

        public void DrawEnemies(SpriteBatch spriteBatch)
        {
            
            if (activeEnemies.Any())
            {
                foreach (EnemyCharacter enemy in activeEnemies)
                {
                    spriteBatch.Draw(enemy.GetImage(), enemy.GetPosition(), Color.White);

                }
            }
        }

        public void SpawnEnemy()
        {
            if(!enemySpawnTimer.GetIsActive())
            {
                enemySpawnTimer.StartStop();
            } 

            enemySpawnTimer.Update();

            if (enemySpawnTimer.GetIsTriggerTime())
            {
                if(basicEnemies.Any())
                {
                    EnemyCharacter nextEnemy = basicEnemies.Dequeue();
                    activeEnemies.Enqueue(nextEnemy);
                    enemySpawnTimer.StartStop();
                }
                
            }
        }

        public void ClearActivveAndRefillEnemy()
        {
            if (activeEnemies.Any())
            {
                EnemyCharacter oldestActiveEnemy = activeEnemies.Peek();


                if (oldestActiveEnemy.GetPosition().Y > MyUtils.BackBufferSize.Y)
                {
                    switch (oldestActiveEnemy.GetEnemyType())
                    {
                        case EnemyTypeEnum.BASE:
                            EnemyCharacter enemyToPutBack = activeEnemies.Dequeue();
                            enemyToPutBack.Respawn();
                            basicEnemies.Enqueue(enemyToPutBack);
                            break;
                    }
                }
            }
        }

        public Queue<EnemyCharacter> GetActiveEnemies()
        {
            return activeEnemies;
        }
    }
}
