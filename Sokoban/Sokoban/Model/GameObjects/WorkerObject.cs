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
        private bool _isSleeping;

        public WorkerObject(bool isSleeping)
        {
            this._isSleeping = isSleeping;
            if (!_isSleeping)
                this.SetChar((char)Characters.Worker);
        }

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

        public override void SetChar(char x)
        {
            _workerValue = x;
            base.SetChar(_workerValue);
        }
    }

}
