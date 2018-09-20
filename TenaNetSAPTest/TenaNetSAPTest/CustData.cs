using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    public class CustDataCollection
    {
        public CustDataCollectionD d { get; set; }
    }


    public class CustDataCollectionD
    {
        public List<CustData> results { get; set; }
    }

    public class CustData
    {
        public MetaData __metadata { get; set; }
        public Return Return { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentDate { get; set; }
        public string DocumentDateTo { get; set; }
        public string Material { get; set; }
        public string PurchaseOrder { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string SalesOrganization { get; set; }
        public string TransactionGroup { get; set; }
        public Cust2SalesNav Cust2SalesNav { get; set; }

    }

    public class Return
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

    public class Cust2SalesNav
    {
        public IList<Cust2SalesNavItem> results { get; set; }
    }

    public class Cust2SalesNavItem
    {
        public MetaData __metadata { get; set; }
        public string CreationTime { get; set; }
        public string SoldTo { get; set; }
        public string SdDoc { get; set; }
        public string ItmNumber { get; set; }
        public string Material { get; set; }
        public string ShortText { get; set; }
        public string DocType { get; set; }
        public string PurchNo { get; set; }
        public string Batch { get; set; }
        public string BillBlock { get; set; }
        public string DlvBlock { get; set; }
        public string Name { get; set; }
        public string BaseUom { get; set; }
        public string CondUnit { get; set; }
        public string Division { get; set; }
        public string DocStatus { get; set; }
        public string SalesGrp { get; set; }
        public string SalesOff { get; set; }
        public string SalesOrg { get; set; }
        public string SalesUnit { get; set; }
        public string ShipPoint { get; set; }
        public string DistrChan { get; set; }
        public string Currency { get; set; }
        public string Plant { get; set; }
        public string StoreLoc { get; set; }
        public string OrdReason { get; set; }
        public string ReasonRej { get; set; }
        public string BUomIso { get; set; }
        public string CdUntIso { get; set; }
        public string SUnitIso { get; set; }
        public string CurrIso { get; set; }
        public string PurchNoC { get; set; }
        public string MatExt { get; set; }
        public string MatGuid { get; set; }
        public string MatVers { get; set; }
        public string StatusDoc { get; set; }
        public string ReqSegment { get; set; }
        public string ReqQty { get; set; }
        public string ExchgRate { get; set; }
        public string DlvQty { get; set; }
        public string NetPrice { get; set; }
        public string CondPUnt { get; set; }
        public string NetValHd { get; set; }
        public string NetValue { get; set; }
        public string ExchgRateV { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? ReqDate { get; set; }
        public object ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime? GiDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }

}
