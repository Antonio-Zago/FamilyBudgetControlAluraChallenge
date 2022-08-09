
using Flunt.Notifications;
using Flunt.Validations;

namespace FamilyBudgetControlAluraChallenge.Domain.DespesaDomain
{
    public class Despesa : Notifiable<Notification>
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }

        public CategoriaDespesa CategoriaDespesa { get; set; }

        private Despesa() { }

        public Despesa(string descricao, double valor, DateTime data, CategoriaDespesa categoriaDespesa ) 
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            CategoriaDespesa = categoriaDespesa;

            Validate();
        }

        public void Validate() 
        {
            var contract = new Contract<Despesa>()
                                .IsNotNullOrEmpty(Descricao, "Descricao")
                                .IsNotNull(Valor, "Valor")
                                .IsGreaterThan(Valor, 0, "Valor")
                                .IsGreaterThan(Data, DateTime.MinValue, "Data");



            AddNotifications(contract);
        }

        public void EditInfo(string descricao, double valor, DateTime data, CategoriaDespesa categoriaDespesa)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            CategoriaDespesa = categoriaDespesa;

            Validate();
        }
    }
}
