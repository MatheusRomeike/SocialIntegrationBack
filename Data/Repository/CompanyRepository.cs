using Domain.Entities.Company;
using Data.Interfaces.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Context;

namespace Data.Repository
{
    public class CompanyRepository : BaseRepository<Company, DataContext>, ICompanyRepository
    {
        private readonly DataContext Context;

        public CompanyRepository(DataContext context) : base(context)
        {
            this.Context = context;
        }
    }
}
