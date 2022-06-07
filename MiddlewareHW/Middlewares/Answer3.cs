using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MiddlewareHW.Middlewares
{
    public class Answer3Middleware
    {
        private readonly RequestDelegate next;

        public Answer3Middleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Handled class number 5");
        }
    }
}
