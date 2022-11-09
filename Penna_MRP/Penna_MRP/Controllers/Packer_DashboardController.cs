using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Penna_Common;
using Penna_Business;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.Reflection;
using System.Net;
using System.IO.Ports;
using System.Threading;

namespace Penna_MRP.Controllers
{
    //[Authorize(Roles = "2")]
    public class Packer_DashboardController :BaseController 
    {
        private Penna_BusinessLayer _Penna_BusinessLayer;
        private NetworkStream stream;
        private System.Net.Sockets.TcpClient client;
        //private SerialPort _serialPort;
        public Packer_DashboardController()
        {
            _Penna_BusinessLayer = new Penna_BusinessLayer(base.ConnectionString);
        }

        public ActionResult Index()
        {
            try
            {
                //SAP();
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                GetDeliveryNo("");
               
                return View(_Penna_PackerDetails);
            }
            catch(Exception ex)
            {
                ViewBag.err = ex;
                LogInfo.LogMsg = string.Format("Packer Dashboard / Index : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View();
            }
            
        }
        public ActionResult GetDeliveryNo(string DeliveryNo)
        {
         try
            {
                ViewBag.DeliveryNo = DeliveryNo;
                
                var DeliveryNoList1 = new List<SelectListItem>();
                var DeliveryNoList2 = new List<SelectListItem>();
                var DeliveryNoList3 = new List<SelectListItem>();
                var DeliveryNoList4 = new List<SelectListItem>();
                var DeliveryNoList5 = new List<SelectListItem>();
                var packer = new List<SelectListItem>();
                List<Penna_PackerDetails> result = new List<Penna_PackerDetails>();

                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                result = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);

                foreach (var element in result)
                {

                    DeliveryNoList1.Add(new SelectListItem
                    {
                        Text = element.Delivery_Number,
                        Value = Convert.ToString(element.packing_Status_details_PKID),

                    });
                    DeliveryNoList2.Add(new SelectListItem
                    {
                        Text = element.Delivery_Number,
                        Value = Convert.ToString(element.packing_Status_details_PKID),

                    });
                    DeliveryNoList3.Add(new SelectListItem
                    {
                        Text = element.Delivery_Number,
                        Value = Convert.ToString(element.packing_Status_details_PKID),

                    });
                    DeliveryNoList4.Add(new SelectListItem
                    {
                        Text = element.Delivery_Number,
                        Value = Convert.ToString(element.packing_Status_details_PKID),

                    });
                    DeliveryNoList5.Add(new SelectListItem
                    {
                        Text = element.Delivery_Number,
                        Value = Convert.ToString(element.Delivery_Number),

                    });

                }
                packer.Add(new SelectListItem
                {
                    Text = "packer1",
                    Value = "1",

                });
                packer.Add(new SelectListItem
                {
                    Text = "packer2",
                    Value = "2",

                });
                packer.Add(new SelectListItem
                {
                    Text = "packer3",
                    Value = "3",

                });
                packer.Add(new SelectListItem
                {
                    Text = "packer4",
                    Value = "4",

                });
                ViewBag.DeliveryNo1 = DeliveryNoList1;
                ViewBag.DeliveryNo2 = DeliveryNoList2;
                ViewBag.DeliveryNo3 = DeliveryNoList3;
                ViewBag.DeliveryNo4 = DeliveryNoList4;
                ViewBag.DeliveryNo5 = DeliveryNoList5;
                ViewBag.packer = packer;
                return View();
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / GetDeliveryNo : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                return View();
            }
        }
      
        public ActionResult GetPacker()
        {
            try
            {
                var Package_Details_PKID = Request.Form["ID"];
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                penna_PackerDetails.packing_Status_details_PKID = Convert.ToInt32(Package_Details_PKID);
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                _Penna_PackerDetails = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails);
                foreach (var element in _Penna_PackerDetails)
                {
                    penna_PackerDetails.Vehicle_Number = element.Vehicle_Number;
                    penna_PackerDetails.MRP = element.MRP;
                    penna_PackerDetails.Grade = element.Grade;
                    penna_PackerDetails.Set_Count = element.Set_Count;
                    penna_PackerDetails.Status = element.Status;
                    penna_PackerDetails.Bag_Count = element.Bag_Count;
                }
                  return Json(new { penna_PackerDetails }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / GetPacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View();
            }

        }

