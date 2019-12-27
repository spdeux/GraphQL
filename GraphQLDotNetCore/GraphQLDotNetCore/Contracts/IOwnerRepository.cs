using GraphQLDotNetCore.Entities;
using System;
using System.Collections.Generic;

namespace GraphQLDotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner CreateOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
        void DeleteOwner(Owner owner);

        Owner GetById(Guid id);
    }
}
