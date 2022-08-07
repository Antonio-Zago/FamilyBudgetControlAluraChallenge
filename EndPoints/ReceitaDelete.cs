using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints
{
    public static class ReceitaDelete
    {
        public static string Template => "/receitas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context) 
        {
            var receita = context.Receitas.Where(r => r.Id == id).FirstOrDefault();

            if (receita == null)
                return Results.NotFound();

            context.Receitas.Remove(receita);

            context.SaveChanges();

            return Results.Ok();
        }
    }
}
