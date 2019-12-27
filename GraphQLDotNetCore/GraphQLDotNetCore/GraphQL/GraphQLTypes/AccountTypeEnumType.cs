using GraphQL.Types;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
    //class must inherit from the generic EnumerationGraphType which for the generic parameter has
    //the enumeration that we have created in our starter project.
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            //the value for the Name property must mache the name of the same enumeration property 
            //inside the Account class : public TypeOfAccount Type { get; set; }
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}
