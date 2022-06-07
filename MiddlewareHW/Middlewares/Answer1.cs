using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareHW.Middlewares
{
    public class Answer1Middleware1
    {
        private readonly RequestDelegate next;

        public Answer1Middleware1( RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var classNum = GetClassNumber(context);
            if(classNum==-1)
            {
                await next(context);
                return;
            }
            Console.WriteLine(classNum);
            await next(context);
        }

        public static int GetClassNumber(HttpContext context)
        {
            int classNum = -1;

            var values = GetValues(context.Request.Path);
            var indexOfStudents = GetIndexOfStudentsValue(values);
            if (indexOfStudents == -1)
            {
                return -1;
            }
            if (values.Length > indexOfStudents + 1)
            {
                if (int.TryParse(values[indexOfStudents + 1], out classNum) == false)
                {
                    return -1;
                }
            }
            else
                return -1;
            return classNum;
        }
        public static string[] GetValues(PathString path)
        {
            return path.Value.Split('/');
        }

        public static int GetIndexOfStudentsValue(string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                    if (values[i] =="students")
                        return i;
            }
            return -1;
        }
    }
    public class Answer1Middleware2
    {
        private readonly RequestDelegate next;

        public Answer1Middleware2(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            int studentid = -1;
            
            var values = Answer1Middleware1.GetValues(context.Request.Path);
            var studentId = Answer1Middleware1.GetIndexOfStudentsValue(values);

            if (studentId == -1)
            {
                await next(context);
                return;
            }

            //looks for the second value
            if (values.Length > studentId + 2)
            {
                if (int.TryParse(values[studentId + 2], out studentid) == false)
                {
                    await next(context);
                    return;
                }
            }
            else
            {
                await next(context);
                return;
            }


            Console.WriteLine(studentid);
            await next(context);
        }
    }
}
