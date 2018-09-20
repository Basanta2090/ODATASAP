using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    public class StatusInfoCollection
    {
        public StatusInfoCollectionD d { get; set; }
    }

    public class StatusInfoCollectionD {

        public IList<StatusInfo> results { get; set; }
    }

    public class StatusInfo
    {
        public MetaData __metadata { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime ReqDateH { get; set; }
        public DateTime ReqDate { get; set; }
        public DateTime DelivDate { get; set; }
        public object CreationDate { get; set; }
        public string ReqQty { get; set; }
        public string CumCfQty { get; set; }
        public string NetValue { get; set; }
        public string NetPrice { get; set; }
        public string CondPUnt { get; set; }
        public string DlvQty { get; set; }
        public string RefQty { get; set; }
        public string Salesdocument { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string LogNo { get; set; }
        public string LogMsgNo { get; set; }
        public string MessageV1 { get; set; }
        public string MessageV2 { get; set; }
        public string MessageV3 { get; set; }
        public string MessageV4 { get; set; }
        public string DocNumber { get; set; }
        public string PurchNo { get; set; }
        public string PrcStatH { get; set; }
        public string DlvStatH { get; set; }
        public string DlvBlock { get; set; }
        public string ItmNumber { get; set; }
        public string Material { get; set; }
        public string ShortText { get; set; }
        public string SalesUnit { get; set; }
        public string Currency { get; set; }
        public string CondUnit { get; set; }
        public string DlvStatI { get; set; }
        public string DelivNumb { get; set; }
        public string DelivItem { get; set; }
        public string SUnitIso { get; set; }
        public string CdUntIso { get; set; }
        public string CurrIso { get; set; }
        public string MaterialExternal { get; set; }
        public string MaterialGuid { get; set; }
        public string MaterialVersion { get; set; }
        public string PoItmNo { get; set; }
        public string SUnitDlv { get; set; }
        public string DlvUnitIso { get; set; }
        public string ReaForRe { get; set; }
        public string PurchNoC { get; set; }
        public string CreationTime { get; set; }

    }
}
