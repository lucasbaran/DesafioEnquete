using Flunt.Notifications;
using Flunt.Validations;

namespace DesafioEnquete.Application.DTO.ViewModels
{
    public class OptionDTO : Notifiable, IValidatable
    {
        public int? Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public long Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Description, 120, "Description", "O opção deve conter até 120 caracteres")
                    .HasMinLen(Description, 3, "Description", "O opção deve conter pelo menos 3 caracteres")
            );
        }
    }
}
