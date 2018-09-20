using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    public class OrderSimInputCollection
    {
        public OrderSimInput d { get; set; }
    }

    // ORDER Header IN
    public class OrderSimInput
    {
        public MetaData __metadata { get; set; }
        public OrderSimInput()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderSimSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderSimSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.OrderSim";

            // Initialize Collection objects
            Head2ItemsNav = new List<OrderSimInOrderItems>();
            Items2CondNav = new List<OrderSimInOrderCond>();
            Items2ShNav = new List<OrderSimInOrderSh>();
            Head2MsgNav = new List<OrderSimInMessages>();
            Head2CustNav = new List<OrderSimInOrderPartners>();


        }

        // Mandatory parameters
        public string SalesOrg { get; set; }
        public string DocType { get; set; } 
        public string DistrChan { get; set; }
        public string Division { get; set; }
        public bool ComplDlv { get; set; }
        
        public IList<OrderSimInOrderItems> Head2ItemsNav { get; set; }
        public IList<OrderSimInOrderCond> Items2CondNav { get; set; }
        public IList<OrderSimInOrderSh> Items2ShNav { get; set; }
        public IList<OrderSimInMessages> Head2MsgNav { get; set; }
        public IList<OrderSimInOrderPartners> Head2CustNav { get; set; }
    }
    
    // Order Iteam 
    public class OrderSimInOrderItems
    {
        public MetaData __metadata { get; set; }
        public OrderSimInOrderItems()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderItemsSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderItemsSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.OrderItems";
        }
       
        // Mandatory parameters
        public string ItmNumber { get; set; }
        public string Material { get; set; }
        public string ReqQty { get; set; }
        public string SalesUnit { get; set; }

        public string NetValue { get; set; }
        public string QtyReqDt { get; set; }
        public string DlvDate { get; set; }
        public string NetValue1 { get; set; }
    }

    public class OrderSimInOrderCond
    {
        public OrderSimInOrderCond()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderCondSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderCondSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.OrderCond";
        }
        public MetaData __metadata { get; set; }
        public string ItmNumber { get; set; }
        public string CondType { get; set; }
        public string CondValue { get; set; }
        public string Condvalue { get; set; }
    }

    public class OrderSimInOrderSh
    {
        public OrderSimInOrderSh()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderShSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderShSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.OrderSh";
        }
        public MetaData __metadata { get; set; }
        public string ItmNumber { get; set; }
        public string SchedLine { get; set; }
        public string ReqDate { get; set; }
        public string ReqQty { get; set; }
        public string ConfirQty { get; set; }
    }

    public class OrderSimInMessages
    {
        public OrderSimInMessages()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/MessagesSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/MessagesSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.Messages";
        }
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

    // BAPIPARTNR
    public class OrderSimInOrderPartners
    {
        // Order Partners contain both Ship to and Sold To
        public OrderSimInOrderPartners()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderPartnersSet('')";
            __metadata.uri = "https://gd1.sap.sca.se:8010/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderPartnersSet('')";
            __metadata.type = "ZSD_BAPI_SALESORDER_SIMULATE_SRV.OrderPartners";
        }
        public MetaData __metadata { get; set; }

        //Mandatory parameters
        public string PartnRole { get; set; }
        public string PartnNumb { get; set; }
    }

}
