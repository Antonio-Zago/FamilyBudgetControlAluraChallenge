using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class CategoriaDespesaGetAll
    {
        public static string Template => "/categoriaDespesa";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context)
        {
            var categoriaDespesa = context.CategoriaDespesas;

            var response = categoriaDespesa.Select(d => new CategoriaDespesaResponse { Nome = d.Nome });

            return Results.Ok(response);
        }
    }
}
