namespace AStar
{
    public class Node
    {
        // node starting params
        public bool free;
        public int x;
        public int y;

        // calculated values while finding path
        public int g;
        public int h;
        public Node parent;

        public Node(bool free, int x, int y)
        {
            this.free = free;
            this.x = x;
            this.y = y;
        }

        public int f
        {
            get
            {
                return g + h;
            }
        }
    }
}