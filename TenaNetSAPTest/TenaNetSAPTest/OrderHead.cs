using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{

    public class Head2ItemsNav
    {
        public MetaData __metadata { get; set; }
        public Head2ItemsNav()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderItemsSet('')";
            __metadata.uri = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderItemsSet('')";
            __metadata.type = "ZSD_WEB_SALESORDER_CREATE_SRV.OrderItems";
        }
        public string Lineno { get; set; }
        public string Artno { get; set; }
        public string Ordergty { get; set; }
        public string Qtytype { get; set; }
        public string CondValue { get; set; }
        public string Currency { get; set; }
        public string CondUnit { get; set; }
        public string CondPUnt { get; set; }
        public string Custitemref { get; set; }
    }

    public class Head2TextsNav
    {
        public MetaData __metadata { get; set; }
        public Head2TextsNav()
        {
            __metadata = new MetaData();
            __metadata.id = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderTextsSet('')";
            __metadata.uri = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderTextsSet('')";
            __metadata.type = "ZSD_WEB_SALESORDER_CREATE_SRV.OrderTexts";
        }
        public string Tdformat { get; set; }
        public string Tdline { get; set; }
    }

    public class OrderHead
    {
        public MetaData __metadata { get; set; }
        public IList<Head2ItemsNav> Head2ItemsNav { get; set; }
        public IList<Head2TextsNav> Head2TextsNav { get; set; }

        public OrderHead()
        {
            __metadata = new MetaData();
            __metadata.uri = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderHeadSet('')";
            __metadata.id = "https://gq1.sap.sca.se/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderHeadSet('')";
            __metadata.type = "ZSD_WEB_SALESORDER_CREATE_SRV.OrderHead";

            Head2ItemsNav = new List<Head2ItemsNav>();
            Head2TextsNav = new List<Head2TextsNav>();

        }
        public string Region { get; set; }
        public string Orderno { get; set; }
        public string Orderdate { get; set; }
        public string Deliverydate { get; set; }
        public string Custlineref { get; set; }
        public string Custid { get; set; }
        public string Ardrno { get; set; }
        public string Goodsaddr1 { get; set; }
        public string Goodsaddr2 { get; set; }
        public string Goodsaddr3 { get; set; }
        public string Goodsaddr4 { get; set; }
        public bool Autlf { get; set; }
        public string Empst { get; set; }
        public string Ablad { get; set; }
        public string Inco1 { get; set; }
        public bool Zfig { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public string LogNo { get; set; }
        public string LogMsgNo { get; set; }
        public string MessageV1 { get; set; }
        public string MessageV2 { get; set; }
        public string MessageV3 { get; set; }
        public string MessageV4 { get; set; }
        public string ESalesdocument { get; set; }
        public string EText { get; set; }
    }

    public class OrderHeadCollection
    {
        public OrderHead d { get; set; }
    }
}