        public ActionResult Startpacker()
        {
            try
            {
               //getdata();
                ViewBag.result = "0";
                var Package_Details_PKID = Request.Form["ID"];
                var Packer = Request.Form["Packer"];
                var NoofBustedbags = Request.Form["NoofBustedbags"];


                Penna_PackerDetails penna_PackerDetails2 = new Penna_PackerDetails();
                Penna_PackerDetails_send PackerDetails = new Penna_PackerDetails_send();
                penna_PackerDetails2.packing_Status_details_PKID = Convert.ToInt32(Package_Details_PKID);

                List<Penna_PackerDetails> _Penna_PackerDetails2 = new List<Penna_PackerDetails>();
                _Penna_PackerDetails2 = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails2);
                List<Penna_ManageSettings> _Penna_ManageSettings2 = new List<Penna_ManageSettings>();
                _Penna_ManageSettings2 = _Penna_BusinessLayer.GetIP(Packer);              
                ViewBag.Penna_PackerDetails = _Penna_PackerDetails2;
                string senddata = "#";
                //senddata += "#";
                string mrp="";
                foreach (var element in _Penna_PackerDetails2)
                {
                    //senddata += "," + Convert.ToString(element.packing_Status_details_PKID);
                    senddata += "," + "01";
                    senddata += "," + Convert.ToString(element.Vehicle_Number);
                    senddata += "," + Convert.ToString(element.Grade);
                    senddata += "," + Convert.ToString(element.MRP);
                   
                    senddata += "," + Convert.ToString(element.Set_Count);
                    mrp = Convert.ToString(element.MRP);
                }
                //if (NoofBustedbags != "" && NoofBustedbags != null)
                //{
                //    senddata += NoofBustedbags;
                //}
                //else
                //{
                //    senddata += ",0";
                //}
                senddata+= ",CR";
                var json = JsonConvert.SerializeObject(senddata);
                foreach (var element in _Penna_ManageSettings2)
                {
                    if (element.ips == 1)
                    {
                        string dt = "<STX> " +mrp+"<ETX>";
                        connection_Printers(element.IP_Address, element.Port_No, dt);
                    }
                    else
                    {
                        
                        connection(element.IP_Address, element.Port_No, senddata);
                    }
                }
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                penna_PackerDetails.packing_Status_details_PKID = Convert.ToInt32(Package_Details_PKID);
                penna_PackerDetails.Packer = Convert.ToInt32(Packer);
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                //if (ViewBag.result < 3) { 
                //int result = _Penna_BusinessLayer.Startpacker(penna_PackerDetails);
                //}

                return Json(new { result = ViewBag.result, ViewBag.Penna_PackerDetails, counter= ViewBag.counter }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / StartPacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return Json(new {result= ViewBag.result }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult connection(string ipadds ,string ports,string msg)
        {
            try
            {
                //getdata();
                string Ipadd = "";
                string port = "";
                Ipadd = ipadds;
                    port = ports;
                //int byteCount = Encoding.Unicode.GetByteCount(msg);

                //byte[] sendData = new byte[byteCount];

               // sendData = Encoding.Unicode.GetBytes(msg);

                //byte[] messageBytes = Encoding.UTF8.GetBytes(msg); 
                    string main = string.Empty;
                    //main =Convert.ToString(messageBytes[0]);
                    //const int bytesize = 1024 * 1024;
                    IPAddress address = IPAddress.Parse(Ipadd);
                 
                    client = new System.Net.Sockets.TcpClient(Ipadd,Convert.ToInt32(port));
                Byte[] data ;
              
                data = System.Text.Encoding.ASCII.GetBytes(msg);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();
                byte[] bdp = Encoding.UTF8.GetBytes(msg);
                // Send the message to the connected TcpServer.
                stream.Write(bdp, 0, bdp.Length);
                
                //string responseData;
                //Int32 bytes = stream.Read(data, 0, data.Length);
                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
              

                //string NoComma = "";
                //string example = "text before first comma, more stuff and another comma, there";
                //string result = responseData.IndexOf(',') == 0 ? NoComma : responseData.Split(',')[5];
                //ViewBag.counter = result;
                ////stream = client.GetStream();
                //  stream.Write(data, 0, data.Length);

                //messageBytes = new byte[bytesize];
                //int dt = stream.Read(sendData, 0, sendData.Length);
                // byte[] messageBytes1 = Encoding.ASCII.GetBytes();
                //string bitString = BitConverter.ToString(messageBytes1);


                //   }
                //IPAddress address = IPAddress.Parse(Ipadd);
                //TcpListener tcpListener = new TcpListener(address,Convert.ToInt32(port));
                //tcpListener.Start();
                //byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(json);
                //const int bytesize = 1024 * 1024;
                // messageBytes = new byte[bytesize];
                //while (true)
                //{
                //    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                //    byte[] data = new byte[1024];
                //    NetworkStream ns = tcpClient.GetStream();
                //   // var json = JsonConvert.SerializeObject(senddata);

                //    //var serializer = new XmlSerializer(typeof(string[]));
                //    //serializer.Serialize(tcpClient.GetStream(), json);
                //    stream = tcpClient.GetStream();
                //    stream.Write(messageBytes, 0, messageBytes.Length);
                //    //tcpClient.GetStream().Close();
                //    //tcpClient.Close();
                //    //int recv = ns.Read(data, 0, data.Length);
                //    //Console.WriteLine(id);
                //    //string id = Encoding.ASCII.GetString(data, 0, recv);
                //}
                //----client
                //const int bytesize = 1024 * 1024;
                //byte[] messageBytes= System.Text.Encoding.UTF8.GetBytes(senddata); 
                //client = new System.Net.Sockets.TcpClient(Ipadd,Convert.ToInt32(port));  
                //stream = client.GetStream();
                //stream.Write(messageBytes, 0, messageBytes.Length); 
                //messageBytes = new byte[bytesize];

                //_serialPort = new SerialPort("COM7", 19200, Parity.None, 8, StopBits.One);
                //_serialPort.Handshake = Handshake.None;
                
                //_serialPort.ReadTimeout = 500;
                //_serialPort.WriteTimeout = 500;
                //_serialPort.Open();
                //_serialPort.Write("SI\r\n");
                return Json(new { result = ViewBag.result  }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / StartPacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                ViewBag.result =Convert.ToInt32(ViewBag.result)+1;
                return Json(new { result = "0" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult connection_Printers(string ipadds, string ports, string msg)
        {
            try
            {
                string Ipadd = "";
                string port = "";
                Ipadd = ipadds;
                port = ports;
                string main = string.Empty;
                IPAddress address = IPAddress.Parse(Ipadd);
                client = new System.Net.Sockets.TcpClient(Ipadd, Convert.ToInt32(port));
                NetworkStream stream = client.GetStream();
                byte[] bdp = Encoding.UTF8.GetBytes(msg);
                stream.Write(bdp, 0, bdp.Length);
                return Json(new { result = ViewBag.result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / StartPacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                ViewBag.result = Convert.ToInt32(ViewBag.result) + 1;
                return Json(new { result = "0" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Stoppacker()
        {
            var Package_Details_PKID = Request.Form["ID"];
            var Status = Request.Form["Status"];
            var Packer = Request.Form["Packer"];
            Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
            try
            {
                penna_PackerDetails.packing_Status_details_PKID = Convert.ToInt32(Package_Details_PKID);

                penna_PackerDetails.Status =Status;
                int result = _Penna_BusinessLayer.Stoppacker(penna_PackerDetails);
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                List<Penna_ManageSettings> _Penna_ManageSettings = new List<Penna_ManageSettings>();
                _Penna_ManageSettings = _Penna_BusinessLayer.GetIP(Packer);
                string Ipadd = "";
                string port = "";
                foreach (var element in _Penna_ManageSettings)
                {
                    Ipadd = element.IP_Address;
                    port = element.Port_No;
                }
                IPAddress address = IPAddress.Parse(Ipadd);
                client = new System.Net.Sockets.TcpClient(address.ToString(), Convert.ToInt32(port));
                stream = client.GetStream();
                stream.Close();
                client.Close();
           
                return Json(new { penna_PackerDetails }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                int result = _Penna_BusinessLayer.Stoppacker(penna_PackerDetails);
                LogInfo.LogMsg = string.Format("Packer Dashboard / Stoppacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return Json(new { result = ViewBag.result }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBustedbag(string packer,string NoofBustedbags)
        {
            try
            {
                Penna_PackerDetails penna_PackerDetails1 = new Penna_PackerDetails();
                penna_PackerDetails1.Packer =Convert.ToInt32(packer);
                List<Penna_PackerDetails> _Penna_PackerDetails1 = new List<Penna_PackerDetails>();
                _Penna_PackerDetails1 = _Penna_BusinessLayer.GetPackerDetails(penna_PackerDetails1);
                Penna_PackerDetails penna_PackerDetails = new Penna_PackerDetails();
                List<Penna_PackerDetails> _Penna_PackerDetails = new List<Penna_PackerDetails>();
                if (packer != null && packer != "")
                {
                    penna_PackerDetails.Packer = Convert.ToInt32(packer);
                }
                if (NoofBustedbags != null && NoofBustedbags != "")
                {
                    penna_PackerDetails.Busted_Bag_Count = Convert.ToInt32(NoofBustedbags);
                }
                _Penna_PackerDetails = _Penna_BusinessLayer.GetBustedbag(penna_PackerDetails);
                TempData["bustedbags"] = _Penna_PackerDetails;
                GetDeliveryNo("");
                ViewBag.bustedbag = "yes";
                ViewBag.JavaScriptFunction = string.Format("bustedbag();");
                return View("Index", _Penna_PackerDetails1);

            }
            catch (Exception ex)
            {
                LogInfo.LogMsg = string.Format("Packer Dashboard / GetPacker : {0} Message: {1} ", "", ex.Message);
                Log.Error(LogInfo.LogMsg, ex);
                ViewBag.err = ex;
                return View();
            }    
        }
      
        public ActionResult getdata()
        {
            try
            {
                var Packer = Request.Form["Packer"];
                NetworkStream ns = null;
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                List<Penna_ManageSettings> _Penna_ManageSettings = new List<Penna_ManageSettings>();
                _Penna_ManageSettings = _Penna_BusinessLayer.GetIP(Packer);
                string Ipadd = "";
                string port = "";
                foreach (var element in _Penna_ManageSettings)
                {
                    Ipadd = element.IP_Address;
                    port = element.Port_No;
                }
                var address = IPAddress.Parse("127.0.0.1");
                clientSocket.Connect(address, 1002);            
                var buffer = new byte[2048];
                client = new TcpClient("127.0.0.1", 1002);
                ns = client.GetStream();
                int totalBytesRcvd = 0; // Total bytes received so far  
                int bytesRcvd = 0; // Bytes received in last read  

                // Receive the same string back from the server  
             
                    if ((bytesRcvd = ns.Read(buffer, totalBytesRcvd,
                    buffer.Length - totalBytesRcvd)) == 0)
                    {

                        return Json(new {  data = 1 }, JsonRequestBehavior.AllowGet);
                    }
                    totalBytesRcvd += bytesRcvd;
                

                string text= Encoding.ASCII.GetString(buffer, 0, totalBytesRcvd);
                //var data = new byte[received];
                //Array.Copy(buffer, data, received);
                //string text = Encoding.ASCII.GetString(data);
                string NoComma = "";
                string result = text.IndexOf(',') == 0 ? NoComma : text.Split(',')[5];
                ViewBag.counter = result;

                return Json(new { result,data=0 }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                ViewBag.result = ex;
                return View ("");
            }
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}