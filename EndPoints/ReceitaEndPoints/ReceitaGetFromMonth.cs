using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.ReceitaEndPoints
{
    public static class ReceitaGetFromMonth
    {
        public static string Template => "/receitas/{ano:int}/{mes:int}";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };


        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, [FromRoute] int mes, [FromRoute] int ano)
        {
            var receitas = context.Receitas.Where(r => r.Data.Month == mes && r.Data.Year == ano);
            var response = receitas.Select(r => new ReceitaResponse { Descricao = r.Descricao, Data = r.Data, Valor = r.Valor, Id = r.Id });

            return Results.Ok(response);
        }
    }
}
