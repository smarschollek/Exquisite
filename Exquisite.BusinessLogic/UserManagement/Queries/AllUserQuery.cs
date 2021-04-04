using Exquisite.BusinessLogic.Entities;
using Exquisite.BusinessLogic.Helper;
using Exquisite.BusinessLogic.UserManagement.Models;
using LiteDB;
using Mapster;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Exquisite.BusinessLogic.UserManagement.Queries
{
    public class AllUserQuery : IRequest<AllUserResponse>
    {
    }

    public class AllUserQueryHandler : IRequestHandler<AllUserQuery, AllUserResponse>
    {
        private readonly ILiteCollection<User> _collection;

        public AllUserQueryHandler(ILiteDatabase database)
        {
            _collection = database.GetCollection<User>(CollectionNames.User);
        }

        public Task<AllUserResponse> Handle(AllUserQuery request, CancellationToken cancellationToken)
        {
            var result = _collection.Query().ToList();
            var users = new List<UserDto>();
            result.ForEach(user => users.Add(user.Adapt<UserDto>()));
            return Task.FromResult(new AllUserResponse { Users = users.ToArray() });
        }
    }
}
