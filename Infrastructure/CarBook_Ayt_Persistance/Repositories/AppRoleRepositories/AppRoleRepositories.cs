using CarBook.Application.Interfaces.AppRoleInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.AppRoleRepositories
{
    public class AppRoleRepositories : IAppRoleRepository
    {
        private readonly CarBookContext _carbookcontext;

        public AppRoleRepositories(CarBookContext carbookcontext)
        {
            _carbookcontext = carbookcontext;
        }

        public async Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            var values = await _carbookcontext.AppRoles.Where(filter).FirstOrDefaultAsync();
            return values;
        }
    }
}
