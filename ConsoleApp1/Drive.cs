using System;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;

namespace SpeechToText
{
    class Drive
    {
        public static File createDirectory(DriveService _service, string _title, string _description, string _parent)
        {
            File NewDirectory = null;

            File body = new File();
            body.Title = _title;
            body.Description = _description;
            body.MimeType = "application/vnd.google-apps.folder";
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
            try
            {
                FilesResource.InsertRequest request = _service.Files.Insert(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }

            return NewDirectory;
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Text;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
////using File = Google.Apis.Drive.v3.Data.File;

//namespace SpeechToText
//{
//    public class Drive
//    {
//        //static string[] Scopes = { DriveService.Scope.DriveReadonly };
//        //static string ApplicationName = "Drive API .NET Quickstart";
//        //UserCredential credential;

//        //public void SaveFile()
//        //{
//        //    //Configuration
//        //    using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
//        //    {
//        //        string credPath = "token.json";
//        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
//        //            Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
//        //        Console.WriteLine("Credential file saved to: " + credPath);
//        //    }

//        //    var service = new DriveService(new BaseClientService.Initializer()
//        //    {
//        //        HttpClientInitializer = credential,
//        //        ApplicationName = ApplicationName,
//        //    });

//        //    FilesResource.ListRequest listRequest = service.Files.List();
//        //    listRequest.PageSize = 10;
//        //    listRequest.Fields = "nextPageToken, files(id, name)";
//        //    IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

//        //    Console.WriteLine("Files:");
//        //    if (files != null && files.Count > 0)
//        //    {
//        //        foreach (var file in files)
//        //            Console.WriteLine("{0} ({1})", file.Name, file.Id);
//        //    }
//        //    else
//        //        Console.WriteLine("No files found.");
//        //    Console.Read();
//        //}
//        public void saveFile(Models.File fileToSave)
//        {
//            var fileMetadata = new File()
//            {
//                Name = "My Report",
//                MimeType = "application/vnd.google-apps.spreadsheet"
//            };
//            FilesResource.CreateMediaUpload request;
//            using (var stream = new System.IO.FileStream("files/FilesText.txt", System.IO.FileMode.Open))
//            {
//                request = driveService.Files.Create(fileMetadata, stream, "text/txt");
//                request.Fields = fileToSave.Content;
//                request.Upload();
//            }
//        }
//        public static Google.Apis.Drive.v3.Data.File UploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
//        {
//            if (System.IO.File.Exists(_uploadFile))
//            {
//                File body = new File();
//                body.Title = System.IO.Path.GetFileName(_uploadFile);
//                body.Description = _descrp;
//                body.MimeType = GetMimeType(_uploadFile);
//                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };

//                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
//                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
//                try
//                {
//                    FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
//                    request.Upload();
//                    return request.ResponseBody;
//                }
//                catch (Exception e)
//                {
//                    MessageBox.Show(e.Message, "Error Occured");
//                }
//            }
//            else
//            {
//                MessageBox.Show("The file does not exist.", "404");
//            }
//        }

//        var file = request.ResponseBody;
//Console.WriteLine("File ID: " + file.Id);
//    }
//}

