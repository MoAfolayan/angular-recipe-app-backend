using System;
using System.Collections.Generic;
using Recipe.Data.Repositories;
using Recipe.Data;
using Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;
using Recipe.Data.UnitOfWork.Interfaces;

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
}
