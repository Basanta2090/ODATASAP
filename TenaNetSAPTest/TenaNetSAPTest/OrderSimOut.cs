using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    public class OrderSimOutCollection
    {
        public OrderSimOut d { get; set; }
    }

    public class OrderSimOut
    {
        public MetaData __metadata { get; set; }
        public string SalesOrg { get; set; }
        public string DocType { get; set; }
        public string DistrChan { get; set; }
        public string Division { get; set; }
        public bool ComplDlv { get; set; }
        public OrderSimOutOrderItemsCollection Head2ItemsNav { get; set; }
        public OrderSimOutOrderCondCollection Items2CondNav { get; set; }
        public OrderSimOutOrderShCollection Items2ShNav { get; set; }
        public OrderSimOutMessagesCollection Head2MsgNav { get; set; }
        public OrderSimOutOrderPartnersCollection Head2CustNav { get; set; }
    }

    // OrderItemsOut  :OK . Coming
    public class OrderSimOutOrderItems
    {
        public MetaData __metadata { get; set; }
        public string ItmNumber { get; set; }
        public string Material { get; set; }
        public string NetValue { get; set; }
        public string NetValue1 { get; set; }
        public string DlvDate { get; set; }
        public string ReqQty { get; set; }
        public string QtyReqDt { get; set; }
        public string SalesUnit { get; set; }
    }

    public class OrderSimOutOrderItemsCollection
    {
        public IList<OrderSimOutOrderItems> results { get; set; }
    }

    // OrderCondOut :OK - 
    public class OrderSimOutOrderCond
    {
        public MetaData __metadata { get; set; }
        public string ItmNumber { get; set; }
        public string CondType { get; set; }
        public string CondValue { get; set; }
        public string Condvalue { get; set; }
    }

    public class OrderSimOutOrderCondCollection
    {
        public IList<OrderSimOutOrderCond> results { get; set; }
    }

    // Order SchedulesOut :OK -  
    public class OrderSimOutOrderSh
    {
        public MetaData __metadata { get; set; }
        public string ItmNumber { get; set; }
        public string SchedLine { get; set; }
        public string ReqDate { get; set; }
        public string ReqQty { get; set; }
        public string ConfirQty { get; set; }
    }

    public class OrderSimOutOrderShCollection
    {
        public IList<OrderSimOutOrderSh> results { get; set; }
    }

    public class OrderSimOutMessages
    {
        public MetaData __metadata { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string LogNo { get; set; }
        public string LogMsgNo { get; set; }
        public string MessageV1 { get; set; }
        public string MessageV2 { get; set; }
        public string MessageV3 { get; set; }
        public string MessageV4 { get; set; }
    }

    public class OrderSimOutMessagesCollection
    {
        public IList<OrderSimOutMessages> results { get; set; }
    }

 

    public class OrderSimOutOrderPartners
    {
        // Order Partners contain both Ship to and Sold To
        public MetaData __metadata { get; set; }
        public string PartnRole { get; set; }
        public string PartnNumb { get; set; }
    }

    public class OrderSimOutOrderPartnersCollection
    {
        public IList<OrderSimOutOrderPartners> results { get; set; }
    }
}
