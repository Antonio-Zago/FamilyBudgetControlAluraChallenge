using Flunt.Notifications;
using Flunt.Validations;

namespace FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain
{
    public class Receita : Notifiable<Notification>
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double Valor { get; set; }

        public DateTime Data { get; set; }

        public Receita(string descricao, double valor, DateTime data) 
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;

            var contract = new Contract<Receita>()
                                .IsNotNullOrEmpty(Descricao, "Descricao")
                                .IsNotNull(Valor, "Valor")
                                .IsGreaterThan(Valor, 0, "Valor")
                                .IsGreaterThan(Data, DateTime.MinValue, "Data");
                                
                            

            AddNotifications(contract);
        }
    }
}
