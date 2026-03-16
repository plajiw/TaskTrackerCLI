using System.Text.Json;
using TaskTrackerCLI.Domain.Models.TaskItem;

namespace TaskTrackerCLI.Infrastructure.Persistence
{
    public class JsonContext
    {
        private readonly string _filePath;  
        public JsonContext()
        {
            var tempFilePath = Path.GetTempPath();
            _filePath = Path.Combine(tempFilePath, Constants.JSON_FILE_NAME);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");
        }

        public List<TaskItem> LoadData()
        {
            var data = File.ReadAllText(_filePath);

            try
            {
                return JsonSerializer.Deserialize<List<TaskItem>>(data);
            }
            catch
            {
                return new List<TaskItem>();
            }
        }

        public void SaveData(List<TaskItem> taskItems)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(taskItems, options);
            File.WriteAllText(_filePath, json);
        }
    }
}
