using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Brands.StudioSol.TechLeadTest.GraphQL
{
    public class RomanNumbersSchema : Schema
    {
        public RomanNumbersSchema(IServiceProvider provider) : base(provider)
        {
            Mutation = provider.GetRequiredService<RomanNumbersMutation>();
            Query = provider.GetRequiredService<RomanNumbersQuery>();

            Description = "Schema for roman numerals search";
        }
    }
}
