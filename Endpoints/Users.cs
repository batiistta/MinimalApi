using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Endpoints
{
    public  static class Users
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/v1/users");

            users.MapGet("/buscarUsuarios", async (DataContext db) =>
            {
                try
                {
                   var usersResult =await db.Users.ToListAsync();

                   return Results.Ok(usersResult);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao buscar usuários. " + ex.Message);
                }
            });

            users.MapGet("/{id}", async (int id, DataContext db) =>
            {
                try
                {
                    var userResult = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
                    return Results.Ok(userResult);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao buscar usuário. " + ex.Message);
                }
            });

            users.MapPost("/salvarUsuario", async (User user, DataContext db) =>
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    return Results.Created($"/api/v1/users/{user.Id}", user);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao criar usuário. " + ex.Message);
                }                
            });

            users.MapPut("/{id}", async (int id, User userInput, DataContext db) =>
            {
                try
                {
                    var currentUser = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

                    if (currentUser == null)
                    {
                        throw new Exception(Results.NotFound().ToString());
                    }

                    currentUser.FirstName = userInput.FirstName;
                    currentUser.LastName = userInput.LastName;
                    currentUser.BirthDate = userInput.BirthDate;

                    await db.SaveChangesAsync();

                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao atualizar usuário. " + ex.Message);
                }
                
            });

            users.MapDelete("/{id}", (int id, DataContext db) =>
            {
                try
                {
                    var userForDeletion = db.Users.FirstOrDefault(u => u.Id == id);

                    if (userForDeletion == null)
                    {
                        throw new Exception(Results.NotFound().ToString());
                    }
                    db.Users.Remove(userForDeletion);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao deletar usuário. "  + ex.Message);
                }
                
            });
        }
    }
}
