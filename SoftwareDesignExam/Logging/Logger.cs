using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Logging
{
    public class Logger
    {
        private static Logger _instance;
        private List<String> _logMessages;

        private Logger() 
        { 
            _logMessages = new List<String>();
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
                _instance = new Logger();

            return _instance;
        }

        public void Log(String message)
        {
            
            _logMessages.Add(message);
        }
        // Save to the database
        public List<String> GetLogs()
        {
            return _logMessages;
        }

    }
}
