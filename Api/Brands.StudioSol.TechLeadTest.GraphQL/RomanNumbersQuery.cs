using GraphQL;
using GraphQL.Types;

namespace Brands.StudioSol.TechLeadTest.GraphQL
{
    /// <summary>
    /// For some reason, GraphQL breaks when the Query is empty, so I implemented this hello
    /// query to make it work.
    /// </summary>
    public class RomanNumbersQuery : ObjectGraphType
    {
        private const string NAME_QUERY_ARGUMENT = "name";

        public RomanNumbersQuery()
        {
            Name = "Query";

            Field<StringGraphType>("hello")
                .Argument<NonNullGraphType<StringGraphType>>(NAME_QUERY_ARGUMENT)
                .Resolve(context => $"Hello {context.GetArgument<string>(NAME_QUERY_ARGUMENT)}");
        }
    }
}
