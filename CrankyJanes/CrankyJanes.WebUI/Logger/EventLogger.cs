using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CrankyJanes.WebUI.Logger
{
    
    public class EventLogger
    {
        List<Event> events;
        
        EventLogger()
        {
            events = new List<Logger.Event>();
        }

        public void log(Logger.Event eventToLog)
        {
            events.Add(eventToLog);
            write(eventToLog);
            
        }

        public void write(Logger.Event eventToLog)
        {
            List<string> filesToWrite = new List<string>();
            switch (eventToLog.level)
            {
                case Logger.LogLevel.Error:
                    filesToWrite.Add("error.log");
                    break;
                case Logger.LogLevel.Warning:
                    filesToWrite.Add("warning.log");
                    break;
                case Logger.LogLevel.Information:
                    filesToWrite.Add("info.log");
                    break;
                case Logger.LogLevel.Debug:
                    filesToWrite.Add("debug.log");
                    break;
                default:
                    {
                        break;
                    }
            }
            foreach(string file in filesToWrite)
            {
                using (StreamWriter outfile = new StreamWriter("debug.log"))
                {
                    outfile.Write(eventToLog.ToString());
                    break;
                }
            }

             using (StreamWriter outfile = new StreamWriter("debug.log"))
                    {
                        outfile.Write(eventToLog.ToString());
                    }
        }
    }
}