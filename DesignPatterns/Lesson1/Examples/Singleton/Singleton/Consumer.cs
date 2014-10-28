using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Consumer
    {
        public string DoMajorTask()
        {
            if (Settings.Instance.MeetingRoom == "first")
                return "going to first floor";
            else
                return "going to second floor";
        }
    }
}
