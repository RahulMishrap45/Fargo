using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Customer.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderType.V1
{
    public class OrderTypeRepository : BaseRepository, IOrderTypeRepository
    {
        public OrderTypeModel AddOrderType(OrderTypeRequestModel OrderTypeRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @TypeName = OrderTypeRequestModel.TypeName,
                @DataSource = OrderTypeRequestModel.DataSource,
                @IsActive = OrderTypeRequestModel.IsActive,
                @CreatedBy = OrderTypeRequestModel.CreatedBy,
            };
            var customerModel = base.GetSPResults<OrderTypeModel>("cit.spCustomer", paramObjects);
            return customerModel.FirstOrDefault() ?? new OrderTypeModel();
        }

        public OrderTypeModel DeleteOrderType(int OrderTypeId, int deletedBy)
        {
            object paramObjects = new
            {
                @OrderTypeId = OrderTypeId,
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<OrderTypeModel>("cit.spDeleteCustomer", paramObjects);
            return result.FirstOrDefault() ?? new OrderTypeModel();
        }

        public IEnumerable<OrderTypeModel> GetAllOrderType()
        {
            object paramObjects = new { };
            List<OrderTypeModel> OrderType = base.GetSPResults<OrderTypeModel>("cit.spGetAllCustomers", paramObjects);
            return OrderType;
        }

        public OrderTypeModel GetOrderType(int OrderTypeId)
        {
            object paramObjects = new
            {
                @OrderTypeId = OrderTypeId
            };
            var ordertypeModel = base.GetSPResults<OrderTypeModel>("cit.spGetCustomer", paramObjects);
            return ordertypeModel.FirstOrDefault() ?? new OrderTypeModel();
        }

        public OrderTypeModel UpdateOrderType(OrderTypeRequestModel OrderTypeRequestModel)
        {
            object paramObjects = new
            {
                @OrderTypeID = OrderTypeRequestModel.OrderTypeID,
                @TypeName = OrderTypeRequestModel.TypeName,
                @DataSource = OrderTypeRequestModel.DataSource,
                @ModifiedBy = OrderTypeRequestModel.ModifiedBy,
                @IsActive = OrderTypeRequestModel.IsActive,
            };
            var ordertypeModel = base.GetSPResults<OrderTypeModel>("cit.spUpdateCustomer", paramObjects);
            return ordertypeModel.FirstOrDefault() ?? new OrderTypeModel();
        }
    }
}
