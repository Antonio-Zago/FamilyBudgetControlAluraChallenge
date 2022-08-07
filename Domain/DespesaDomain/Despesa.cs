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

        public Despesa(string descricao, double valor, DateTime data) 
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;

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
    }
}
