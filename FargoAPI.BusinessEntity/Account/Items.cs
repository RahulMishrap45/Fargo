using ForgoAPI.Entity.Item.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FargoAPI.BusinessEntity.Items
{
    internal class Items
    {
        public static bool IsActive(ItemModel itemModel) => itemModel.ItemID > 0;
        public static bool IsInactive(ItemModel itemModel) => itemModel.ItemID == 0;
        public static bool UserLoginCondition(ItemModel itemModel, int CatId) => itemModel.ItemName == CatId;
    }
}
