using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Domain.Enum
{
    public enum StatusCode
    {   OK = 1,

        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        InternalServerError = 500,
        ServiceUnavailable = 503,
        Created = 201,
        NoContent = 204,
        ProductNotFound = 1001,
        ProductAlreadyExists = 1002,
    }
}
