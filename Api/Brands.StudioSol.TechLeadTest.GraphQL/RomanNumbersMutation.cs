using Brands.StudioSol.TechLeadTest.GraphQL.Types;
using Brands.StudioSol.TechLeadTest.Services.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace Brands.StudioSol.TechLeadTest.GraphQL
{
    public class RomanNumbersMutation : ObjectGraphType
    {
        private const string TEXT_ARGUMENT_NAME = "text";

        public RomanNumbersMutation(IRomanNumbersService romanNumbersService)
        {
            Name = "Mutation";

            Field<RomanNumberType>("search")
                .Argument<NonNullGraphType<StringGraphType>>(TEXT_ARGUMENT_NAME)
                .Resolve(context => romanNumbersService.GetLowestPrimeRomanNumber(context.GetArgument<string>(TEXT_ARGUMENT_NAME)));
        }
    }
}
