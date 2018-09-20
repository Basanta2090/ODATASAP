using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{

    public class CustAddressCollection
    {
        public CustAddressCollectionD d { get; set; }
    }

    public class CustAddressCollectionD
    {
        public IList<CustAddress> results { get; set; }
    }

    public class CustAddress
    {
        public MetaData __metadata { get; set; }

        public string IKunnr { get; set; }
        public string IVkorg { get; set; }
        public string Custno { get; set; }
        public string Goodsaddrno { get; set; }
        public string Goodsaddr1 { get; set; }
        public string Goodsaddr2 { get; set; }
        public string Goodsaddr3 { get; set; }
        public string Goodsaddr4 { get; set; }
    }
}
