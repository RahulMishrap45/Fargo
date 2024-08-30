using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.OrderType.V1
{
    public interface IOrderTypeService
    {
        CommonResponse<OrderTypeModel> GetAllordertype();
        OrderTypeModel AddOrderType(OrderTypeRequestModel OrderTypeRequestModel);
        OrderTypeModel GetOrderType(int OrderTypeId);
        OrderTypeModel UpdateOrderType(OrderTypeRequestModel OrderTypeRequestModel);
        OrderTypeModel DeleteOrderType(int OrderTypeID, int deletedBy);
    }
}
