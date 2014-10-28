using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Settings
    {
        public static readonly Settings Instance = new Settings();
        private Settings()
        {
        }

        public string MeetingRoom;

        public override string ToString()
        {
            return "Singleton hash: " + this.GetHashCode();
        }
    }
}
