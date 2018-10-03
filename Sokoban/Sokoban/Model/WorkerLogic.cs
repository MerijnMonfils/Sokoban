using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WorkerLogic
    {

        private bool _isSleeping { get; set; }


        public void IsWakingUp()
        {
            // chance of waking up = 1/10 -> 10%
        }

        public void MoveWorker()
        {
            // random direction
            // if wall -> no move
            // if crate -> move crate (unless a wall is at the end)
            // if player -> move player (unless a wall is at the end)
            // if player with crate -> move both (unless a wall is at the end)
        }

        public void CheckPercentageSleep()
        {
           // chance of sleeping = 1/4 -> 25%
        }

        public void CheckIfPushed()
        {
            // if worker is pushed, he wakes up -> but doesn't move
        }

    }
}
