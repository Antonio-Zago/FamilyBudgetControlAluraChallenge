using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaGet
    {
        public static string Template => "/despesas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute]int id, ApplicationDbContext context)
        {
            var despesa = context.Despesas.Where(d => d.Id == id).FirstOrDefault();

            if (despesa == null)
                return Results.NotFound();

            var response = new DespesaResponse
            {
                Id = despesa.Id,
                Descricao = despesa.Descricao,
                Data = despesa.Data,
                Valor = despesa.Valor
            };

            return Results.Ok(response);
        }
    }
}
