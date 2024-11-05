using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Data_Protection
{
    public class DataProtection : IDataProtection
    {
        private readonly IDataProtector _dataProtector;

        public DataProtection(IDataProtectionProvider provider)
        {
            _dataProtector = provider.CreateProtector("security");
        }
        public string Protect(string text)
        {
            return _dataProtector.Protect(text);
        }

        public string UnProtect(string protectedText)
        {
            return _dataProtector.Unprotect(protectedText);
        }
    }
}
