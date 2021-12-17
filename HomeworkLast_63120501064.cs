using System;

namespace HomeworkLast
{
    class Program
    {
        static void BuildMapFromGraph(ref Graph teamGraph)
        {

            static void FillDirection(ref Node root)
            {
                if (root == null)
                {
                    return;
                }

                if (root.Left != null)
                {
                    FillDirection(ref root.Left);
                }
                if (root.Right != null)
                {
                    FillDirection(ref root.Right);
                }

                if (root.Name == "")
                {
                    root.Name = Console.ReadLine();
                }
            }

            static int GetDirection(ref Node root, int maxDepth)
            {
                if (root == null)
                {
                    return maxDepth;
                }
                else
                {
                    int leftMaxDepth = GetDirection(ref root.Left, maxDepth + 1);
                    int rightMaxDepth = GetDirection(ref root.Right, maxDepth + 1);
                    return leftMaxDepth > rightMaxDepth ? leftMaxDepth : rightMaxDepth;
                }
            }

            static int MapDirection(ref Node root, int distance, int depth)
            {
                int location = 0;

                if (root.Left == null || root.Right == null)
                {
                    return location;
                }

                if (root.Left != null)
                {
                    location += MapDirection(ref root.Left, distance, depth + 1);
                }
                if (root.Right != null)
                {
                    location += MapDirection(ref root.Right, distance, depth + 1);
                }

                Console.WriteLine("Where your location? {0} or {1}", root.Left.Name, root.Right.Name);
                string mapDirectionName = Console.ReadLine();
                if (mapDirectionName == root.Name)
                {
                    location += distance - depth;
                }

                return location;
            }

            static void Main(string[] args)
            {
                Graph inputDirectionName = new Graph();

                int locationCount = int.Parse(Console.ReadLine());
                string inputDirectionName;
                for (int i = 0; i < locationCount; i++)
                {
                    inputDirectionName = Console.ReadLine();
                    Node CityNode = new Node(inputDirectionName);
                    inputDirectionName.Push(CityNode);
                }

                BuildWayFromGraph(ref inputDirectionName);
            }
        }
    }
}