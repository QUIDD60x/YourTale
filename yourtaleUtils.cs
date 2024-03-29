﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace yourtale
{
    public static class yourtaleUtils
    {
        internal static ILog Logger = LogManager.GetLogger("yourtaleUtils");

        public static void Log(string message)
        {
            Logger.Debug("[yourtale] " + message);
        }

        public static void Log(object message, params object[] formatData)
        {
            Log(string.Format(message.ToString(), formatData));
        }
    }
}