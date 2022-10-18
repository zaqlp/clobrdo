using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clobrdo
{
    public class StartovniPolicko : VicenasobnePolicko
    {
        public override void Vypis()
        {
            Console.Write("{");
            foreach (var figurka in figurky)
            {
                figurka.Vypis();
            }

            Console.Write("}");
        }
    }
}
