using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaGetAll
    {
        public static string Template => "/despesas";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, [FromQuery] string descricao = "")
        {
            var despesas = context.Despesas.Where(d => d.Descricao.Contains(descricao));

            var response = despesas.Select(d => new DespesaResponse { Descricao = d.Descricao, Data = d.Data, Id = d.Id, Valor = d.Valor });

            return Results.Ok(response);
        }
    }
}
