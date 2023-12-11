using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDotNet.Common.Objects
{
    public class RequestDtoBase
    {
        private string? _userID;

        public string? GetUserID()
        {
            return _userID;
        }

        public void SetUserID(string? userID)
        {
            _userID = userID;
        }
    }
}
