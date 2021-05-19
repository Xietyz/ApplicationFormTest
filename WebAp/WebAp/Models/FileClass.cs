using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace WebAp.Models
{
    public class FileClass
    {
        public long Id { get; set; }
        public IFormFile NewFile { get; set; }
        public FileClass(IFormFile file)
        {
            this.NewFile = file;
        }
        public async Task ContainerUpload()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            //Create a unique name for the container
            string containerName = "filetestcontainer1";

            // Create the container and return a container client object
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (!containerClient.Exists())
            {
                containerClient.Create();
            }

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(NewFile.FileName);

            // Open the file and upload its data
            using (var stream = NewFile.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }
        }
    }
}
