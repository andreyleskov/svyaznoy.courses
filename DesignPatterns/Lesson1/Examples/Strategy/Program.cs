using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main()
        {
            var fileName = "P:\\1.txt";
            File.AppendAllText(fileName,"sfdsfdsfsdfdsfdf",Encoding.ASCII);
            var compressor = new Compressor("Zip");

            Consume(compressor, fileName);

            Console.ReadKey()
        }

        private static void Consume(Compressor compressor, string fileName)
        {
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(compressor.Compress(fileName)));
        }
    }

    abstract class Compressor
    {
    }

    CompressorZip: Compresor;


    class Compressor
    {
        public Compression Compression { private get;  set; }
        Dictionary<string, Compression> _compressions = new Dictionary<string, Compression>();
        public Compressor(string name)
        {
            _compressions.Add("7Zip", new Zip7Compression());
            _compressions.Add("RAR",  new RARCompression());
            _compressions.Add("Zip",  new ZipCompression());

            this.Compression = _compressions[name];
        }

        public enum CompressionEnum
        {
            Zip,
            Zip7,
            Rar
        }


        public byte[] Compress(string fileName)
        {
            var data = File.ReadAllBytes(fileName);
            return Compression.Compress(data);
        }
    }

    abstract class Compression
    {
        public abstract byte[] Compress(byte[] stream);
    }

    class ZipCompression : Compression
    {
        public override byte[] Compress(byte[] stream)
        {
            return stream.Take(3).ToArray();
        }
    }

    class RARCompression : Compression
    {
        public override byte[] Compress(byte[] stream)
        {
            return stream.Take(5).ToArray();
        }
    }

    class Zip7Compression : Compression
    {
        public override byte[] Compress(byte[] stream)
        {
            return stream.Take(7).ToArray();
        }
    }





}
