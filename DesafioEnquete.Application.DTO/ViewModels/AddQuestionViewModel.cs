using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace DesafioEnquete.Application.DTO.ViewModels
{
    public class AddQuestionViewModel : Notifiable, IValidatable
    {
        public string poll_description { get; set; }

        public IEnumerable<OptionViewModel> options { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(poll_description, 120, "poll_description", "A pergunta deve conter até 120 caracteres")
                    .HasMinLen(poll_description, 3, "poll_description", "A pergunta deve conter pelo menos 3 caracteres")
                    .AreNotEquals(options.Count(), 3, "options", "A pergunta deve conter 3 opções")
            );
            foreach (var option in options)
            {
                AddNotifications(
                    new Contract()
                    .HasMaxLen(option.option_description, 120, "option_description", "A opção deve conter até 120 caracteres")
                    .HasMinLen(option.option_description, 3, "option_description", "A opção deve conter pelo menos 3 caracteres")
                );
            }
        }
    }
}
