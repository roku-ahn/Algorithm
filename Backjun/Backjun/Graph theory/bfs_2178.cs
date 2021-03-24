using System;
using System.Collections.Generic;
using System.Text;

namespace Backjun.Backjun.Graph_theory
{
    class _2178
    {
        int[,] map;
        int[,] check;
        int n,m;
        int[,] dir = {{1,0}, {-1,0}, {0,1}, {0,-1}}; //up, down, left, right check.

        public int Solution()
        {

            string text = Console.ReadLine();
            string[] splitText = text.Split(" ");
            n = int.Parse(splitText[0]);
            m = int.Parse(splitText[1]);
            map = new int[n,m];
            check = new int[n,m];            
            
            for(int i =0; i<n; i++)
            {
                text = Console.ReadLine();
                
                for (int j =0; j< m; j++)
                {
                    map[i, j] = int.Parse(text[j].ToString());
                }
            }
            int anwser = BFS();
            Console.WriteLine(anwser);

            for (int i = 0; i < n; i++)
            {          
                for (int j = 0; j < m; j++)
                {
                    Console.Write(check[i, j] + " ");
                }
                Console.WriteLine();
            }
            return anwser;

        }
        bool isInside(int a, int b)
        {
            return (a >= 0 && a < n) && (b >= 0 && b < m);
        }

        int BFS()
        {
            int cur_x = 0, cur_y = 0;
            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            //첫 시작 부분
            q.Enqueue(KeyValuePair.Create(cur_x, cur_y));
            //최단거리 1
            check[cur_x, cur_y] = 1;

            //bfs용 que
            //check = 간 경로 체크, 방문값
            while (q.Count != 0)
            {
                var key = q.Dequeue();
                cur_x = key.Key;
                cur_y = key.Value;

                //위 아래, 왼쪽 ,오른쪽 체크
                for (int i =0; i<4; i++)
                {
                    int next_x = cur_x + dir[i, 0];
                    int next_y = cur_y + dir[i,1];
                    
                    if(isInside(next_x, next_y) )
                    {
                        if (check[next_x, next_y] == 0 && map[next_x, next_y] == 1)
                        {
                            check[next_x, next_y] = check[cur_x, cur_y] + 1; //이전 방문값 + 1 = 다음 방문
                            q.Enqueue(KeyValuePair.Create(next_x, next_y)); //방문한 곳 push push
                        }

                    }
                }
            }
            return check[n - 1,m - 1];
        }
    }
}
