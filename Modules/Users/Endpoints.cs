using Carter;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Modules.Users
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/api/v1/users");

            users.MapGet("", () => Collections.Users);

            users.MapGet("/{id:int}",  (HttpContext context, int id) =>
            {
                var userResult = Collections.Users.FirstOrDefault(user => user.Id == id);
                if (userResult == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Response.WriteAsync("Usuário não encontrado");
                    return;
                }

                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.WriteAsJsonAsync(userResult);
            });


            users.MapPost("", (User user) => Collections.Users.Add(user));

            users.MapPut("/{id}", (int id, User user) =>
            {
                User currentUser = Collections.Users.FirstOrDefault(user => user.Id == id);

                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.BirthDate = user.BirthDate;
            });

            users.MapDelete("/{id}", (int id) =>
            {
                var userForDeletion = Collections.Users.FirstOrDefault(user => user.Id == id);

                Collections.Users.Remove(userForDeletion);
            });
        }
    }
}
