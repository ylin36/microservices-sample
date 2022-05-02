using MSS.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.Service.Services.Classes
{
    public class CoreService : ICoreService
    {
        private IMessageService MessageService { get; set; }
        public CoreService(IMessageService messageService)
        {
            MessageService = messageService;
        }

        public async Task Run()
        {
            MessageService.Consume();
        }
    }
}
