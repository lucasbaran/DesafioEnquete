using System.Collections.Generic;

namespace DesafioEnquete.Domain.Models
{
    public class Question : Base
    {
        public string Description { get; set; }
        public long Views { get; set; }
    }
}
