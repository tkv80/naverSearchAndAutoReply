using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace NaverSearch
{
    class GcmManager
    {
        string deviceId = "APA91bEjnv2-SfcFU441y__4LZycOmHNUFN9hBjsi24B3QRyTXT6sQ4TcL8ehpvX9Sn74B9UkOiIFI-Amj-mMOJDhjOL5mvhzohW-n41bbR8BDVO9ChuQjG7VXJ2tv-O5fWeAq8I21_AgF5_2DHMAKV1CuIYfrMtcA";
        string apiKey = "AIzaSyCcFDylElWuJkVPvG688WXPxYttV8GHoGM";

        string tickerText = "cmaping GCM";

        public string SendNotification(string message, string contentTitle)
        {
            string postData =
        "{ \"registration_ids\": [ \"" + deviceId + "\" ], " +
          "\"data\": {\"GameName\":\"" + tickerText + "\", " +
                     "\"FTitle\":\"" + contentTitle + "\", " +
                     "\"FContent\":\"" + contentTitle + "\", " +
                     "\"PromotionCopy\": \"" + message + "\"}}";
            string response = SendGCMNotification(apiKey, postData);
            return response;
        }



        /// <summary>
        /// Send a Google Cloud Message. Uses the GCM service and your provided api key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="postData"></param>
        /// <param name="postDataContentType"></param>
        /// <returns>The response string from the google servers</returns>
        private string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }


        public static bool ValidateServerCertificate(
                                                    object sender,
                                                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                                                    SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
