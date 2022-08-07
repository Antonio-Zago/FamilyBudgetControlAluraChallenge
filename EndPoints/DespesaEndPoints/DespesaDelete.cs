using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public class DespesaDelete
    {
        public static string Template => "/despesas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            var despesa = context.Despesas.Where(d => d.Id == id).FirstOrDefault();

            if (despesa == null)
                return Results.NotFound();

            context.Remove(despesa);

            context.SaveChanges();



            return Results.Ok();
        }
    }
}
