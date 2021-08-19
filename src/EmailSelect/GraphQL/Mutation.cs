using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmailSelect.Data;
using EmailSelect.GraphQL.SelectionAssociations;
using EmailSelect.GraphQL.RuleSelections;
using EmailSelect.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace EmailSelect.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddSelectionAssociationPayload> AddSelectionAssociationAsync(AddSelectionAssociationInput input, [ScopedService] AppDbContext context,
         [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var association = new SelectionAssociation
            {
                EmailAddress = input.EmailAddress,
            };

            context.SelectionAssociations.Add(association);

            await context.SaveChangesAsync(cancellationToken);

            // await eventSender.SendAsync(nameof(Subscription.OnAssociationAdded), association, cancellationToken);

            return new AddSelectionAssociationPayload(association);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddRuleSelectionPayload> AddRuleSelectionAsync(AddRuleSelectionInput input, [ScopedService] AppDbContext context,
        CancellationToken cancellationToken)
        {
            var selection = new RuleSelection
            {
                Name = input.Name,
                AssociationId = input.AssociationId
            };

            context.RuleSelections.Add(selection);
            await context.SaveChangesAsync(cancellationToken);

            return new AddRuleSelectionPayload(selection);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteRuleSelectionPayload> DeleteRuleSelectionAsync(DeleteRuleSelectionInput input, [ScopedService] AppDbContext context,
         CancellationToken cancellationToken)
        {
            var itemToRemove = context.RuleSelections.SingleOrDefault(x => x.Id == input.SelectionId);

            if (itemToRemove != null) {
                context.RuleSelections.Remove(itemToRemove);
                int rowsChanged = await context.SaveChangesAsync(cancellationToken);
                return new DeleteRuleSelectionPayload(itemToRemove.Id);
            }

            return null;
        }       
    }
}