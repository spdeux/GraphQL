using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.GraphQL.GraphQLTypes;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            //The „owners“ parameter is a field name (query from the client must match this name) and the second parameter is the result itself.
            // ListGraphType is the representation of the List type, and of course, we have IntGraphType or StringGraphType,...
            Field<ListGraphType<OwnerType>>("owners", resolve: context => repository.GetAll());
            Field<OwnerType>("owner",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                 resolve: context =>
                    {
                        //first way to implement without error handling
                        //var id = context.GetArgument<Guid>("ownerId");
                        //return repository.GetById(id);

                        //second way to implement with error handling
                        Guid id;
                        if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                        {
                            context.Errors.Add(new ExecutionError("Wrong value for guid"));
                            return null;
                        }

                        return repository.GetById(id);

                    });
        }
    }
}
