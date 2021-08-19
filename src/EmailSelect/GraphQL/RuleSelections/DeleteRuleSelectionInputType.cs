using HotChocolate.Types;

namespace EmailSelect.GraphQL.RuleSelections
{
    public class DeleteRuleSelectionInputType : InputObjectType<DeleteRuleSelectionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DeleteRuleSelectionInput> descriptor)
        {
            descriptor.Description("Represents the input to delete a Rule Selection.");

            descriptor
                .Field(c => c.SelectionId)
                .Description("Represents the unique ID of the Rule Selection to remove.");

            base.Configure(descriptor);
        }
    }
}