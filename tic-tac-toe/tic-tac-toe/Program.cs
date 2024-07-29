using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program Test = new Program();
            Test.Dozdynamic();
        }
        #region Doz
        public void Dozdynamic()
        {
            int len = 0;
            bool player = false;
            Console.WriteLine("Plase Enter an odd number For the Array ");
            len = Convert.ToInt32(Console.ReadLine());
            string[] ArrayRow = new string[len * len];
            for (int i = 0; i < len * len; i++)
            {
                ArrayRow[i] = (i + 1).ToString();
            }
            ImaginGameDaynamic(ArrayRow, len);
            for (int i = 1; i <= len * len; i++)
            {
                Console.WriteLine("Plase enetr an number cell");
                if (player) { Console.WriteLine("Player 2 "); } else { Console.WriteLine("Player 1"); }
                int key = Convert.ToInt32(Console.ReadLine());
                if (key < (len * len) + 1 && key > 0)
                {
                    if (ArrayRow[key - 1] == "P1" || ArrayRow[key - 1] == "P2")
                    {
                        i--;
                        Console.Clear();
                        ImaginGameDaynamic(ArrayRow, len);
                        continue;
                    }
                    if (!player)
                    {
                        player = true;
                        Console.Clear();
                        ArrayRow[key - 1] = "P1";
                        ImaginGameDaynamic(ArrayRow, len);
                        if (CheckGameDynamic(ArrayRow, len)) { Console.WriteLine("Player 1 Win....."); break; }
                    }
                    else
                    {
                        player = false;
                        Console.Clear();
                        ArrayRow[key - 1] = "P2";
                        ImaginGameDaynamic(ArrayRow, len);
                        if (CheckGameDynamic(ArrayRow, len)) { Console.WriteLine("Player 2 Win....."); break; }
                    }
                }
                else
                {
                    i--;
                    Console.Clear();
                    ImaginGameDaynamic(ArrayRow, len);
                    continue;
                }
            }
            if (!CheckGameDynamic(ArrayRow, len))
            {
                Console.WriteLine("Equal.........");
            }
            Console.ReadLine();
        }
        public void ImaginGameDaynamic(string[] arr, int len)
        {
            Console.WriteLine("player 1 is 'P1' & player 2 is 'P2'");
            Console.WriteLine("------------------------------");
            int start = 0;
            for (int i = 1; i <= len; i++)
            {
                int end = (i * len);

                for (int j = start; j < end; j++)
                {
                    Console.Write("  {0}\t |", arr[j]);
                }
                start += len;
                Console.WriteLine("");
            }

            Console.WriteLine("------------------------------");
            // Console.ReadLine();
        }
        public bool CheckGameDynamic(string[] arr, int len)
        {
            bool Out = false;
            int startrow = 0;
            for (int i = 0; i < len; i++)
            {
                int countRow = 0, countColumn = 0;
                //---------for check row---------
                int end = (i + 1) * len;
                for (int j = startrow; j < end - 1; j++)
                {
                    if (arr[j] == arr[j + 1])
                    {
                        countRow++;
                    }
                }
                //---------for check column-------
                int endcolumn = i + ((len - 1) * len);
                for (int k = i; k < endcolumn; k += len)
                {
                    if (arr[k] == arr[k + len])
                    {
                        countColumn++;
                    }
                }
                //---------check the winer----------
                if ((countRow == len - 1)) { Out = true; return Out; }
                if ((countColumn == len - 1)) { Out = true; return Out; }
                startrow += len;
            }
            return Out;
        }
        #endregion

    }
}
