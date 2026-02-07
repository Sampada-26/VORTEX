using UnityEngine;
using System.Collections.Generic;

namespace AStar
{
    public class TileGrid
    {
        public Node[,] nodes;
        int gridsize_x, gridsize_y;


        public TileGrid(int width, int height, bool[,] tiles)
        {
            gridsize_x = width;
            gridsize_y = height;
            nodes = new Node[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    nodes[x, y] = new Node(tiles[x, y], x, y);
                }
            }
        }

        // Find neigbors to all nodes
        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int temp_x = node.x + x;
                    int temp_y = node.y + y;

                    if (temp_x >= 0 && temp_x < gridsize_x && temp_y >= 0 && temp_y < gridsize_y)
                    {
                        neighbours.Add(nodes[temp_x, temp_y]);
                    }
                }
            }

            return neighbours;
        }
    }
}