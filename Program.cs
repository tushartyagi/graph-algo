using System;
using Graphs.Structures;
using System.Collections.Generic;
using Graphs.Algorithms;
using Data.Structures;

namespace Graphs
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /*
            Graph graph = new UndirectedAdjListGraph();
            Vertex a = new Vertex("a"),
                b = new Vertex("b"),
                c = new Vertex("c"),
                d = new Vertex("d"),
                e = new Vertex("e"),
                f = new Vertex("f"),
                g = new Vertex("g"),
                h = new Vertex("h"),
                i = new Vertex("i"),
                s = new Vertex("s");
*/
/*
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
*/
            /* 
            //Edges for DFS
            Edge ab = new Edge(a, b),
                ae = new Edge(a, e),    
                bc = new Edge(b, c),
                bd = new Edge(b, d),
                ca = new Edge(c, a),
                fg = new Edge(f, g),
                fa = new Edge(f, a),
                id = new Edge(i, d),
                hi = new Edge(h, i),
                hc = new Edge(h, c),
                hg = new Edge(h, g),
                gh = new Edge(g, h),
                ec = new Edge(e, c);

            graph.Add(new List<Edge>{ab,ae,bc,bd,ca,fg,fa,id,hi,hc,hg,gh,ec});
            */

/*
            // Edges for BFS
            Edge sa = new Edge(s, a),
                ab = new Edge(a, b),
                sc = new Edge(s, c),
                bc = new Edge(b, c),
                bg = new Edge(b, g),
                bh = new Edge(b, h),
                gh = new Edge(g, h),
                fg = new Edge(f, g),
                df = new Edge(d, f),
                ed = new Edge(e, d),
                es = new Edge(e, s),
                ds = new Edge(d, s);

            graph.Add(new List<Edge>{sa, ab, sc, bc, bg, bh, gh, fg, df, ed, es, ds});
*/
            /*
            var dfs = new DFS(graph);
            dfs.PreExploredVertexDelegate += PreProcess;
            dfs.PostExploredVertexDelegate += PostProcess;
            dfs.Start();
            */

            /*
            var sort = new TopologicalSort(graph);
            List<Vertex> vertices = sort.Sort().ToList();
            foreach (var v in vertices) {
                Console.WriteLine("Name: {0}, Start: {1}, End: {2}", v.Name, v.StartTime, v.StopTime);
            }
            */

            /*
            var cc = ConnectedComponent.CountComponents(graph);
            Console.WriteLine(cc);
            */

            //var components = graph.ConnectedComponents();
            
            /*
            var BFS = new BFS(graph);
            BFS.Start(s);
            */

            var list = new List<PQNode<int>>{
                new PQNode<int>(18, 18),
                new PQNode<int>(16, 16),
                new PQNode<int>(12, 12),
                new PQNode<int>(6, 6),
            };

            var q = new PriorityQueue<PQNode<int>>(list);

        }
    }
}
