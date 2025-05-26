using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneManagement.Utils
{
    /// <summary>
    /// Create the timer object and pass in the time you want to count down from in seconds E.G new MyTimer(10) this will count down 10 seconds
    /// Call MyTimer.Update() in the desired classes update method or in a loop
    /// When ready to start the timer call MyTimer.StartStop() if in a loop you can surround it with if(!MyTimer.GetIsActive())
    /// </summary>
    internal class MyTimer
    {
        private float timeLeft;
        private float timeTotal;
        private bool isActive;
        private bool isTriggerTime;
        public MyTimer(float tt)
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
