using Carter;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Modules.Users
{
    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/api/v1/users");

            users.MapGet("/buscarUsuarios", async (DataContext db) =>
            {
                try
                {
                    var usersResult = await db.Users.ToListAsync();

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
                    if (userResult == null)
                    {
                        return Results.NotFound("Usuário não encontrado.");
                    }   
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
                        return Results.NotFound("Usuário não encontrado.");
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
                        return Results.NotFound();
                    }
                    db.Users.Remove(userForDeletion);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest("Erro ao deletar usuário. " + ex.Message);
                }

            });
        }
    }
}
