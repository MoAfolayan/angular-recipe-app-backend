using System;
using System.Collections.Generic;
using Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

namespace Recipe.Logic.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CheckList GetById(int id)
        {
            return _unitOfWork.CheckLists.GetById(id);
        }

        public void Add(CheckList checkList)
        {
            checkList.CreatedDate = DateTime.UtcNow;
            checkList.IsActive = true;
            _unitOfWork.CheckLists.Insert(checkList);
        }

        public void Update(CheckList checkList)
        {
            _unitOfWork.CheckLists.Update(checkList);
        }

        public void Delete(CheckList checkList)
        {
            _unitOfWork.CheckLists.Delete(checkList);
        }

        public void DeleteMultiple(IEnumerable<CheckList> checkLists)
        {
            _unitOfWork.CheckLists.DeleteMultiple(checkLists);
        }
    }

    public interface ICheckListService : IService<CheckList>
    {
    }
}
