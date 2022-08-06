using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetControlAluraChallenge.EndPoints
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
                    Descricao = receitaBusca.Descricao,
                    Data = receitaBusca.Data,
                    Valor = receitaBusca.Valor
                };

                return Results.UnprocessableEntity(resposta);
            }
            


            if (!receita.IsValid)
                return Results.ValidationProblem(receita.Notifications.GroupBy(r => r.Key).ToDictionary(r => r.Key, r => r.Select(x => x.Message).ToArray()));
                


            context.Receitas.Add(receita);
            context.SaveChanges();

            return Results.Created(ReceitaPost.Template + "/" + receita.Id, receita.Id);
        }


    }
}
