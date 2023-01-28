using System;
using System.Collections.Generic;
using Recipe.Data.Entities;
using Recipe.Data.UnitOfWork;

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

        public void DeleteMultiple(IEnumerable<CheckListItem> checkListItems)
        {
            _unitOfWork.CheckListItems.DeleteMultiple(checkListItems);
        }
    }

    public interface ICheckListItemService : IService<CheckListItem>
    {
    }
}
