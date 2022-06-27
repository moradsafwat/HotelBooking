using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public interface IBranchsService
    {
        IEnumerable<Branch> GetAll();
        IEnumerable<Branch> GetWithHotel();
        BranchDto GetById(int id);
        BranchDto Add(BranchDto branchDto);
        BranchDto Delete(BranchDto branchDto);
        BranchDto Update(BranchDto branchDto);
        bool Check(int id);
        bool CheckHotel(int id);
        bool CheckBranch(int branchId);

        void SaveChange();
    }
}
