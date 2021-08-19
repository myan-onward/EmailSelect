using EmailSelect.Models;

namespace EmailSelect.GraphQL.RuleSelections
{
    public record AddRuleSelectionInput(string Name, int AssociationId);
}