using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace DesafioEnquete.Application.DTO.ViewModels
{
    public class QuestionDTO : Notifiable, IValidatable
    {
        public int? Id { get; set; }

        public string Description { get; set; }
        public long Views { get; set; }
        public IEnumerable<OptionDTO> Options { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Description, 120, "Title", "O título deve conter até 120 caracteres")
                    .HasMinLen(Description, 3, "Title", "O título deve conter pelo menos 3 caracteres")
            );
        }
    }
}
