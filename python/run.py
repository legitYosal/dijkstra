from dijkstra import Node, dijkstra

a = Node('a', 0)
b = Node('b')
d = Node('d')
c = Node('c')
e = Node('e')
f = Node('f')

a.AddEdge(b ,10, f, 1)
b.AddEdge(c,2, d, 3)
c.AddEdge(e,6)
d.AddEdge(e,1)
e.AddEdge(f,1)


dijkstra(a, '')

for node in Node.all:
    node.__str__()
