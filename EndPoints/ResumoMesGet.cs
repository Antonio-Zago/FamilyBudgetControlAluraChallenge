using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudgetControlAluraChallenge.EndPoints
{
    public static class ResumoMesGet
    {
        public static string Template => "/resumo/{ano:int}/{mes:int}";

        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

        public static Delegate handle => Action;

        public static IResult Action(ApplicationDbContext context, [FromRoute] int ano, [FromRoute] int mes)
        {
            var resumo = new ResumoMesResponse();
            

            var despesas = context.Despesas
                                        .Include(d => d.CategoriaDespesa)
                                        .Where(d => d.Data.Month == mes && d.Data.Year == ano)
                                        .ToList();

            var receitas = context.Receitas.Where(r => r.Data.Month == mes && r.Data.Year == ano);


            var grupoCategoriaDespesas = despesas.GroupBy(d => d.CategoriaDespesa.Nome);

            foreach (var grupos in grupoCategoriaDespesas)
            {
                var despesaResumoResponse = new DespesaResumoResponse()
                {
                    Descricao = grupos.Key
                };
                foreach (var itens in grupos)
                {
                    despesaResumoResponse.SomaValor += itens.Valor;
                }
                resumo.Despesas.Add(despesaResumoResponse);
            }

            double somaDespesas = 0;

            foreach (Despesa despesa in despesas) 
            {
                somaDespesas += despesa.Valor;

            }

            resumo.somaDespesas = somaDespesas;

            double somaReceitas = 0;

            foreach (Receita receita in receitas)
            {
                somaReceitas += receita.Valor;

            }

            resumo.somaReceitas = somaReceitas;

            resumo.saldo = somaReceitas - somaDespesas;



            return Results.Ok(resumo);
        }
    }
}
