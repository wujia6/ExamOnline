using System.Collections.Generic;
using Domain.Entities.MenuAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    public class MenuManage : IMenuManage
    {
        private readonly IEfCoreRepository<MenuInfo> efCore;

        public MenuManage(IEfCoreRepository<MenuInfo> ef)
        {
            this.efCore = ef;
        }

        public bool AddOrEdit(MenuInfo entity)
        {
            return entity.ID > 0 ? efCore.ModifyAt(entity) : efCore.AddAt(entity);
        }

        public bool Remove(ISpecification<MenuInfo> spec)
        {
            var entity = FindBy(spec);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public MenuInfo FindBy(ISpecification<MenuInfo> spec)
        {
            return efCore.Single(spec);
        }

        public IEnumerable<MenuInfo> Lists(ISpecification<MenuInfo> spec = null)
        {
            return efCore.Lists(spec);
        }
    }
}
