using SceneManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Scenes.AvoidGame
{
    internal class Timer
    {
        private float timeLeft;
        private float timeTotal;
        private bool isActive;
        private bool isTriggerTime;
        public Timer(float tt )
        { 
            timeTotal = tt;
            Reset();
        }

        public void Reset()
        {
            isTriggerTime = false;
            timeLeft = timeTotal;
        }
        public void StartStop()
        {
            isActive = !isActive;

            if (isTriggerTime)
            {
                Reset();
            }
        }

        public void Update()
        {
            if (!isActive) return;

            timeLeft = timeLeft - MyUtils.Delta;

            if (timeLeft <= 0)
            {
                isTriggerTime = true;
                
            }


        }
        public bool GetIsActive()
        {
            return isActive;
        }
        public bool GetIsTriggerTime()
        {
            return isTriggerTime;
        }
    }
}
