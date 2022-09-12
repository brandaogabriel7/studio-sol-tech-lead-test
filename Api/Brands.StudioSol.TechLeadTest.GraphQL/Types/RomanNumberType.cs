using Brands.StudioSol.TechLeadTest.Models;
using GraphQL.Types;

namespace Brands.StudioSol.TechLeadTest.GraphQL.Types
{
    public class RomanNumberType : ObjectGraphType<RomanNumber>
    {
        public RomanNumberType()
        {
            Name = "romanNumber";

            Field<StringGraphType>("number")
                .Description("O número romano")
                .Resolve(context => context.Source.Number);

            Field<IntGraphType>("value")
                .Description("O valor numérico")
                .Resolve(context => context.Source.Value);

        }
    }
}
