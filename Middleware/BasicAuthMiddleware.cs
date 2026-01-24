using MIDTERM_A1_BASICAUTH.Data;
using System.Text;

namespace MIDTERM_A1_BASICAUTH.Middleware
{
    public class BasicAuthMiddleware
    {
        public async Task Invoke(HttpContext context, BasicAuthDBContext dbContext)
        {
            var str = context.Request.Path.Value;

            var authorizatonHeader = context.Request.Headers["Authorization"];
            var header = authorizatonHeader.FirstOrDefault().Replace("Basic ", "");
            var base64EncodedBytes = Encoding.UTF8.GetString(Convert.FromBase64String(header));
            var userName = base64EncodedBytes.Split(":")[0];
            var password = base64EncodedBytes.Split(":")[1];

            //search for a user with same user name and password
            //if null return bad request
            var user = dbContext.Users
                .FirstOrDefault(u => u.username == userName && u.password == password);

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid username or password");
                return;
            }

            await _next(context);

            dbContext.Users.FirstOrDefault(u => u.username == userName && u.password == password);
        }

        private readonly RequestDelegate _next;
        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    }
}
