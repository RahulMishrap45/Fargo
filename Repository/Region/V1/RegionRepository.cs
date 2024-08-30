using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Region.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Region.V1
{
    public class RegionRepository : BaseRepository, IRegionRepository
    {
        public RegionModel AddRegion(RegionRequestModel regiomRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @RegionName = regiomRequestModel.RegionName,
                @DataSource = regiomRequestModel.DataSource,
                @IsActive = regiomRequestModel.IsActive,
                @CreatedBy = regiomRequestModel.CreatedBy,
            };
            var regionModel = base.GetSPResults<RegionModel>("cit.spCustomer", paramObjects);
            return regionModel.FirstOrDefault() ?? new RegionModel();
        }

        public RegionModel DeleteRegion(int RegionID, int deletedBy)
        {
            object paramObjects = new
            {
                @RegionID = RegionID,
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<RegionModel>("cit.spDeleteCustomer", paramObjects);
            return result.FirstOrDefault() ?? new RegionModel();
        }

        public IEnumerable<RegionModel> GetAllRegion()
        {
            object paramObjects = new { };
            List<RegionModel> RegionType = base.GetSPResults<RegionModel>("cit.spGetAllCustomers", paramObjects);
            return RegionType;
        }

        public RegionModel GetRegion(int RegionID)
        {
            object paramObjects = new
            {
                @RegionID = RegionID
            };
            var regionModel = base.GetSPResults<RegionModel>("cit.spGetCustomer", paramObjects);
            return regionModel.FirstOrDefault() ?? new RegionModel();
        }

        public RegionModel UpdateRegion(RegionRequestModel regiomRequestModel)
        {
            object paramObjects = new
            {
                @RegionID = regiomRequestModel.RegionID,
                RegionName = regiomRequestModel.RegionName,
                @DataSource = regiomRequestModel.DataSource,
                @ModifiedBy = regiomRequestModel.ModifiedBy,
                @IsActive = regiomRequestModel.IsActive,
            };
            var ordertypeModel = base.GetSPResults<RegionModel>("cit.spUpdateCustomer", paramObjects);
            return ordertypeModel.FirstOrDefault() ?? new RegionModel();
        }
    }
}
