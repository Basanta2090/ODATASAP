using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    public class UnloadPtCollection
    {
        public UnloadPtCollectionD d { get; set; }
    }

    public class UnloadPtCollectionD
    {
        public IList<Kunnr> results { get; set; }
    }

    public class Kunnr
    {
        public MetaData __metadata { get; set; }
        public string IKunnr { get; set; }
        public Kun2UnloadNav Kun2UnloadNav { get; set; }
    }

    public class UnloadPt
    {
        public MetaData __metadata { get; set; }
        public string Mandt { get; set; }
        public string Locnr { get; set; }
        public string Empst { get; set; }
        public string Kunn2 { get; set; }
        public string Ablad { get; set; }
    }

    public class Kun2UnloadNav
    {
        public IList<UnloadPt> results { get; set; }
    }
}
