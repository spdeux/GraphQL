using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
    // GraphQL API can’t return our models directly as a result but GraphQL types which implement IObjectGraphType instead.
    //OwnerType class which we use as a replacement for the Owner model inside a GraphQL API
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository)
        {
            //With the Field method, we specify the fields which represent our properties from the Owner model class.
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");

            #region After creating AccountType
            //the context contains the Source property which is of the Owner type
            Field<ListGraphType<AccountType>>(
                "accounts", 
                resolve: context => repository.GetAllAccountsPerOwner(context.Source.Id));
            #endregion
        }
    }
}
