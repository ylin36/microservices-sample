using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Service.Services.Interfaces
{
    public interface IMessageService
    {
        Task Consume();
    }
}
