using System.Linq;
using EmailSelect.Data;
using EmailSelect.Models;
using HotChocolate;
using HotChocolate.Data;

namespace EmailSelect.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]  -- no longer needed with Resolvers / Types (GraphQL)
        [UseFiltering]
        [UseSorting]
        public IQueryable<SelectionAssociation> GetSelectionAssociations([ScopedService] AppDbContext context)
        {
            return context.SelectionAssociations;
        }
    }
}