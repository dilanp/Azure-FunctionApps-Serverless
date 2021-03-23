using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace ServerlessFunctions
{
    public static class QueueListeners
    {
        [FunctionName("QueueListeners")]
        public static async Task Run(
            [QueueTrigger("todos", Connection = "AzureWebJobsStorage")]ToDo toDo, 
            [Blob("todos", Connection = "AzureWebJobsStorage")] CloudBlobContainer container,
            ILogger log)
        {
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference($"{toDo.Id}.txt");
            await blob.UploadTextAsync($"Created a new task: {toDo.TaskDescription}");
            log.LogInformation($"C# Queue trigger function processed: {toDo.TaskDescription}");
        }
    }
}
