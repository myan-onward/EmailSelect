using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmailSelect.Models
{
    public class SelectionAssociation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAddress {get; set;}
        
        public ICollection<RuleSelection> RuleSelections { get; set; } = new List<RuleSelection>();
    }
}