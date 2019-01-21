from dijkstra import Node, dijkstra

if __name__=='__main__':
        a = Node('a', 0)
        b = Node('b')
        d = Node('d')
        c = Node('c')
        e = Node('e')
        f = Node('f')

        a.AddEdge(b, 5, c, 1, d, 6)
        b.AddEdge(a, 5, c, 3, e, 6)
        c.AddEdge(a, 1, d, 4, b, 3, e, 8)
        d.AddEdge(a, 6, c, 4, e, 1, f, 2)
        e.AddEdge(b, 6, c, 8, d, 1, f, 7)
        f.AddEdge(d, 2, e, 7)


        dijkstra(a)

        for node in Node.all:
            node.__str__()
