using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            System.IO.FileStream file = null;
            System.IO.FileInfo fileinfo = new System.IO.FileInfo("C:\\file.txt");
            try
            {
                file = fileinfo.OpenWrite();
                file.WriteByte(0xF);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("file not found");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("in catch block");
                Console.WriteLine(e.Message);
                Console.WriteLine("Details:");
                Console.WriteLine(e);
            }
            finally
            {
                // Check for null because OpenWrite might have failed. 
                if (file != null)
                {
                    file.Close();
                }
            }

            Console.WriteLine();
            Console.Read();
        }


    }
}
