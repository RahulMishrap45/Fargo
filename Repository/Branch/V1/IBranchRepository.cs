using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Branch.V1
{
    public interface IBranchRepository
    {
        IEnumerable<BranchModel> GetAllBranch();
        BranchModel AddBranch(BranchRequestModel branchRequestModel);
        BranchModel GetBranch(int branchId);
        BranchModel UpdateBranch(BranchRequestModel branchRequestModel);
        BranchModel DeleteBranch(int branchId, int deletedBy);
    }
}
