using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.ReceitaEndPoints
{
    public static class ReceitaGet
    {
        public static string Template => "/receitas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context)
        {
            var receita = context.Receitas.Where(r => r.Id == id).FirstOrDefault();

            if (receita == null)
                return Results.NotFound();

            var response = new ReceitaResponse { Id = receita.Id, Data = receita.Data, Descricao = receita.Descricao, Valor = receita.Valor };


            return Results.Ok(response);
        }
    }
}
