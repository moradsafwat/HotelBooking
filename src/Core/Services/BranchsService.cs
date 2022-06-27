using HotelBookig.Core.Repositories;
using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public class BranchsService : IBranchsService
    {
        private readonly IBranchRepository _branch;
        private readonly IHotelRepository _hotel;
        public BranchsService(IBranchRepository branch, IHotelRepository hotel)
        {
            _branch = branch;
            _hotel = hotel;
        }

        public IEnumerable<Branch> GetAll()
        {
            var branchs = _branch.List();
            return branchs ;
        }
        public IEnumerable<Branch> GetWithHotel()
        {
            var branchs = _branch.GetWithHotel();
            return branchs;
        }

        public BranchDto GetById(int id)
        {
            var branch = _branch.Find(id);

            var dto = new BranchDto
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                Location = branch.Location,
                HotelId = branch.HotelId,
            };
            return dto;
        }
        public BranchDto Update(BranchDto dto)
        {
            var branch = new Branch
            {
                Id = dto.Id,
                BranchName = dto.BranchName,
                Location = dto.Location,
                HotelId = dto.HotelId
            };
            _branch.Update(branch);
            return dto;
        }
        public BranchDto Add(BranchDto dto)
        {
            var branch = new Branch
            {
                Id = dto.Id,
                BranchName = dto.BranchName,
                Location = dto.Location,
                HotelId = dto.HotelId
            };

            _branch.Add(branch);
            return dto;
        }
        public BranchDto Delete(BranchDto dto)
        {
            var branch = new Branch
            {
                Id = dto.Id,
                BranchName = dto.BranchName,
                Location = dto.Location,
                HotelId = dto.HotelId
            };
            _branch.Remove(branch);

            return dto;
        }

        public bool Check(int id)
        {
            var branch = _branch.Find(id);
            if (branch == null)
                return false;
            return true;
        }

        public bool CheckHotel(int HotelId)
        {
            var hotel = _branch.CheckHotelId(HotelId);
            if (hotel == null)
                return false;
            return true;
        }

        public bool CheckBranch(int branchId)
        {
            return _branch.CheckBranch(branchId);
        }
        public void SaveChange()
        {
            _branch.SaveAsync();
        }
    }
}
