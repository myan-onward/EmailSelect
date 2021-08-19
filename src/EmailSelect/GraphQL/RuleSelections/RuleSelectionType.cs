using System.Linq;
using EmailSelect.Data;
using EmailSelect.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailSelect.GraphQL.RuleSelections
{
    public class RuleSelectionType : ObjectType<RuleSelection>
    {
        protected override void Configure(IObjectTypeDescriptor<RuleSelection> descriptor)
        {
            descriptor.Description("Represents a selection of rules (by their IDs and order).");

            //descriptor.Field(f => f.).Ignore();

            descriptor.Field(f => f.AssociationId)
            .ResolveWith<Resolvers>(r => r.GetSelectionAssociation(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the association or email address to which the rule selections belong.");
        }

        private class Resolvers
        {            
                public SelectionAssociation GetSelectionAssociation(RuleSelection selection, [ScopedService] AppDbContext context)
                {
                    return context.SelectionAssociations.FirstOrDefault(s => s.Id == selection.AssociationId);
                }
        }
    }
}