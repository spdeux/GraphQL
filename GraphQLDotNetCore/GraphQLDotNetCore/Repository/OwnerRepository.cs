using System;
using System.Collections.Generic;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;
using System.Linq;

namespace GraphQLDotNetCore.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners;
        }

        public Owner GetById(Guid id)
        {
            return _context.Owners.SingleOrDefault(x => x.Id == id);
        }

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;

            _context.SaveChanges();

            return dbOwner;
        }
    }
}
