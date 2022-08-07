using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints.ReceitaEndPoints
{
    public class ReceitaPost
    {
        public static string Template => "/receitas";

        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };


        public static Delegate handle => Action;

        public static IResult Action(ReceitaRequest request, ApplicationDbContext context)
        {


            var receita = new Receita(request.Descricao, request.Valor, request.Data);

            var receitaBusca = context.Receitas.Where(r => r.Descricao == receita.Descricao && r.Data.Month == receita.Data.Month && r.Data.Year == receita.Data.Year).FirstOrDefault();



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



            if (!receita.IsValid)
                return Results.ValidationProblem(receita.Notifications.ConvertToProblemDetails());



            context.Receitas.Add(receita);
            context.SaveChanges();

            return Results.Created(Template + "/" + receita.Id, receita.Id);
        }


    }
}
