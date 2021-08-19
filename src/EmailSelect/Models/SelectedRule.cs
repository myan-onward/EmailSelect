using System.ComponentModel.DataAnnotations;

namespace EmailSelect.Models
{
    public class SelectedRule
    {
        [Key]
        public int Id { get; set; }

        public int RuleId {get; set;}
    }
}