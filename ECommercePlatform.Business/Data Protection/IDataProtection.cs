using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Business.Data_Protection
{
    public interface IDataProtection
    {
        string Protect(string text);
        string UnProtect(string protectedText);

    }
}
