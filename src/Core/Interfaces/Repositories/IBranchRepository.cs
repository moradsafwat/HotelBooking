using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookig.Core.Repositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        IEnumerable<Branch> GetWithHotel();
        Branch CheckHotelId(int HotelId);
        bool CheckBranch(int branchId);

    }
}
