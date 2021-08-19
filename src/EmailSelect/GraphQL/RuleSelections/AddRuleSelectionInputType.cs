using EmailSelect.GraphQL.SelectionAssociations;
using HotChocolate.Types;

namespace EmailSelect.GraphQL.RuleSelections
{
    public class AddRuleSelectionInputType : InputObjectType<AddRuleSelectionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddRuleSelectionInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Rule Selection.");

            // descriptor
            //     .Field(c => c.Name)
            //     .Description("Represents the name of the rule selection.");
            descriptor
                .Field(c => c.AssociationId)
                .Description("Represents the unique ID of Association that this belongs.");

            base.Configure(descriptor);
        }
    }
}