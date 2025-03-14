using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra
{
    public class HerniPostava
    {
        public int poziceX { get; private set; }
        public int poziceY { get; private set; }
        public int Level { get; private set; } = 1;
        private string jmeno;

        public HerniPostava()
        {
           
        }

        public void changePosition(int x, int y)
        {

        }



        public string Jmeno
        {
          
        }

        public HerniPostava(string jmeno)
        {
            
        }

        public virtual void ZmenaPozice(int x, int y)
        {
           
        }

        public override string ToString()
        {
            
        }

    }
    
}
