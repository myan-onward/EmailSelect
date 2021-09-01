using EmailSelect.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailSelect.GraphQL
{
    [GraphQLDescription("Represents the subscription to an Association.")]
    public class Subscription
    {
        /// <summary>
        /// The subscription for added <see cref="SelectionAssociation"/>.
        /// </summary>
        /// <param name="association">The <see cref="SelectionAssociation"/>.</param>
        /// <returns>The added <see cref="SelectionAssociation"/>.</returns>
        [Subscribe]
        [Topic]
        [GraphQLDescription("The subscription for added email rule.")]
        public SelectionAssociation OnAssociationAdded([EventMessage] SelectionAssociation association)
        {
            return association;
        }
    }
}