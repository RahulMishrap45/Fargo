using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    /// <summary>
    /// For Crud Operation Through Single SP
    /// </summary>
    public enum enmCRUDAction
    {
        Select = 0,
        Add = 1,
        Update = 2,
        Delete = 3,
        GetById = 4,
        HideShowFieldForUsers = 5
    }
}
