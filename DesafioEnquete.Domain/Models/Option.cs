using System;

namespace DesafioEnquete.Domain.Models
{
    public class Option: Base
    {
        public string Description { get; set; }
        public long Quantity { get; set; }
        public int QuestionId { get; set; }
    }
}
