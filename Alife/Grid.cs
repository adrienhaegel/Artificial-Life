using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alife
{
    public class Grid<T> where T:Gridable
    {
        public static Parameters parameters;

        private int Nx;
        private int Ny;

        private double xstep;
        private double ystep;

        List<T>[,] Data;

        public Grid(int Nx, int Ny)
        {
            this.Nx = Nx;
            this.Ny = Ny;
            

            this.xstep = parameters.Length_x / (double)Nx;
            this.ystep = parameters.Length_y / (double)Ny;

            Data = new List<T>[Nx, Ny];
            for(int xi=0;xi< Nx; xi++)
            {
                for (int yi = 0; yi < Ny; yi++)
                {
                    Data[xi, yi] = new List<T>();
                }
            }

        }


        public int GetxIndex(double x)
        {
            return  (int)Math.Floor(x / xstep);
        }

        public int GetyIndex(double y)
        {
            return (int)Math.Floor(y /ystep);
        }

        public void Add(T obj)
        {
            this.Data[GetxIndex(obj.Getx()),GetyIndex(obj.Gety())].Add(obj);
            obj.Setindex(GetxIndex(obj.Getx()), GetyIndex(obj.Gety()));
        }

        public void AddRange(ICollection<T> objlist)
        {
            foreach(var obj in objlist)
            {
                Add(obj);
            }
        }

        public void Remove(T obj)
        {
            this.Data[GetxIndex(obj.Getx()), GetyIndex(obj.Gety())].Remove(obj);
        }

        public void RemoveRange(ICollection<T> objlist)
        {
            foreach (var obj in objlist)
            {
                Remove(obj);
            }
        }
        public bool HasChangedInGrid(double oldx, double oldy, double newx, double newy)
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

        public void Update(T obj, double newx, double newy)
        {
            if (HasChangedInGrid(obj.Getx(), obj.Gety(), newx, newy))
            {
                Remove(obj);
                obj.Setx(newx);
                obj.Sety(newy);
                obj.Setindex(GetxIndex(newx), GetyIndex(newy));
                Add(obj);
            }
            else
            {
                obj.Setx(newx);
                obj.Sety(newy);
            }
        }

        public System.Collections.IEnumerable Iterator()
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

        public System.Collections.IEnumerable SearchRadius(double x, double y, double radius)
        {
            int minx =Math.Max(GetxIndex(x - radius),0);
            int maxx = Math.Min(GetxIndex(x + radius),this.Nx-1);
            int miny = Math.Max(GetyIndex(y - radius), 0);
            int maxy = Math.Min(GetyIndex(y + radius), this.Ny-1);

            for(int indx =minx; indx <= maxx; indx++)
            {
                for(int indy = miny; indy <= maxy; indy++)
                {
                    foreach(T t in Data[indx, indy])
                    yield return t;
                }
            }
        }

        public Tuple<double,T> FindClosestinRadius(double x, double y, double radius)
        {
            double min = parameters.Length_x*2 + parameters.Length_y*2;
            T minvalue ;
            minvalue = default(T);

            foreach (T t in SearchRadius(x, y, radius))
            {
                double dist = (t.Getx() - x) * (t.Getx()- x) + (t.Gety()- y) * (t.Gety() - y);
                if (dist < min)
                {
                    min = dist;
                    minvalue = t;
                }
            }

            return new Tuple<double, T>(Math.Sqrt(min), minvalue);

        }

        public List<T> ToList()
        {
            List<T> result = new List<T>();
            foreach(T t in Iterator())
            {
                result.Add(t);
            }
            return result;
        }
    }
}
