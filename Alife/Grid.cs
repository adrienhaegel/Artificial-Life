using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    // Grid is a class used to efficiently store and retrieve data. The operation with highest complexity which is done often is to find the nearest neighbor
    // Compartimenting all the animals in an array (in spatial bins) allow a fast nearest neighbour retrieval.
    public class Grid<T> where T : Gridable
    {

        public static Parameters parameters;

        private int Nx;
        private int Ny;

        private double xstep;
        private double ystep;

        List<T>[,] Data; //Where the data is stored: array of spatial bins, with the List of Animals in each bin.

        //About the size of the Grid:
        //If the size is small, the grid efficiency is useless, but if it is too high, the number of cells is too high and it becomes computationally more expensive.
        //The number of cells should depend on the number of animals.


        //Constructor
        public Grid(int Nx, int Ny)
        {
            this.Nx = Nx;
            this.Ny = Ny;

            this.xstep = parameters.Length_x / (double)Nx;
            this.ystep = parameters.Length_y / (double)Ny;

            Data = new List<T>[Nx, Ny];
            for (int xi = 0; xi < Nx; xi++)
            {
                for (int yi = 0; yi < Ny; yi++)
                {
                    Data[xi, yi] = new List<T>();
                }
            }

        }

        public int GetxIndex(double x) //Return the x-index of the bin for that position
        {
            return (int)Math.Floor(x / xstep);
        }

        public int GetyIndex(double y) //Return the y_index of the bin for that position
        {
            return (int)Math.Floor(y / ystep);
        }

        public void Add(T obj) //Add an object to the grid
        {
            this.Data[GetxIndex(obj.Getx()), GetyIndex(obj.Gety())].Add(obj); //Add the object to the correct bin
            obj.Setindex(GetxIndex(obj.Getx()), GetyIndex(obj.Gety())); //updates the indexes of the object
        }

        public void AddRange(ICollection<T> objlist) //Add a collection of objects to the grid
        {
            foreach (var obj in objlist)
            {
                Add(obj);
            }
        }

        public void Remove(T obj) //Remove an object from the grid
        {
            this.Data[GetxIndex(obj.Getx()), GetyIndex(obj.Gety())].Remove(obj);
        }

        public void RemoveRange(ICollection<T> objlist) //Remove a collection of objects from the grid
        {
            foreach (var obj in objlist)
            {
                Remove(obj);
            }
        }

        public bool HasChangedInGrid(double oldx, double oldy, double newx, double newy) //returns true if the old and new indexes are different.
        {
            if (GetxIndex(oldx) != GetxIndex(newx))
            {
                return true;
            }
            else if (GetyIndex(oldy) != GetyIndex(newy))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(T obj, double newx, double newy) //Update the position of an object
        {
            if (HasChangedInGrid(obj.Getx(), obj.Gety(), newx, newy)) // If the bin of the object has changed, then 
            {
                Remove(obj); //remove from the grid
                obj.Setx(newx); //set new position values
                obj.Sety(newy);
                obj.Setindex(GetxIndex(newx), GetyIndex(newy)); //updates the indexes
                Add(obj); //Add the object back
            }
            else //If the bin is the same, then just update the positions
            {
                obj.Setx(newx);
                obj.Sety(newy);
            }
        }



        //This returns an enurable of all the elements who might be in the radius around x and y
        //It retunrs all the bins that are at least partially covered by the radius
        //Hence, some elements may be (slightly) outside the radius
        public System.Collections.IEnumerable SearchRadius(double x, double y, double radius)
        {
            //indexes of all possible bins
            int minx = Math.Max(GetxIndex(x - radius), 0);
            int maxx = Math.Min(GetxIndex(x + radius), this.Nx - 1);
            int miny = Math.Max(GetyIndex(y - radius), 0);
            int maxy = Math.Min(GetyIndex(y + radius), this.Ny - 1);

            for (int indx = minx; indx <= maxx; indx++)
            {
                for (int indy = miny; indy <= maxy; indy++)
                {
                    foreach (T t in Data[indx, indy])
                        yield return t;
                }
            }
        }


        /* old version, should not be used
        internal System.Collections.IEnumerable Starving_Iterator()
        {
            int K_per_square = (int)Math.Floor(parameters.K / (Nx * Ny));
            for (int indx = 0; indx < Nx; indx++)
            {
                for (int indy = 0; indy < Ny; indy++)
                {

                    List<T> list = Data[indx, indy];
                    if (list.Count > K_per_square)
                    {
                        int count = 1;
                        foreach (T t in list)
                        {
                            if (count > K_per_square)
                            {
                                yield return t;
                            }
                            count++;
                        }

                    }


                }
            }
        }
        */

        //Returns the closest element in a radius around x and y.
        //WARNING: because of the searchradius limitation, the element can be slightly outside the radius. It should be checked afterwards.
        public Tuple<double, T> FindClosestinRadius(double x, double y, double radius) 
        {
            double min = double.PositiveInfinity;
            T minvalue;
            minvalue = default(T);

            foreach (T t in SearchRadius(x, y, radius)) //finds the closest element
            {
                double dist = (t.Getx() - x) * (t.Getx() - x) + (t.Gety() - y) * (t.Gety() - y);
                if (dist < min)
                {
                    min = dist;
                    minvalue = t;
                }
            }
            return new Tuple<double, T>(Math.Sqrt(min), minvalue);

        }

        //same as findclsoestinradius, but can not return the element at x,y.
        // Should be used when looking for closest element of same type (Prey-Prey or Predator-Predator)
        // For hunting (Predator-Prey closest), the classic FindClosestinRadius should be used.
        public Tuple<double, T> FindClosestinRadius_Not_Self(double x, double y, double radius) 
        {
            double min = parameters.Length_x * 2 + parameters.Length_y * 2;
            T minvalue;
            minvalue = default(T);

            foreach (T t in SearchRadius(x, y, radius))
            {
                double dist = (t.Getx() - x) * (t.Getx() - x) + (t.Gety() - y) * (t.Gety() - y);
                if (dist < min && dist > 0)
                {
                    min = dist;
                    minvalue = t;
                }
            }
            return new Tuple<double, T>(Math.Sqrt(min), minvalue);
        }

        public System.Collections.IEnumerable Iterator() //An iterator to cycle trough the objects in the grid
        {
            for (int indx = 0; indx < Nx; indx++)
            {
                for (int indy = 0; indy < Ny; indy++)
                {
                    List<T> list = Data[indx, indy];
                    if (list.Count != 0)
                    {
                        foreach (T t in list)
                        {
                            yield return t;
                        }
                    }
                }
            }
        }

        public List<T> ToList() //Return all the elements in a List
        {
            List<T> result = new List<T>();
            foreach (T t in Iterator())
            {
                result.Add(t);
            }
            return result;
        }
    }
}
