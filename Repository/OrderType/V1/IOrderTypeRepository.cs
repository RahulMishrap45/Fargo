using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderType.V1
{
    public interface IOrderTypeRepository
    {
        IEnumerable<OrderTypeModel> GetAllOrderType();
        OrderTypeModel AddOrderType(OrderTypeRequestModel OrderTypeRequestModel);
        OrderTypeModel GetOrderType(int OrderTypeId);
        OrderTypeModel UpdateOrderType(OrderTypeRequestModel OrderTypeRequestModel);
        OrderTypeModel DeleteOrderType(int OrderTypeId, int deletedBy);
    }
}
