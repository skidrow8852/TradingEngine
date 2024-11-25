using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    // Readonly representation of an Order
    public record OrderRecord(long OrderId, uint Quantity, long Price, bool isBuySide, string Username, int SecurityId, uint TheoreticalQueuePosition);
 
}
