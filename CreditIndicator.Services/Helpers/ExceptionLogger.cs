using System;
using System.IO;

namespace CreditIndicator.Services.Helpers
{
    public class ExceptionLogger
    {
        public void Handle(string error, string executionStatus)
        {
            TextWriter tsw = new StreamWriter(@"D:\ErrorLogs\Error.txt", true);
            tsw.WriteLine(string.Format("-{0}- The following Error Ocuured at {1} while ExecutionStatus = {2} ", DateTime.Now, error, executionStatus));
            tsw.Close();
        }
    }
}
