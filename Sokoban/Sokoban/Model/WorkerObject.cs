using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class WorkerObject : BaseObject
    {
        private char _workerValue = (char) Characters.WorkerSleeping;

        public override char _value
        {
            get
            {
                return _workerValue;
            }
            set
            {
                _workerValue = value;
            }
        }
    }
}
