using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SettingsSingletonWrap : ISettings
    {
        private readonly Settings _singleton;

        public SettingsSingletonWrap(Settings singleton)
        {
            this._singleton = singleton;
        }

        public string MeetingRoom
        {
            get
            {
                return _singleton.MeetingRoom;
            }
        }
    }

    public class Consumer
    {
        private ISettings _settings;
        public Consumer(ISettings settings)
        {
            _settings = settings;
        }
        public string DoMajorTask()
        {
            if (_settings.MeetingRoom == "first")
                return "going to first floor";
            else
                return "going to second floor";
        }
    }
}
