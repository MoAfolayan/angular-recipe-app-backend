using System;
using Recipe.Data.Repositories;
using Recipe.Data;
using Recipe.Data.Entities;
using Recipe.Logic.Services.Interfaces;
using Recipe.Data.UnitOfWork.Interfaces;

namespace Recipe.Logic.Services
{
    public class CheckListItemService : ICheckListItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckListItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CheckListItem GetById(int id) 
        {
            return _unitOfWork.CheckListItems.GetById(id);
        }

        public void Add(CheckListItem checkListItem)
        {
            checkListItem.CreatedDate = DateTime.UtcNow;
            checkListItem.IsActive = true;
            _unitOfWork.CheckListItems.Insert(checkListItem);
        }

        public void Update(CheckListItem checkListItem)
        {
            _unitOfWork.CheckListItems.Update(checkListItem);
        }

        public void Delete(CheckListItem checkListItem)
        {
            _unitOfWork.CheckListItems.Delete(checkListItem);
        }
    }
}
