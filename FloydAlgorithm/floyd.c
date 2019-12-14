// this code edited by hamed from geekforce page: https://www.geeksforgeeks.org/floyd-warshall-algorithm-dp-16/
#include <stdio.h>
#define V 6
int MAX;
/* need to slice path from node V1 -> V2 into using intermediate node K wich means
paths V1 -> K -> V2 if this is shorter than V1 -> V2 then it will change to new distance
the point here is order of iteration if it be V2 then V1 then K it will automaticly find
shortest path with more than * 3 NODES *.*/

void printSol(int A[V][V]);


void floydIT(int A[V][V]){
	int D[V][V];
	for (int k = 0; k < V; k ++)
		for (int j = 0; j < V; j ++)
			D[k][j] = A[k][j];
	
	for (int k = 0; k < V; k ++)
		for (int i = 0; i < V; i ++)
			for (int j = 0; j < V; j ++){
				//if (A[k][j] == MAX) continue;
				//if (A[i][k] == MAX) break;
				if (i == j)         continue;
				if (D[i][k] + D[k][j] < D[i][j])
					D[i][j] = D[i][k] + D[k][j];
			}
	printf("solution is:\n");
	printSol(D);
}

void printSol(int A[V][V]){
	printf("   ");
	for (int i = 0; i < V; i ++)
		printf("%4d ", i);
	printf("\n");
	for (int i = 0; i < V; i ++){
		printf("%2d ", i);
		for (int j = 0; j < V;j ++)
			if (A[i][j] == MAX)
				printf("NONE ");
			else
				printf("%4d ", A[i][j]);
						
		printf("\n");
	}
}

void main(){
	int max = 1;
	for (int i = 1; i < sizeof(int); i ++)
		max = max * 256;
	MAX = max;
	printf("max is: %d\n", MAX);

	int A[V][V];
	for (int i = 0; i < V; i ++)
		for (int j = 0; j < V; j ++)
			if (i == j) A[i][j] = 0;
			else A[i][j] = MAX;
	A[0][3] = 1;
	A[3][4] = 1;
	A[4][2] = 1;
	A[4][5] = 1;
	printf("relations are:\n");
	printSol(A);
	floydIT(A);	
}
