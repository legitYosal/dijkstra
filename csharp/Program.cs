using System.Collections.Generic;
using System;
using System.Collections;

namespace Dijkstra
{
    public class Vertex
    {
        public bool State { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        public string Tail = "";

        public List<Vertex> Adjacents = new List<Vertex>();
        public List<int> AdjacentsValues = new List<int>();
        public static List<Vertex> All = new List<Vertex>();

        public Vertex(string text, int value = 10000)
        {
            State = true;
            Value = value;
            All.Add(this);
            Name = text;

            if (value == 0)
                Tail += Name;
        }
        public void AddAdjacent(Vertex adj , int val)
        {
            Adjacents.Add(adj);
            AdjacentsValues.Add(val);
        }
    }

    public class Test
    {
        public void Dijkstra2(Vertex start,Vertex final)
        {
            start.State = false;

            for (int i = 0 ; i < start.Adjacents.Count; i++)   //  updating values of all the adjacent vertexes 
            {
                if((start.Value + start.AdjacentsValues[i] < start.Adjacents[i].Value) && start.Adjacents[i].State)  //  check to see if the value of the specific adjacent vertex can be updated
                {
                    start.Adjacents[i].Value = start.Value + start.AdjacentsValues[i];
                    start.Adjacents[i].Tail = start.Tail + start.Adjacents[i].Name;
                }
            }

            int min = 10000;

            for(int j = 0; j < Vertex.All.Count ; j++)
            {
                if(Vertex.All[j].State && Vertex.All[j].Value != 10000)   //  checking all the valid vertexes
                {
                    if(Vertex.All[j].Value <= min)  // selecting the vertex of the minimum value
                    {
                        min = Vertex.All[j].Value;   //  minimization
                    }
                }
            }
            
            Vertex next = Vertex.All.Find(n => n.Value == min && n.State);
 
            if(start.Name != final.Name)
                Dijkstra2(next, final);
            else
                Console.WriteLine("Shortest Path : " + start.Tail + "\n" + "Shortest Weight : " + start.Value);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Vertex a = new Vertex("a" ,0);
            Vertex b = new Vertex("b");
            Vertex c = new Vertex("c");
            Vertex d = new Vertex("d");
            Vertex e = new Vertex("e");
            Vertex f = new Vertex("f");

            a.AddAdjacent(b, 5);
            a.AddAdjacent(c, 1);
            a.AddAdjacent(d, 6);

            b.AddAdjacent(a, 5);
            b.AddAdjacent(c, 3);
            b.AddAdjacent(e, 6);

            c.AddAdjacent(a, 1);
            c.AddAdjacent(d, 4);
            c.AddAdjacent(b, 3);
            c.AddAdjacent(e, 8);

            d.AddAdjacent(a, 6);
            d.AddAdjacent(c, 4);
            d.AddAdjacent(e, 1);
            d.AddAdjacent(f, 2);

            e.AddAdjacent(b, 6);
            e.AddAdjacent(c, 8);
            e.AddAdjacent(d, 1);
            e.AddAdjacent(f, 7);

            f.AddAdjacent(d, 2);
            f.AddAdjacent(e, 7);

            Test test = new Test();
            test.Dijkstra2(a, f);

            Console.ReadKey();
        }
    }
}
