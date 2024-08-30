using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using Repository.User.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgoAPI.Services.User.V1;
using Repository.OrderType.V1;

namespace ForgoAPI.Services.OrderType.V1
{
    public class OrderTypeService : BaseService, IOrderTypeService
    {

        private IOrderTypeRepository _IorderTypeRepository;

        public OrderTypeService(IOrderTypeRepository IorderTypeRepository)
        {
            _IorderTypeRepository = IorderTypeRepository;
        }

        public OrderTypeModel AddOrderType(OrderTypeRequestModel OrderTypeRequestModel)
        {
            return _IorderTypeRepository.AddOrderType(OrderTypeRequestModel);
        }

        public OrderTypeModel DeleteOrderType(int OrderTypeID, int deletedBy)
        {
            return _IorderTypeRepository.DeleteOrderType(OrderTypeID, deletedBy);
        }
        public CommonResponse<OrderTypeModel> GetAllordertype()
        {
            var OrderTypeList = _IorderTypeRepository.GetAllOrderType().ToList();
            if (OrderTypeList == null)
                return new CommonResponse<OrderTypeModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<OrderTypeModel>
            {
                Model = OrderTypeList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
        }

        public OrderTypeModel GetOrderType(int OrderTypeId)
        {
            return _IorderTypeRepository.GetOrderType(OrderTypeId);
        }
        public OrderTypeModel UpdateOrderType(OrderTypeRequestModel OrderTypeRequestModel)
        {
            return _IorderTypeRepository.UpdateOrderType(OrderTypeRequestModel);
        }
    }
}
