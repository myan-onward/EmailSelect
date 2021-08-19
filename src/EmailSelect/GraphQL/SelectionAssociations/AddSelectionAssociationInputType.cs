using HotChocolate.Types;

namespace EmailSelect.GraphQL.SelectionAssociations
{
    public class AddSelectionAssociationInputType : InputObjectType<AddSelectionAssociationInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddSelectionAssociationInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Selection Association.");

            descriptor
                .Field(p => p.EmailAddress)
                .Description("Represents the email address for the Selection Association.");

            base.Configure(descriptor);
        }
    }
}