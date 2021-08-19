using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmailSelect.Models
{
    public class RuleSelection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }     
        public ICollection<SelectedRule> SelectedRules { get; set; } = new List<SelectedRule>();

        [Required]
        public int AssociationId { get; set; }
        public SelectionAssociation SelectionAssociation { get; set; }
    }
}