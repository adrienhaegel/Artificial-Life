using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    //This interface implements the methods required for elements that can be put in a grid.
    // An element in a grid should know the value of its indexes in the grid.
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
