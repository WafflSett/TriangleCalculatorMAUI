using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleCalculatorMAUI.Classes
{
    public class Triangle
    {
        public int? A { get; set; }
        public int? B { get; set; }
        public int? C { get; set; }
        public int S 
        { 
            get {
                if (IsValidTriangle())
                    return (int)(A + B + C)!; 
                return 0;
            } 
        }
        public double Area
        {
            get
            {
                if (IsValidTriangle())
                    return Math.Round(Math.Sqrt((double)(S*(S-A)*(S-B)*(S-C))!), 2);
                return 0;
            }
        }
        public double Alpha
        {
            get
            {
                if (IsValidTriangle())
                    return Math.Round(Double.RadiansToDegrees(Math.Acos((double)(((C * C) + (B * B) - (A * A)) / (double)(2 * (C * B))!)!)), 2);
                return 0;
            }
        }
        public double Beta
        {
            get
            {
                if (IsValidTriangle())
                    return Math.Round(Double.RadiansToDegrees(Math.Acos((double)(((A * A) + (C * C) - (B * B)) / (double)(2 * (A * C))!)!)), 2);
                return 0;
            }
        }
        public double Gamma
        {
            get
            {
                if (IsValidTriangle())
                    return Math.Round(Double.RadiansToDegrees(Math.Acos((double)(((A*A)+(B*B)-(C*C))/(double)(2*(A*B))!)!)), 2);
                return 0;
            }
        }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public Triangle()
        {
        }
        public bool IsValidTriangle()
        {
            if (A==null || B==null || C==null)
                return false;
            if (A+B>C && B+C > A && C+A>B)
                return true;
            return false; 
        }
    }
}
