using HotChocolate.Types;

namespace EmailSelect.GraphQL.RuleSelections
{
    public class AddRuleSelectionPayloadType : ObjectType<AddRuleSelectionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddRuleSelectionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Rule Selection.");

            descriptor
                .Field(c => c.selection)
                .Description("Represents the added Rule Selection.");

            base.Configure(descriptor);
        }
    }
}