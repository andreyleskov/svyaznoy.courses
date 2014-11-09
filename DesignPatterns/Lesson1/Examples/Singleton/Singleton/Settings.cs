using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface ISettings
    {
        string MeetingRoom { get; }
    }

    public class Settings
    {
        private static Settings _instance;// = new Settings();
        private Settings()
        {
        }

        public static Settings Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Settings();
                return _instance;
            }
        }

        public string MeetingRoom;

        public override string ToString()
        {
            return "Singleton hash: " + this.GetHashCode();
        }
    }
}
