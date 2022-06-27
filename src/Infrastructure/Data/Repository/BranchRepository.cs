using HotelBookig.Core.Repositories;
using HotelBooking.Core.Models;
using HotelBooking.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data.Repository
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public Branch CheckHotelId(int HotelId)
        {
            return db.Branchs.Where(h => h.Hotel.Id == HotelId).FirstOrDefault();
        }
        public bool CheckBranch(int branchId)
        {
            var check = db.Branchs.Any(b => b.Id == branchId);
            if (check == false)
                return false;
            return true;
        }

        public IEnumerable<Branch> GetWithHotel()
        {
            return db.Branchs.Include(h => h.Hotel).ToList();
        }
    }
}
