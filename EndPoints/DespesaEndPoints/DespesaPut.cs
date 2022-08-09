using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaPut
    {
        public static string Template => "/despesas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context, DespesaRequest request)
        {
            var categoriaDepesas = context.CategoriaDespesas.Where(c => c.Id == request.CategoriaDespesaId).FirstOrDefault();

            if (categoriaDepesas == null)
                categoriaDepesas = context.CategoriaDespesas.Where(c => c.Nome == "Outras").FirstOrDefault();

            var despesa = context.Despesas.Where(d => d.Id == id).FirstOrDefault();
            var despesaBusca = context.Despesas.Where(d => d.Descricao == request.Descricao && d.Data.Month == request.Data.Month && d.Data.Year == request.Data.Year).FirstOrDefault();

            if (despesa == null)
                return Results.NotFound();

            if (!(despesaBusca == null))
            {
                var resposta = new DespesaResponse()
                {
                    Id = despesaBusca.Id,
                    Descricao = despesaBusca.Descricao,
                    Data = despesaBusca.Data,
                    Valor = despesaBusca.Valor
                };

                return Results.UnprocessableEntity(resposta);
            }

            

            despesa.EditInfo(request.Descricao, request.Valor, request.Data, categoriaDepesas);

            if (!despesa.IsValid)
            {
                return Results.ValidationProblem(despesa.Notifications.ConvertToProblemDetails());
            }

            context.SaveChanges();


            return Results.Ok();

            


        }
    }
}
