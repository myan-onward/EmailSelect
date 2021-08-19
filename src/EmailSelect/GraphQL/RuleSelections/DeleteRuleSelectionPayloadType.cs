using HotChocolate.Types;

namespace EmailSelect.GraphQL.RuleSelections
{
    public class DeleteRuleSelectionPayloadType : ObjectType<DeleteRuleSelectionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteRuleSelectionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for a deleted Rule Selection.");

            descriptor
                .Field(c => c.SelectionId)
                .Description("Represents the deleted Rule Selection.");

            base.Configure(descriptor);
        }
    }
}