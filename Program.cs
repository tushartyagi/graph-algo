using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tushartyagi.graphs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Graph g = new AdjListGraph();
            Vertex a = new Vertex("a"),
                b = new Vertex("b"),
                c = new Vertex("c"),
                d = new Vertex("d"),
                e = new Vertex("e");

            Edge ab = new Edge(a, b),
                bc = new Edge(b, c),
                ad = new Edge(a, d),
                de = new Edge(d, e),
                ce = new Edge(c, e);

            g.Add(ab)
            .Add(bc)
            .Add(ad)
            .Add(de)
            .Add(ce);

            DFS.Search(g, a);

            System.Console.WriteLine("Done");
        }
    }
}
