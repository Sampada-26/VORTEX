using UnityEngine;
using System.Collections.Generic;

namespace AStar
{

    public class AStar
    {
        // tweaking parameter for optimality
        public static float optimality;


        public static Point FindPath(TileGrid grid, Point start, Bounds end)
        {
            Node startNode = grid.nodes[start.x, start.y];
            Node endNode = grid.nodes[(int)end.center.x, (int)end.center.y];

            List<Node> open = new List<Node>();
            HashSet<Node> closed = new HashSet<Node>();
            open.Add(startNode);

            while (open.Count > 0)
            {
                Node currentNode = open[0];
                for (int i = 1; i < open.Count; i++)
                {
                    if (f(open[i]) < f(currentNode) || f(open[i]) == f(currentNode) && open[i].h < currentNode.h)
                    {
                        currentNode = open[i];
                    }
                }

                open.Remove(currentNode);
                closed.Add(currentNode);

                if (end.Contains(new Vector2(currentNode.x, currentNode.y)))
                {
                    return GetDirection(startNode, currentNode);
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.free || closed.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.g + GetHeuristic(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.g || !open.Contains(neighbour))
                    {
                        neighbour.g = newMovementCostToNeighbour;
                        neighbour.h = GetHeuristic(neighbour, endNode);
                        neighbour.parent = currentNode;

                        if (!open.Contains(neighbour))
                            open.Add(neighbour);
                    }
                }
            }

            return null;
        }

        private static Point GetDirection(Node startNode, Node endNode)
        {
            Node currentNode = endNode;
            if (currentNode == startNode) {
                return new Point(currentNode.x, currentNode.y);
            }
            while (currentNode.parent != startNode)
            {
                currentNode = currentNode.parent;
            }
            return new Point(currentNode.x, currentNode.y);

        }

        private static int GetHeuristic(Node nodeA, Node nodeB)
        {
            int xDist = Mathf.Abs(nodeA.x - nodeB.x);
            int yDist = Mathf.Abs(nodeA.y - nodeB.y);

            if (xDist > yDist)
                return 14 * yDist + 10 * (xDist - yDist);
            return 14 * xDist + 10 * (yDist - xDist);

        }

        private static int f(Node n) {
            return (int)optimality * n.g + n.h;
        }
    }

}