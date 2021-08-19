using HotChocolate.Types;

namespace EmailSelect.GraphQL.SelectionAssociations
{
    public class AddSelectionAssociationPayloadType : ObjectType<AddSelectionAssociationPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddSelectionAssociationPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Selection Association.");

            descriptor
                .Field(p => p.association)
                .Description("Represents the added Selection Association.");

            base.Configure(descriptor);
        }
    }
}