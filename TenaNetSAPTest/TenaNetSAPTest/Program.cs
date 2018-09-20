using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ODataHelper test = new ODataHelper();
            //test.GetCSRFToken();
            //test.GetOrderSchema();
            //test.GetListFromSAP("11324", "20160501", "20160731", "71052122", "NL68");
            //test.GetListFromSAP("0000155812", "20180601", "20180720", "NL68");
            //test.GetStatusFromSAP("1002119901");
            //test.GetShippingAddressFromSAP("0000008610", "BE068");
            //test.GetShippingAddressFromSAP("0000012121", "BE068");
            //test.GetShippingAddressFromSAP("801645", "IT068");
            //test.ProcessOrder();
            test.GetUnloadingPointsFromSAP("0000329780"); //Getting Data
            //test.GetUnloadingPointsFromSAP("0000329780");
            //test.GetCSRFTokenForSimulation();
           //test.ProcessOrderSimulate();
        }
    }
}
