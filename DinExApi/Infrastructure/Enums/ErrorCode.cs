using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Infrastructure.Enums
{
    public enum ErrorCode
    {
        // if there is no error
        Empty = 0,

        // if any structural error happens
        ErrorToSave = 1,
        HasAlreadyExists = 2,
    }
}
