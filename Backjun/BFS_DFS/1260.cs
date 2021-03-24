using System;
using System.Collections.Generic;
using System.Text;

namespace Backjun.BFS_DFS
{
    class Baekjoon1260
    {
        Dictionary<int ,List<int>> graph = new Dictionary<int ,List<int>>();
        List<int> visite = new List<int>();
        int n, m, v;
        public void Solution()
        {
            string text = Console.ReadLine();
            string[] splitText = text.Split(" ");

            n = int.Parse(splitText[0]);
            m = int.Parse(splitText[1]);
            v = int.Parse(splitText[2]);

            for(int i =0; i< m; i++)
            {
                text = Console.ReadLine();
                splitText = text.Split(" ");

                int num1 = int.Parse(splitText[0]);
                int num2 = int.Parse(splitText[1]);

                if(graph.ContainsKey(num1))
                {
                    graph[num1].Add(num2);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(num2);

                    graph.Add(num1,list);
                }

                if (graph.ContainsKey(num2))
                {
                    graph[num2].Add(num1);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(num1);

                    graph.Add(num2, list);
                }
            }

            DFS(v);
            Console.WriteLine();
            visite.Clear();
            BFS(v);
        }
        //DFS는 재귀함수를 이용해서 
        
        public void DFS(int v)
        {
            Console.Write (v + " ");
            visite.Add(v); //방문한 곳은 체크

            var li = graph[v];
            li.Sort();
            foreach(int n in li)
            {
                if(!visite.Contains(n))
                {
                    DFS(n);
                }
            }

        }
        //BFS는 Que를 이용해서 한다.
        public void BFS(int v)
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(v);


            while (que.Count > 0)
            {
                int n = que.Dequeue();
                Console.Write (n + " ");
                visite.Add(n);//방문한 곳은 체크

                var li = graph[n];
                li.Sort();
                for (int i = 0; i < li.Count; i++)
                {
                    if (!visite.Contains(li[i]))
                    {
                        que.Enqueue(li[i]);
                        visite.Add(li[i]);

                    }
                }


            }
        }
    }
}
