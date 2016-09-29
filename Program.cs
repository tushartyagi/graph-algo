using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Graphs.Data;
using Graphs.Algorithms;

namespace Graphs
{
    public class Program
    {
        private static int _timeStamp = 0;

        public static int CurrentTimeStamp() {
            _timeStamp += 1;  // Tick
            return _timeStamp;
        }

        public static void PostProcess(Vertex v) {
            Console.Write("Visited vertex: {0}.", v.Name);
            Console.WriteLine("Timestamp: {0}/{1}", v.StartTime, v.StopTime);
        }
        public static void PreProcess(Vertex v) {
            Console.Write("Visiting vertex: {0}.", v.Name);
            Console.WriteLine("Timestamp: {0}/{1}", v.StartTime, v.StopTime);
        }
        public static void Main(string[] args)
        {
            Graph graph = new UndirectedAdjListGraph();
            Vertex a = new Vertex("a"),
                b = new Vertex("b"),
                c = new Vertex("c"),
                d = new Vertex("d"),
                e = new Vertex("e"),
                f = new Vertex("f"),
                g = new Vertex("g");

            Edge ab = new Edge(a, b),
                bc = new Edge(b, c),
                ad = new Edge(a, d),
                de = new Edge(d, e),
                ce = new Edge(c, e),
                fg = new Edge(f, g);

            graph.Add(ab)
            .Add(bc)
            .Add(ad)
            .Add(de)
            .Add(ce)
            .Add(fg);

            
            var dfs = new DFS(graph);
            dfs.PreExploredVertexDelegate += PreProcess;
            dfs.PostExploredVertexDelegate += PostProcess;
            dfs.Start();
            
        }
    }
}
