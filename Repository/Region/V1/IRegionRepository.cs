using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Region.V1
{
    public interface IRegionRepository
    {
        IEnumerable<RegionModel> GetAllRegion();
        RegionModel AddRegion(RegionRequestModel regiomRequestModel);
        RegionModel GetRegion(int OrderTypeId);
        RegionModel UpdateRegion(RegionRequestModel regiomRequestModel);
        RegionModel DeleteRegion(int RegionID, int deletedBy);
    }
}
