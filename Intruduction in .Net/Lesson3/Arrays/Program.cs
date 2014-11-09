using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single-dimensional array (numbers).
            int[] n1 = new int[4] { 2, 4, 6, 8 };
            int[] n2 = new int[] { 2, 4, 6, 8 };
            int[] n3 = { 2, 4, 6, 8 };
            // Single-dimensional array (strings).
            string[] s1 = new string[3] { "John", "Paul", "Mary" };
            string[] s2 = new string[] { "John", "Paul", "Mary" };
            string[] s3 = { "John", "Paul", "Mary" };

            // Multidimensional array.
            int[,] n4 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] n5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] n6 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            // Jagged array.
            int[][] n7 = new int[2][] { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };
            int[][] n8 = new int[][] { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };
            int[][] n9 = { new int[] { 2, 4, 6 }, new int[] { 1, 3, 5, 7, 9 } };

            Console.WriteLine("Single-dimensional array");
            foreach (int i in n1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");

            Console.WriteLine("Multidimensional array - fixed size at all dimensions + linear elements");
            foreach (int elem in n6)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine("");

            Console.WriteLine("Multidimensional array - grouping elements");
            for(int i = 0; i < n6.GetLength(0);  i ++  )
            {
                Console.WriteLine("dimension " + i);
                for(int j =0; j < n6.GetLength(1); j ++ )
                    Console.Write(n6[i,j] + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("");

            Console.WriteLine("Jagged array - initial grouping");
            foreach(int[] array in n9)
            {
                Console.WriteLine("new array");
                foreach (int elem in array)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
