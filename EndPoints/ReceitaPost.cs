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
            var receita = new Receita
            {
                Descricao = request.Descricao,
                Data = request.Data,
                Valor = request.Valor
            };

            context.Receitas.Add(receita);
            context.SaveChanges();

            return Results.Created(ReceitaPost.Template + "/" + receita.Id, receita.Id);
        }
    }
}
