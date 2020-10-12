using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json.Linq;

namespace L03
{
    class Program {
        private static UserCredential userCredential;
        private static string[] scope = { DriveService.Scope.Drive };
        private static DriveService service;
        private static HttpWebRequest httpWebRequest;
        static void Main(string[] args) {
            init();
            readFiles();
        }

        private static void init() {
            using (var fileStream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(fileStream).Secrets,
                    scope,
                    Environment.UserName,
                    CancellationToken.None,
                    new FileDataStore(".", true)).Result;
            }
            service = new DriveService(new BaseClientService.Initializer() {
                HttpClientInitializer = userCredential,
                ApplicationName = "DATC",
            });
        }

        private static void readFiles() {
            httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/drive/v3/files?q='root'%20in%20parents");
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + userCredential.Token.AccessToken);
            using(var response = httpWebRequest.GetResponse()) {
                using(Stream responseStream = response.GetResponseStream())
                using(var streamReader = new StreamReader(responseStream)) {
                    String stringJson = streamReader.ReadToEnd();
                    var json = JObject.Parse(stringJson);
                    Console.WriteLine("Files in Drive:\n");
                    foreach(var file in json["files"]) {
                        Console.WriteLine(file["name"]);
                    }
                }
            }
        }
    }
}
