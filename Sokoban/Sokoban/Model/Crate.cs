using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Crate : Square
    {
        public char _square
        {

            get
            {
                return _square;
            }
            set
            {
                _square = 'O';
            }
        }
        public object _neighbourBelow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object _neighbourAbove { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object _neighbourRight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object _neighbourLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
