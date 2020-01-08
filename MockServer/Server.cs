using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MockServer.Models;

namespace MockServer
{
    struct ResponseUser<T>
    {
        public List<T> response;
    }
    public class Server
    {
        static void Main(string[] args)
        {
            Listen();
        }
        private static void Listen()
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8080/connection/");
            listener.Prefixes.Add("http://localhost:8080/");
            
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                //Ожидает входящий запрос и возвращается после его получения. 
                HttpListenerContext context =  listener.GetContext();
                //Получает запрос HttpListenerRequest, представляющий запрос клиента на ресурс
                HttpListenerRequest request = context.Request;
                // получаем объект ответа
                HttpListenerResponse response = context.Response;

                ProcessRequest(request.Url.PathAndQuery, response);
            }
        }
        
        private static void SendMessageToClient(object message, HttpListenerResponse response)
        { 
            byte[] buffer = ConvertMessageToBytes(message);

            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        private static byte[] ConvertMessageToBytes(object message)
        {
            string json = JsonConvert.SerializeObject(message);
            return System.Text.Encoding.UTF8.GetBytes(json);
        }
        private static void ProcessRequest(string request, HttpListenerResponse response)
        {
            switch (request) //выбирает ответ
            {
                case "/test":
                    string text = "Hello, world!";
                    SendMessageToClient(text, response);
                    break;
                case "/method/users.get?user_ids=261163818&fields=bdate&access_token=0de83f380e4f2e5bbef1ebb445c30f6dc0f55f0a407e2d8a32b2c76bca34263ac012c11f867144adf0f40&v=5.103":
                    ResponseUser<User> user = new ResponseUser<User>()
                    {
                        response = new List<User>()
                        {
                            new User()
                            {
                                id = "261163818",
                                first_name = "Денис",
                                last_name = "Иванов",
                                is_closed = false,
                                bdate = "28.2.1998"
                            }
                        }
                    };
                    SendMessageToClient(user,response);
                    break;
                default:
                    string faild = "Failed!";
                    SendMessageToClient(faild,response);
                    break;
            }
        }
    }
}