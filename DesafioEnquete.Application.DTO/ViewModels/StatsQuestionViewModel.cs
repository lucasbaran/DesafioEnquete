using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioEnquete.Application.DTO.ViewModels
{
    public class StatsQuestionViewModel
    {
        public long views { get; set; }
        public IEnumerable<StatsVotesViewModel> votes { get; set; }
    }
}
