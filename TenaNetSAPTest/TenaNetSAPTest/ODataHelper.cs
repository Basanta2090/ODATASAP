using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using TenaNetSAPTest.Entity;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace TenaNetSAPTest
{
    public class ODataHelper
    {

        #region Properties

        //QA
        public string sapUserName = "web_tena";
        public string sapPassword = "Tena_weborder";

        //PROD
        //public string sapUserName = "WEB_TENA";
        //public string sapPassword = "T3n@_w3b0r8e5"; 

        public string csrfToken = "";
        public string setCookie = "";
        public CookieContainer cookieJar;
        public CookieCollection cookiestopass;

        public string csrfTokenOrderSimulate = "";
        public string setCookieOrderSimulate = "";
        public CookieContainer cookieJarOrderSimulate;
        public CookieCollection cookiestopassOrderSimulate;

        #endregion

        #region SAP Endpoints
        //WebConfigurationManager.AppSettings["SAPServiceUrl"].ToString();

        //QA
        public string sapCreateOrderURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderHeadSet()";
        public string sapGetListURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETLIST_SRV/CustDataSet?$format=json&$expand=Cust2SalesNav&$filter=CustomerNumber eq '{0}' and DocumentDate eq '{1}' and DocumentDateTo eq '{2}' and SalesOrganization eq '{3}'&sap-client=006&sap-language=EN";
        public string sapGetStatusURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETSTATUS_SRV/StatusInfoSet";
        public string sapShipToAddressURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZSD_CUST_SHIP_ADRESS_SRV/CustAddressSet?$filter=IKunnr eq'{0}' and IVkorg eq'{1}'&$format=json";
        public string sapGetUnLoadingPointsURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZSD_UNLOADING_POINT_SRV/KunnrSet?$expand=Kun2UnloadNav&$filter=IKunnr eq '{0}'";
        public string sapOrderSimulationPost = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderSimSet()";

        //PROD
        //public string sapCreateOrderURL = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZSD_WEB_SALESORDER_CREATE_SRV/OrderHeadSet()";
        //public string sapGetListURL = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETLIST_SRV/CustDataSet?$format=json&$expand=Cust2SalesNav&$filter=CustomerNumber eq '{0}' and DocumentDate eq '{1}' and DocumentDateTo eq '{2}' and SalesOrganization eq '{3}'&sap-client=006&sap-language=EN";
        //public string sapGetStatusURL = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETSTATUS_SRV/StatusInfoSet";
        //public string sapShipToAddressURL = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZSD_CUST_SHIP_ADRESS_SRV/CustAddressSet?$filter=IKunnr eq'{0}' and IVkorg eq'{1}'&$format=json";
        //public string sapGetUnLoadingPointsURL = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZSD_UNLOADING_POINT_SRV/KunnrSet?$expand=Kun2UnloadNav&$filter=IKunnr eq '{0}'";
        //public string sapOrderSimulationURL = "https://gp1.sap.sca.se:443//sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderSimSet()?$expand=Head2CustNav,Head2ItemsNav,Items2CondNav,Items2ShNav,Head2MsgNav&$format=json";
        //public string sapOrderSimulationPost = "https://gp1.sap.sca.se:443/sap/opu/odata/sap/ZSD_BAPI_SALESORDER_SIMULATE_SRV/OrderSimSet()";

        JsonSerializerSettings settings = new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() };

        #endregion

        #region Private Token Methods

        public void GetCSRFToken()
        {
            string requestURL = sapCreateOrderURL + "?$expand=Head2ItemsNav,Head2TextsNav&$format=json";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJar = new CookieContainer();
            req.CookieContainer = cookieJar;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookie = response.Headers.Get("Set-Cookie");
                    cookiestopass = response.Cookies;
                }
            }

        }

        public void GetCSRFTokenForSimulation()
        {
            string requestURL = sapOrderSimulationPost + "?expand=Head2CustNav,Head2ItemsNav,Head2MsgNav,Head2ItemsNav/Items2CondNav,Head2ItemsNav/Items2ShNav&$format=json";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJarOrderSimulate = new CookieContainer();
            req.CookieContainer = cookieJarOrderSimulate;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    csrfTokenOrderSimulate = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookieOrderSimulate = response.Headers.Get("Set-Cookie");
                    cookiestopassOrderSimulate = response.Cookies;
                }
            }
        }

        #endregion

        #region private Method

        private CustDataCollection GetList(string customerNumber, string documentDate, string documentDateTo, string salesOrg)
        {
            // Get List as per below inputs
            // {0} Customer Number
            // {1} Document Date
            // {2} Document DateTo
            // {3} Material Number
            // {4} Sales Org

            //string requestURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETLIST_SRV/CustDataSet?$format=json&$expand=Cust2SalesNav&$filter=CustomerNumber eq '0000008542' and DocumentDate eq '20160606' and DocumentDateTo eq '20161206' and SalesOrganization eq 'BE68'&sap-client=006&sap-language=EN";

            //string requestURL = "https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZBAPI_SALESORDER_GETLIST_SRV/CustDataSet?$format=json&$expand=Cust2SalesNav&$filter=CustomerNumber eq '11324' and DocumentDate eq '20160501' and DocumentDateTo eq '20160731' and SalesOrganization eq 'NL68'&sap-client=006&sap-language=EN";
            string requestURL = string.Format(sapGetListURL, customerNumber, documentDate, documentDateTo, salesOrg);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJar = new CookieContainer();
            req.CookieContainer = cookieJar;
            CustDataCollection collection = null;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    collection = JsonConvert.DeserializeObject<CustDataCollection>(rawJson);
                    var dat1 = collection.d.results[0].Cust2SalesNav.results;
                    string a = "";
                    string b = null;
                    dat1 = dat1.Where(q => q.ReqSegment.Equals(a)).ToList();
                    dat1 = dat1.Where(q => q.SalesOrg.Equals(b)).ToList();

                    csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookie = response.Headers.Get("Set-Cookie");
                    cookiestopass = response.Cookies;
                }
            }
            return collection;
        }

        private StatusInfoCollection GetStatus(string eSalesDocument)
        {
            // Get Order Satus By eSalesDocumentNumber
            sapGetStatusURL = sapGetStatusURL + "?$filter=Salesdocument eq '{0}'&$format=json";
            string requestURL = string.Format(sapGetStatusURL,eSalesDocument) ;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJar = new CookieContainer();
           // req.CookieContainer = cookieJar;
            StatusInfoCollection collection = null;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    collection = JsonConvert.DeserializeObject<StatusInfoCollection>(rawJson);

                    csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookie = response.Headers.Get("Set-Cookie");
                    cookiestopass = response.Cookies;
                }
            }

            return collection;
        }

        private CustAddressCollection GetShippingAddress(string soldToNumber, string salesOrg)
        {
            // Kunnr SoldToNumber
            // VKorg Sales Organisation

            string requestURL = string.Format(sapShipToAddressURL, soldToNumber, salesOrg);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJar = new CookieContainer();
            req.CookieContainer = cookieJar;
            CustAddressCollection collection = null;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    collection = JsonConvert.DeserializeObject<CustAddressCollection>(rawJson);

                    // To combine the Zero's into the Shipping Number to make as 10 digit number.
                   // var shippingAddr = PadLeft(10, '0');

                    csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookie = response.Headers.Get("Set-Cookie");
                    cookiestopass = response.Cookies;
                }
            }
            return collection;
        }

        private UnloadPtCollection GetUnloadingPoints(string ShipToNumber)
        {
            // https://gq1.sap.sca.se:443/sap/opu/odata/sap/ZSD_UNLOADING_POINT_SRV/KunnrSet?$expand=Kun2UnloadNav&$filter=IKunnr eq '0000329780'
            // Get Unloading Points By ShiptoNumber

            string requestURL = string.Format(sapGetUnLoadingPointsURL, ShipToNumber) + "&$format=json";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(requestURL);
            HttpWebResponse resp; // No Use
            req.Credentials = new NetworkCredential(sapUserName, sapPassword);
            req.Method = "GET";
            req.Headers.Add("X-CSRF-Token", "Fetch");
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            cookieJar = new CookieContainer();
            // req.CookieContainer = cookieJar;
            UnloadPtCollection collection = null;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    collection = JsonConvert.DeserializeObject<UnloadPtCollection>(rawJson);

                    csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                    setCookie = response.Headers.Get("Set-Cookie");
                    cookiestopass = response.Cookies;
                }
            }
            return collection;
        }

        #endregion

        #region Public Methods

        public Order GetStatusFromSAP(string eSalesDocument)
        {
            Order order = new Order();
            try
            {
                // Get Status Info Collection
                StatusInfoCollection statusCollection = GetStatus(eSalesDocument);

                // Map Status to Order Data

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("(400)"))
                {
                    // Bad Request. There is some error on the Input 
                }   
                throw;
            }

            return order;
        }

        public List<Order> GetListFromSAP(string customerNumber, string documentDate, string documentDateTo, string salesOrg)
        {
            List<Order> orderList = new List<Order>();
            try
            {
                // Get Status Info Collection
                CustDataCollection customerDataCollection = GetList(customerNumber, documentDate, documentDateTo, salesOrg);

                foreach (var orederHeader in customerDataCollection.d.results)
                {
                    var date = DateTime.ParseExact(orederHeader.DocumentDate,
                                  "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                    foreach (var orderItem in orederHeader.Cust2SalesNav.results)
                    {
                        
                    }
                }
                // TODO : Map Get List to Order List

            }
            catch (Exception)
            {

                throw;
            }

            return orderList;
        }

        public List<ShipTo> GetShippingAddressFromSAP(string soldToNumber, string salesOrg)
        {
            List<ShipTo> shipToList = new List<ShipTo>();
            try
            {
                CustAddressCollection addressCollection = GetShippingAddress(soldToNumber, salesOrg);

                // TODO: Map the SAP address to entity
                shipToList.Add(new ShipTo() { });
            }
            catch (Exception)
            {
                
                throw;
            }

            return shipToList;
        }

        public List<UnloadingPoint> GetUnloadingPointsFromSAP(string shipToNumber)
        {
            List<UnloadingPoint> unloadingPointList = new List<UnloadingPoint>();
            try
            {
                UnloadPtCollection unloadingPoints = GetUnloadingPoints(shipToNumber);

                foreach (var item in unloadingPoints.d.results)
                {
                    foreach (var innerItem in item.Kun2UnloadNav.results)
                    {
                        
                    }
                }
                // TODO: Map unloading Points

            }
            catch (Exception)
            {
                
                throw;
            }

            return unloadingPointList;
        }

        #endregion

        #region Push Order to SAP

        // This method is using HttpWebRequest to POST Json Data.
        private OrderHead PushOrderToSAP(OrderHeadCollection collection)
        {
            OrderHead orderHeadData = new OrderHead();
            try
            {
                // Get Cookies and csrfToken
                if (string.IsNullOrEmpty(csrfToken))
                {
                    GetCSRFToken();
                }

                // Using the HTTPWebRequest.
                var cookieContainer = new CookieContainer();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sapCreateOrderURL);

                // Add Credentional, Header, Token & Cookies
                req.Credentials = new NetworkCredential(sapUserName, sapPassword);
                req.Method = "POST";
                req.Headers.Add("X-CSRF-Token", csrfToken);
                req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.Accept = "application/json";
                req.ContentType = "application/json";
                cookieContainer.Add(new Uri(sapCreateOrderURL), cookiestopass);
                req.CookieContainer = cookieContainer;

                // Get JSON Data from Entity
                var jsonData = JsonConvert.SerializeObject(collection, settings);

                // Enclding JSON Data
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(jsonData);

                Stream newStream = req.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    // Get the response Content from Webresponse
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        // Deserialize the Response JSON data to Order data.
                        OrderHeadCollection responseCollection = JsonConvert.DeserializeObject<OrderHeadCollection>(rawJson);

                        if (responseCollection != null)
                        {
                            orderHeadData = responseCollection.d;
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        // Log for the bad request.
                        string errorMessage = rawJson;
                        //Log.Info(errorMessage);
                    }
                }
            }
            catch (WebException ex)
            {
                var exceptionJson = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
               
                // Deserialize the Response JSON data to Error Model
                ErrorMessage errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(exceptionJson);

                // Log 
                string message = errorMessage.error.message.value;
                //Log.Info(errorMessage);

            }
            catch (Exception ex)
            {
                // Log the message in case any exception
                //Log.Info(ex.Message);
            }

            return orderHeadData;
        }


        // This method will be called by HttpClient which is only support by Framework 4.0
        private string PushOrderToSAP123(OrderHeadCollection collection)
        {
            string eSalesDocument = string.Empty;

            // Get Cookies and csrfToken
            if (string.IsNullOrEmpty(csrfToken))
            {
                GetCSRFToken();
            }

            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainer, Credentials = new NetworkCredential(sapUserName, sapPassword) })
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(sapCreateOrderURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-CSRF-Token", csrfToken);
                cookieContainer.Add(client.BaseAddress, cookiestopass);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new StringContent(JsonConvert.SerializeObject(collection, settings)
                                                    , UnicodeEncoding.UTF8, "application/json");

                var response = client.PostAsync(client.BaseAddress, httpContent).Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    // Get response data 
                    var responseJsonData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the Response JSON data to Order data.
                    OrderHeadCollection responseCollection = JsonConvert.DeserializeObject<OrderHeadCollection>(responseJsonData);

                    // Get Sales Document 
                    // Check the responseCollection if that is not null
                    eSalesDocument = responseCollection.d.ESalesdocument;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Log for the bad request.
                    string errorMessage = response.Content.ReadAsStringAsync().Result;
                    //Log.Info(errorMessage);
                }
            }

            return eSalesDocument;
        }

        public void ProcessOrder()
        {
            OrderHeadCollection collection = this.FillCreateOrderData();
            try
            {
                //var result = PushOrderToSAP123(collection);

                // Call the SAP Method
               OrderHead orderHeadData = PushOrderToSAP(collection);

             
                // Check if Sales Doc is not Zero. Then Pass the Sales Doc
                // If the Sales Doc is Zero, then Log the message

               if (orderHeadData.ESalesdocument != "0")
               {
                   // Pass the Sales Document
               }
               else
               {
                   // Log the Message.
                   string message = orderHeadData.EText;
               }
            }
            catch (Exception ex)
            {
                // Need to log the exception details.

                throw ex;
            }

        }

        private OrderHeadCollection FillCreateOrderData()
        {
            OrderHeadCollection collection = new OrderHeadCollection();
            collection.d = new OrderHead();

            // Fill Create Order Data.

            // Get the Order from Database.
            OrderHead orderdata = new OrderHead();

            // Order No , CustLineref and CustItemref needs to be unique to push Order to SAP.
            // ** OrderNo (mandatory)
            // ** SalesOrg (mandatory)
            // ** SoldTo (mandatory)
            //    ShipTo Address

            // Region - SalesOrgNumberProdCat **
            orderdata.Region = "NL068";
            // Order No Should be Unique **
            orderdata.Orderno = "15";
            // CUSTID - Sold to Number **
            orderdata.Custid = "1421200";
            // Ship to Number
            orderdata.Ardrno = "";

            orderdata.Orderdate = "00000000";
            orderdata.Deliverydate = "00000000";

            // Should be Unique
            orderdata.Custlineref = "Ref 123 with error text test"; // This shoudl be testing error purpose
             
            orderdata.Goodsaddr1 = "";
            orderdata.Goodsaddr2 = "";
            orderdata.Goodsaddr3 = "";
            orderdata.Goodsaddr4 = "";
            orderdata.Autlf = false;

            // If the Unloading Point is valid then add below EMPst & Ablad
            orderdata.Empst = "UNLOADING POINT 1";
            orderdata.Ablad = "UNLOADING POINT 1";

            orderdata.Inco1 = "";
            orderdata.Zfig = false;
            orderdata.Type = "";
            orderdata.Id = "";
            orderdata.Number = "000";
            orderdata.Message = "";
            orderdata.LogNo = "";
            orderdata.LogMsgNo = "000000";
            orderdata.MessageV1 = "";
            orderdata.MessageV2 = "";
            orderdata.MessageV3 = "";
            orderdata.MessageV4 = "";
            orderdata.ESalesdocument = "";
            orderdata.EText = "";

            // Fill Head2ItemNav 
            // Loop all Order Item and add into Head2IteamsNav
            orderdata.Head2ItemsNav = new List<Head2ItemsNav>();

            Head2ItemsNav orderItem = new Head2ItemsNav();

            // Basic Fields 
            orderItem.Lineno = "000000";
            orderItem.Artno = "725222";
            orderItem.Ordergty = "1";
            orderItem.Qtytype = "TRP";

            // CustItemref should be Unique - Residence Name
            orderItem.Custitemref = "TESToDATA 15";

            orderItem.CondValue = "0.000000000";
            orderItem.Currency = "";
            orderItem.CondUnit = "";
            orderItem.CondPUnt = "0";
            orderdata.Head2ItemsNav.Add(orderItem);

            // Fill Order Note Item
            // Loop on Order Note to add into Head2TextNav.

            orderdata.Head2TextsNav = new List<Head2TextsNav>();
            Head2TextsNav noteItem = new Head2TextsNav();
            noteItem.Tdline = "Test Note";
            noteItem.Tdformat = "/";
            orderdata.Head2TextsNav.Add(noteItem);

            // Push Create Order to collection
            collection.d = orderdata;

            //var jsonData = JsonConvert.SerializeObject(collection, settings);
            return collection;
        }

        #endregion

        #region Order Simulate 

        // This method using WebRequest
        private OrderSimOutCollection OrderSimulateToSAP(OrderSimInputCollection collection)
        {
            OrderSimOutCollection orderSimOutCollection = new OrderSimOutCollection();

            try
            {
                // Get Cookies and csrfToken
                if (string.IsNullOrEmpty(csrfTokenOrderSimulate))
                {
                    GetCSRFTokenForSimulation();
                }

                // Using the HTTPWebRequest.
                var cookieContainerOrderSimulate = new CookieContainer();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sapOrderSimulationPost);

                // Add Credentional, Header, Token & Cookies
                req.Credentials = new NetworkCredential(sapUserName, sapPassword);
                req.Method = "POST";
                req.Headers.Add("X-CSRF-Token", csrfTokenOrderSimulate);
                req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                req.Accept = "application/json";
                req.ContentType = "application/json";
                cookieContainerOrderSimulate.Add(new Uri(sapOrderSimulationPost), cookiestopassOrderSimulate);
                req.CookieContainer = cookieContainerOrderSimulate;

                // Get Order Simulate JSON Data from Entity
                var jsonData = JsonConvert.SerializeObject(collection, settings);

                // Enclding JSON Data
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(jsonData);

                Stream newStream = req.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    // Get the response Content from Webresponse
                    var rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        // Deserialize the Response JSON data to Order data.
                        OrderSimOutCollection responseCollection = JsonConvert.DeserializeObject<OrderSimOutCollection>(rawJson);

                        if (responseCollection != null)
                        {
                            orderSimOutCollection = responseCollection;
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        // Log for the bad request.
                        string errorMessage = rawJson;
                        //Log.Info(errorMessage);
                    }
                }

            }
            catch (WebException webex)
            {
                var exceptionJson = new StreamReader(webex.Response.GetResponseStream()).ReadToEnd();

                // Deserialize the Response JSON data to Error Model
                ErrorMessage errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(exceptionJson);

                // Log 
                string message = errorMessage.error.message.value;
                //Log.Info(errorMessage);
            }
            catch (Exception ex)
            {
                // Log the message in case any exception
                //Log.Info(ex.Message);
            }

            return orderSimOutCollection;
        }

        //This Method using Http_Client
        private Order OrderSimulateToSAP_HttpClient(OrderSimInputCollection collection)
        {
            Order orderSimulate = new Order();
            // Get Cookies and csrfToken
            if (string.IsNullOrEmpty(csrfTokenOrderSimulate))
            {
                GetCSRFTokenForSimulation();
            }

            var cookieContainerOrderSimulate = new CookieContainer();
            using (var handler = new HttpClientHandler { CookieContainer = cookieContainerOrderSimulate, Credentials = new NetworkCredential(sapUserName, sapPassword) })
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(sapOrderSimulationPost);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-CSRF-Token", csrfTokenOrderSimulate);
                cookieContainerOrderSimulate.Add(client.BaseAddress, cookiestopassOrderSimulate);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var httpContent = new StringContent(JsonConvert.SerializeObject(collection, settings)
                                                    , UnicodeEncoding.UTF8, "application/json");

                var response = client.PostAsync(client.BaseAddress, httpContent).Result;

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    // Get response data 
                    var responseJsonData = response.Content.ReadAsStringAsync().Result;

                    // Deserialize the Response JSON data to OrderSimCollection.
                    OrderSimOutCollection responseCollection = JsonConvert.DeserializeObject<OrderSimOutCollection>(responseJsonData);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Log for the bad request.
                    var message = response.Content.ReadAsStringAsync().Result;
                    // Log Message
                }
            }
            return orderSimulate;
            
        }

        private OrderSimInputCollection FillCreateOrderSimulateData()
        {
            // Fill Order Header.
            // Fill Order Item.
            // Fill Order Partner. Create Partner by Partner Role, Ship To and SoldTo.
           
            // Keep Order Schedulein Empty.
            // Keep Extension empty.
            // Keep Message Table empty.
            // Keep Order Card  empty.
            // Keep orderCcardEx  empty.
            // Keep orderCfgsBlob empty
            // Keep orderCfgsInst empty
            // Keep orderCfgsPartOf empty
            // Keep orderCfgsRef empty
            // Keep orderCfgsValue empty
            // Keep orderConditionEx empty
            // Keep orderIncomplete empty
            // Keep partneraddresses empty


            OrderSimInputCollection collection = new OrderSimInputCollection();
            
            // Fill Order Simulate Data.
            OrderSimInput orderSimulate = new OrderSimInput();

            // Bind OrderHead

            // Sales Org
            orderSimulate.SalesOrg = "NL68";

            // Dist Chain
            orderSimulate.DistrChan = "01";
            //Division 
            orderSimulate.Division = "00";
            //Complete DLV
            orderSimulate.ComplDlv = true;

            // Sales Document Type 
            orderSimulate.DocType = "OR";

            // Fill Head2ItemNav 
            // Do foreach loop for the Order Iteam
            orderSimulate.Head2ItemsNav = new List<OrderSimInOrderItems>();

            // Generate ItemSimulate
            OrderSimInOrderItems itemSimulate = new OrderSimInOrderItems(){
             // Bind Meta Data
             //NetValue = "000000000000000",
             //QtyReqDt ="0000000000000",
             //DlvDate ="",
             NetValue1 = "0.0000",
             ItmNumber = "000010",
             Material = "760406*",// 760226*
             ReqQty = "0000000000100",
             SalesUnit = "CON"
            };
            orderSimulate.Head2ItemsNav.Add(itemSimulate);


            // Fill Items2CondNav
            orderSimulate.Items2CondNav = new List<OrderSimInOrderCond>();
            OrderSimInOrderCond itemCondNav = new OrderSimInOrderCond() {
                // Bind Meta Data
                ItmNumber = "000000",
                CondType="",
                CondValue = "0.000000000",
                Condvalue = "0.000000000"
            };

            orderSimulate.Items2CondNav.Add(itemCondNav);

            //Fill Item2ShNav
            orderSimulate.Items2ShNav = new List<OrderSimInOrderSh>();
            OrderSimInOrderSh item2shNav = new OrderSimInOrderSh() {
                // Bind Meta Data
                ItmNumber ="000000",
                SchedLine ="0000",
                ReqDate ="",
                ReqQty ="0.000",
                ConfirQty ="0.000"
            };
            orderSimulate.Items2ShNav.Add(item2shNav);

            // Fill Head2MsgNav
            orderSimulate.Head2MsgNav = new List<OrderSimInMessages>();
            OrderSimInMessages head2MsgNav = new OrderSimInMessages() {
                // Bind Meta Data
                Type = "",
                Code ="",
                Message ="",
                LogNo ="",
                LogMsgNo = "000000",
                MessageV1 = "",
                MessageV2 = "",
                MessageV3 = "",
                MessageV4 = ""
            };
            orderSimulate.Head2MsgNav.Add(head2MsgNav);

            // Fill Head2CustNav
            orderSimulate.Head2CustNav = new List<OrderSimInOrderPartners>();

            // There are 2 Cust Nav .
            //Sold To - SP
            OrderSimInOrderPartners head2CustNavSP = new OrderSimInOrderPartners()
            {
                // Bind Sold To - SP
                PartnRole ="AG", //"SP",
                PartnNumb = "155580"
            };
            orderSimulate.Head2CustNav.Add(head2CustNavSP);

            // Fil the  Ship to - SH 
            OrderSimInOrderPartners head2CustNavSH = new OrderSimInOrderPartners()
            {
                // Bind  Ship to - SH
                PartnRole ="WE",// "SH",
                PartnNumb = "1286277"
            };
            orderSimulate.Head2CustNav.Add(head2CustNavSH);

            // Add OrderSimulate to OrderSimulate Object
            collection.d = orderSimulate;

            //var jsonData = JsonConvert.SerializeObject(collection, settings);
            
            return collection;
        }

        public void ProcessOrderSimulate()
        {
            OrderSimOutCollection orderSimOutCollection = new OrderSimOutCollection();
           
            // Fill the Order collect 
            OrderSimInputCollection collection = this.FillCreateOrderSimulateData();
            try
            {
                // Push and get Order to SAP for Simulate 
                orderSimOutCollection = OrderSimulateToSAP(collection);

                // todo : Now Map all Order Data as per the IQL Mapping


            }
            catch (Exception ex)
            {
                // Need to log the exception details.

                throw ex;
            }
        }

        #endregion
    }
}
