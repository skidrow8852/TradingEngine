﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class Order: IOrderCore
    {
        public Order(IOrderCore orderCore, long price, uint quantity, bool isBuySide) 
        {
            Price = price;
            isBuySide = isBuySide;
            CurrentQuantity = quantity;
            InitialQuantity = quantity; 

            _orderCore = orderCore;
        
        }

        public Order(ModifyOrder modifyOrder) : this(modifyOrder, modifyOrder.Price, modifyOrder.Quantity, modifyOrder.IsBuySide) { }
        public long Price { get; private set; }
        public uint InitialQuantity { get; private set; }

        public uint CurrentQuantity { get; private set; }
        public bool IsBuySide { get; private set; }

        public long OrderId => _orderCore.OrderId;
        public string Username => _orderCore.Username;
        public int SecurityId => _orderCore.SecurityId;
        public void IncreaseQuantity(uint quantityData)
        {
            CurrentQuantity += quantityData;
        }

        public void DecreaseQuantity(uint quantityDelta)
        {
            if(quantityDelta > CurrentQuantity)
            {
                throw new InvalidOperationException($"Quantity Delta ? Current Quantity for OrderId={OrderId}");
            }
            CurrentQuantity -= quantityDelta;
        }

        private readonly IOrderCore _orderCore;
    }
}
