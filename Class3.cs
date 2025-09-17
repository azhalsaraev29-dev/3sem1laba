using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem1laba
{
    public class Rectangle // не наследуем от Triangle, т.к. другая геометрия
    {
        private Point2D p1;
        private Point2D p2;
        private Point2D p3;
        private Point2D p4;

        public Rectangle(Point2D p1, Point2D p2, Point2D p3, Point2D p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }

        public Point2D getP1() { return p1; }
        public Point2D getP2() { return p2; }
        public Point2D getP3() { return p3; }
        public Point2D getP4() { return p4; }

        public void addX(int x)
        {
            p1.addX(x);
            p2.addX(x);
            p3.addX(x);
            p4.addX(x);
        }

        public void addY(int y)
        {
            p1.addY(y);
            p2.addY(y);
            p3.addY(y);
            p4.addY(y);
        }
    }
}
