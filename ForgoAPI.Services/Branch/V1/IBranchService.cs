using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Branch.V1
{
    public interface IBranchService
    {
        CommonResponse<BranchModel> GetAllBranch();
        BranchModel AddBranch(BranchRequestModel branchRequestModel);
        BranchModel GetBranch(int customerId);
        BranchModel UpdateBranch(BranchRequestModel branchRequestModel);
        BranchModel DeleteBranch(int branchId, int deletedBy);
    }
}
