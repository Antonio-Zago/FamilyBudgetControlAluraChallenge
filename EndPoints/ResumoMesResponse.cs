using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;

namespace FamilyBudgetControlAluraChallenge.EndPoints
{
    public class ResumoMesResponse
    {
        public double somaReceitas { get; set; }

        public double somaDespesas { get; set; }

        public double saldo { get; set; }


        public List<DespesaResumoResponse> Despesas { get; set; } = new List<DespesaResumoResponse>();
    }
}
