using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.ReceitaEndPoints
{
    public static class ReceitaGetAll
    {
        public static string Template => "/receitas";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };


        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, [FromQuery] string descricao = "")
        {
            var receitas = context.Receitas.Where(r => r.Descricao.Contains(descricao));
            var response = receitas.Select(r => new ReceitaResponse { Descricao = r.Descricao, Data = r.Data, Valor = r.Valor, Id = r.Id });

            return Results.Ok(response);
        }
    }
}
