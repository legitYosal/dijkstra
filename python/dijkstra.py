global Max
Max = 1000
class Node:
        all = []
        def __init__(self, name, value = Max):
            self.all.append(self)
            self.State = True
            self.Value = value
            self.Name = name
            self.Tail = ''
            self.Edge = []
            self.EdgeValue = []
        def AddEdge(self, node, value, *args):
            self.Edge.append(node)
            self.EdgeValue.append(value)
            if (len(args) > 0):
                for arg in args:
                    if type(arg) == Node:
                        self.Edge.append(arg)
                    elif type(arg) == int:
                        self.EdgeValue.append(arg)

        def __str__(self):
            print('name of node: ', self.Name, ', weight of shortest path: ', self.Value, ', path name: ', self.Tail)


def dijkstra(currentNode, tailStr):
        currentNode.State = False
        currentNode.Tail = tailStr + currentNode.Name
        for i in range(0, len(currentNode.Edge)):
            if currentNode.Edge[i].State:
                currentNode.Edge[i].Value = min(currentNode.Edge[i].Value, currentNode.Value + currentNode.EdgeValue[i])
        Min = Max
        nextNode = None
        for node in Node.all:
            if node.State and node.Value < Min:
                Min = node.Value
                nextNode = node
        if not nextNode == None:
            Min = Max
            tailNode = None
            for node in Node.all:
                if not node.State and nextNode in node.Edge and node.Value < Min:
                    Min = node.Value
                    tailNode = node

            dijkstra(nextNode, tailNode.Tail)
