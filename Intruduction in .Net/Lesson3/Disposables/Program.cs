using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposables
{
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    class Program
    {
        static void Main(string[] args)
        {
            //IWriteDestination[] destinations = { new ConsoleDestination(), new FileDestination("output.txt") };

            using (IWriteDestination dst = new ConsoleDestination())
            {
                dst.WriteLine("example text");
            }

            using (IWriteDestination dst = new FileDestination("output.txt"))
            {
                dst.WriteLine("example text");
            }

            IWriteDestination dst2 = new FileDestination("output.txt");

            try
            {
                dst2.WriteLine("");
            }
            finally
            {
                if(dst2 != null)
                    ((IDisposable)dst2).Dispose();
            }

            Console.ReadKey();
        }


        interface IWriteDestination : IDisposable
        {
            void WriteLine(string line);
        }

        class ConsoleDestination : IWriteDestination
        {
            public void Dispose()
            {
                
            }

            public void WriteLine(string line)
            {
                Console.WriteLine(line);
            }
        }

        class FileDestination : IWriteDestination
        {
            private FileStream _fileStream;

            public FileDestination(string fileName)
            {
                this._fileStream = File.OpenWrite(fileName);
            }

            public void Dispose()
            {
                _fileStream.Flush();
                _fileStream.Dispose();
            }

            public void WriteLine(string line)
            {
                byte[] data = Encoding.UTF8.GetBytes(line);
                _fileStream.Write(data,0, data.Length);
            }
        }
    }
}
