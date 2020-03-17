using System.Collections.Generic;

namespace DesafioEnquete.Application.DTO.ViewModels
{
    public class GetQuestionViewModel
    {
        public int poll_id { get; set; }

        public string poll_description { get; set; }
        public IEnumerable<GetOptionViewModel> options { get; set; }
    }
}
