using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.ReceitaEndPoints
{
    public static class ReceitaPut
    {
        public static string Template => "/receitas/{id:int}";

        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

        public static Delegate handle => Action;

        public static IResult Action([FromRoute] int id, ApplicationDbContext context, ReceitaRequest request)
        {
            var receita = context.Receitas.Where(r => r.Id == id).FirstOrDefault();
            var receitaBusca = context.Receitas.Where(r => r.Descricao == request.Descricao && r.Data.Month == request.Data.Month && r.Data.Year == request.Data.Year).FirstOrDefault();

            if (receita == null)
                return Results.NotFound();


            if (!(receitaBusca == null))
            {
                var resposta = new ReceitaResponse()
                {
                    Id = receitaBusca.Id,
                    Descricao = receitaBusca.Descricao,
                    Data = receitaBusca.Data,
                    Valor = receitaBusca.Valor
                };

                return Results.UnprocessableEntity(resposta);
            }


            receita.EditInfo(request.Descricao, request.Data, request.Valor);

            if (!receita.IsValid)
            {
                return Results.ValidationProblem(receita.Notifications.ConvertToProblemDetails());
            }

            context.SaveChanges();


            return Results.Ok();
        }
    }
}
