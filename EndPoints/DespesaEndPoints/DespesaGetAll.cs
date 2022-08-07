using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaGetAll
    {
        public static string Template => "/despesas";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var despesas = context.Despesas;

            var response = despesas.Select(d => new DespesaResponse { Descricao = d.Descricao, Data = d.Data, Id = d.Id, Valor = d.Valor });

            return Results.Ok(response);
        }
    }
}
