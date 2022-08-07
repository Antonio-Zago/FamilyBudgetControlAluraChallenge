using Flunt.Notifications;

namespace FamilyBudgetControlAluraChallenge.EndPoints
{
    public static class ProblemDetailsExtension
    {
        public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications) 
        {
            return notifications.GroupBy(r => r.Key).ToDictionary(r => r.Key, r => r.Select(x => x.Message).ToArray());
        }
    }
}
