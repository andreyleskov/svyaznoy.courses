using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    using System.Security.Policy;

    class Program
    {
        static void Main(string[] args)
        {
            var ex = new MyClass();

            try
            {
                ex.ThrowException();
            }
            catch(Exception e)
            {
                System.Reflection.MemberInfo info = e.TargetSite.DeclaringType;
                var attribute = (HelpAttribute)info.GetCustomAttributes(typeof(HelpAttribute), false)[0];
                
                Console.WriteLine("Error. Go to " + attribute.Url + " for topic: " + attribute.Topic);
            }
            Console.ReadKey();
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class HelpAttribute : System.Attribute
    {
        public readonly string Url;

        public string Topic               // Topic is a named parameter
        {
            get
            {
                return topic;
            }
            set
            {

                topic = value;
            }
        }

        public HelpAttribute(string url)  // url is a positional parameter
        {
            this.Url = url;
        }

        private string topic;
    }

    [HelpAttribute("http://msdn.microsoft.com/en-us/library/aa288454(v=vs.71).aspx",Topic = "123")]
    class MyClass
    {
        public void ThrowException()
        {
            throw new NotImplementedException();
        }
    }
}
