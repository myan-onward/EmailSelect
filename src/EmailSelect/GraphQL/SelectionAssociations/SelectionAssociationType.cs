using System.Linq;
using EmailSelect.Data;
using EmailSelect.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailSelect.GraphQL.SelectionAssociations
{
    public class SelectionAssociationType : ObjectType<SelectionAssociation>
    {
        protected override void Configure(IObjectTypeDescriptor<SelectionAssociation> descriptor)
        {
            descriptor.Description("Represents a selection of rules for an associated email address.");

            //descriptor.Field(f => f.).Ignore();

            descriptor.Field(f => f.RuleSelections)
            .ResolveWith<Resolvers>(r => r.GetRuleSelections(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is a collection of email rule sets.");
        }

        private class Resolvers
        {            
            public IQueryable<RuleSelection> GetRuleSelections(SelectionAssociation association, [ScopedService] AppDbContext context)
            {
                return context.RuleSelections.Where(r => r.AssociationId == association.Id);
            }
        }
    }
}