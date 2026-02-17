using System.Text.Json;
using TaskTrackerCLI.Domain.Models.TaskItem;

namespace TaskTrackerCLI.Infrastructure.Persistence
{
    public class JsonContext
    {
        private readonly string _filePath;  
        public JsonContext()
        {
            var tempFilePath = Path.GetTempFileName();
            var filePath = Path.Combine(tempFilePath, Constants.JSON_FILE_NAME);
            
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("[]");
                }
            }

           _filePath = filePath;
        }

        public void LoadData()
        {
            var dataDeserializer = new List<TaskItem>();
            var data = File.ReadAllText(_filePath);

            try
            {
                dataDeserializer = JsonSerializer.Deserialize<TaskItem>(data);
            }
            catch
            {

            }

        }

        public void SaveData(List<TaskItem> taskItems)
        {
        }
    }
}
