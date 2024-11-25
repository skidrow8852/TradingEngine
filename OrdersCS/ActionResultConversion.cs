using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public sealed class ActionResultConversion
    {
        public static CancelOrderStatus GenerateCancelOrderStatus(CancelOrder cancelOrder) 
        {
            return new CancelOrderStatus();
        }

        public static NewOrderStatus GenerateOrderStatus(Order order) 
        { 
            return new NewOrderStatus(); 
        }  

        public static ModifyOrderStatus GenerateModifyOrderStatus(ModifyOrder modifyOrder) 
        { 
            return new ModifyOrderStatus(); 
        }      
    }
}
