using System;
using System.Collections.Generic;
using System.Text;

namespace Backjun
{
    public class Backjun2839
    {
        public int Solution()
        {
            int anwser = -1;
            string sNum = Console.ReadLine();
            int n = int.Parse(sNum);

            if(n % 5 == 0)
            {
                anwser = n / 5;
            }
            else
            {
                int cnt = 1;
                while(cnt * 3 < n)
                {
                    if((n - cnt * 3) % 5== 0)
                    {
                        break;
                    }
                    cnt++;
                }

                if(cnt * 3 < n)
                {
                    anwser = ( n -cnt*3) / 5;
                    int n2 = cnt * 3 ;

                    anwser += n2 / 3;
                    
                }
                else
                {
                    if(n % 3 == 0)
                    {
                        anwser = n / 3;
                    }
                }
            }
            Console.WriteLine(anwser);
            return anwser;
        }
    }
}
