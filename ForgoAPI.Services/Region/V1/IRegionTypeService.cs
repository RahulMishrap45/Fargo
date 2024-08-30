using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Region.V1
{
    public interface IRegionTypeService
    {
        CommonResponse<RegionModel> GetAllRegion();
        RegionModel AddRegion(RegionRequestModel regionRequestModel);
        RegionModel GetRegion(int RegionID);
        RegionModel UpdateRegion(RegionRequestModel regionRequestModel);
        RegionModel DeleteRegion(int RegionID, int deletedBy);
    }
}
