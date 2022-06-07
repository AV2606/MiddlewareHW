using Microsoft.AspNetCore.Builder;

namespace MiddlewareHW.Middlewares
{
    public static class Answer2
    {
        public static void UseClassesMW(this IApplicationBuilder me)
        {
            me.UseMiddleware<Answer1Middleware1>();
        }
        public static void UseStudentsMW(this IApplicationBuilder me)
        {
            me.UseMiddleware<Answer1Middleware2>();
        }

    }
}
