using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;

namespace FamilyBudgetControlAluraChallenge.EndPoints
{
    public class ReceitaGetAll
    {
        public static string Template => "/receitas";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };


        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context) 
        {
            var receitas = context.Receitas.ToList();
            var response = receitas.Select(r => new ReceitaResponse { Descricao = r.Descricao, Data = r.Data, Valor = r.Valor, Id = r.Id });

            return Results.Ok(response);
        } 
    }
}
