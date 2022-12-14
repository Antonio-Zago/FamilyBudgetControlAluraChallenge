using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;

namespace FamilyBudgetControlAluraChallenge.EndPoints.DespesaEndPoints
{
    public static class DespesaPost
    {
        public static string Template => "/despesas";

        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, DespesaRequest request)
        {
            var categoriaDepesas = context.CategoriaDespesas.Where(c => c.Id == request.CategoriaDespesaId ).FirstOrDefault();

            if (categoriaDepesas == null)
                categoriaDepesas = context.CategoriaDespesas.Where(c => c.Nome == "Outras").FirstOrDefault();

            var despesa = new Despesa(request.Descricao, request.Valor, request.Data, categoriaDepesas);


            var despesaBusca = context.Despesas.Where(d => d.Descricao == despesa.Descricao && d.Data.Month == despesa.Data.Month && d.Data.Year == despesa.Data.Year).FirstOrDefault();

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

            if (!despesa.IsValid)
                return Results.ValidationProblem(despesa.Notifications.ConvertToProblemDetails());


            context.Despesas.Add(despesa);

            context.SaveChanges();

            return Results.Created(DespesaPost.Template + "/" + despesa.Id, despesa.Id);



        }
    }
}
