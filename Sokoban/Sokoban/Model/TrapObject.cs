using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class TrapObject : BaseObject
    {
        private char _trapValue = '~';
        
        /// <summary>
        /// Wanneer er 3 keer een kist of vorkheftruk op dit veld wordt geplaatst, begeeft de vloer het
        /// en wordt dit veld een gat weergegeven met een spatie ‘ ‘. Elk krat dat daarna op het
        /// valkuil veld wordt geplaatst gaat verloren (wordt verwijderd uit het level). Een vorkheftruk
        /// kan door de brede wielbasis wel over een ingestorte valkuil rijden.
        /// </summary>

        public override char _value
        {
            get
            {
                return _trapValue;
            }
            set
            {
                _trapValue = value;
            }
        }

        public override void SetChar(char x)
        {
            _trapValue = x;
            base.SetChar(_trapValue);
        }

    }
}
