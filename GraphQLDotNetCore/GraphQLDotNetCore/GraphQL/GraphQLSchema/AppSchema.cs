using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        // inject the IdependencyResolver which is going to help us resolve our Query, Mutation or Subscription objects.
        //each of the schema properties (Query, Mutation or Subscription) implements IObjectGraphType
        public AppSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}
