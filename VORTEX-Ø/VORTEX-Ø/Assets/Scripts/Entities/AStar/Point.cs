
namespace AStar
{
    /**
    * A 2d point on the grid
    */
    public class Point
    {
        public int x;
        public int y;

        public Point(int iX, int iY)
        {
            this.x = iX;
            this.y = iY;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public override bool Equals(System.Object obj)
        {
            Point p = (Point)obj;

            if (ReferenceEquals(null, p))
            {
                return false;
            }
            return (x == p.x) && (y == p.y);
        }

        public bool Equals(Point p)
        {
            if (ReferenceEquals(null, p))
            {
                return false;
            }
            return (x == p.x) && (y == p.y);
        }

        public static bool operator ==(Point a, Point b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (ReferenceEquals(null, a))
            {
                return false;
            }
            if (ReferenceEquals(null, b))
            {
                return false;
            }
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}
