using Cw6.DAL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw6.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        const string DEF_LOG_FILE_PATH = " requestsLog.txt";

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            if (httpContext.Request != null)
            {
                string sciezka = httpContext.Request.Path; 
                string querystring = httpContext.Request?.QueryString.ToString();
                string metoda = httpContext.Request.Method.ToString();
                string bodyStr = "";

                using (StreamReader reader
                 = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    httpContext.Request.Body.Position = 0; 
                }

                using (System.IO.StreamWriter logFile =
                   new System.IO.StreamWriter(DEF_LOG_FILE_PATH, true))
                 {
                    String timeStamp = DateTime.Now.ToString();
                    logFile.WriteLine(timeStamp + ": " );
                    logFile.WriteLine(sciezka);
                    logFile.WriteLine(querystring);
                    logFile.WriteLine(metoda);
                    logFile.WriteLine(bodyStr);
                }
                
            }

            await _next(httpContext);
        }
    }
}
