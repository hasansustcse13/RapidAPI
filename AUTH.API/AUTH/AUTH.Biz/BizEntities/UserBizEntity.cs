using AUTH.Biz.BOs;
using AUTH.Biz.DataModels;
using AutoMapper;
using BizFrameWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AUTH.Biz.BizEntities
{
    public class UserBizEntity : BizEntity<IAuthBizContext>
    {
        public UserBizEntity(IAuthBizContext bizContext, IMapper mapper) : base(bizContext, mapper)
        {

        }

        public async Task<UserBO[]> GetAllUsersAsync()
        {
            var users = await Context.DbContext.Users.ToArrayAsync();
            return Mapper.Map<UserBO[]>(users);
        }

        public async Task<int> AddUserAsync(UserBO userBO)
        {
            var user = Mapper.Map<User>(userBO);
            await Context.DbContext.Users.AddAsync(user);
            await Context.DbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
