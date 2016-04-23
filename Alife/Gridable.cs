using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public interface Gridable
    {
        int Getxindex();
        int Getyindex();

        double Getx();
        double Gety();

        void Setx(double a);
        void Sety(double a);

        void Setindex(int xindex, int yindex);

    }
}
