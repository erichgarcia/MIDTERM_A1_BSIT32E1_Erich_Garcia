namespace MIDTERM_A1_BASICAUTH.Middleware
{
    public class BasicAuthMiddleware
    {
        public Task Invoke(HttpContext context)
        {
            var str = context.Request.Path.Value;

            var authorizatonHeader = context.Request.Headers["Authorization"];


            return default;
        }
        public BasicAuthMiddleware(RequestDelegate next)
        {
            
        }
    }
}
