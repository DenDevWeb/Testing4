using System;
using System.IO;
using System.Net;

namespace Testing4_ApiVk.WebClient
{
    public class WebClient
    {
        public string SendRequest(string requestString, string method)
        {
            // requestString = baseURL + requestString;
            
            WebRequest request = WebRequest.Create(requestString);
            request.Method = method;
            request.Credentials = CredentialCache.DefaultCredentials;
            
            WebResponse response = request.GetResponse(); 
            
            Stream stream = response.GetResponseStream(); 
            
            StreamReader reader = new StreamReader(stream);
            
            
            string receiveMessage = reader.ReadToEnd();
            
            stream.Close();
            response.Close();

            return receiveMessage;
        }
    }
}