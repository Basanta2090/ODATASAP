using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenaNetSAPTest.Entity
{
    public class Message
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Application
    {
        public string component_id { get; set; }
        public string service_namespace { get; set; }
        public string service_id { get; set; }
        public string service_version { get; set; }
    }

    public class ErrorResolution
    {
        public string SAP_Transaction { get; set; }
        public string SAP_Note { get; set; }
    }

    public class Innererror
    {
        public Application application { get; set; }
        public string transactionid { get; set; }
        public string timestamp { get; set; }
        public ErrorResolution Error_Resolution { get; set; }
        public IList<object> errordetails { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public Message message { get; set; }
        public Innererror innererror { get; set; }
    }

    public class ErrorMessage
    {
        public Error error { get; set; }
    }
}
