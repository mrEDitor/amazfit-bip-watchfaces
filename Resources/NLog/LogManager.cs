using System;

namespace NLog
{
    namespace Internal
    {
        class Dummy { }
    }

    public static class LogManager
    {
        public static Logger GetCurrentClassLogger() => new Logger();
    }

    public class Logger
    {
        public void Fatal(Exception e, string message = "Fatal error!", params object[] args)
        {
            Console.WriteLine(message, args);
            Console.WriteLine(e);
        }

        public void Warn(Exception e, string message, params object[] args)
        {
            Console.WriteLine(message, args);
            Console.WriteLine(e);
        }

        public void Warn(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Info(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Debug(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Trace(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Trace(Func<string> messageFactory, params object[] args)
        {
            Console.WriteLine(messageFactory(), args);
        }
    }
}