using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaGetFromMonth
    {
        public static string Template => "/despesas/{ano:int}/{mes:int}";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };


        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, [FromRoute] int mes, [FromRoute] int ano)
        {
            var despesas = context.Despesas.Where(d => d.Data.Month == mes && d.Data.Year == ano);
            var response = despesas.Select(r => new DespesaResponse { Descricao = r.Descricao, Data = r.Data, Valor = r.Valor, Id = r.Id });

            return Results.Ok(response);
        }
    }
}
