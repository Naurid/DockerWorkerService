using MessageGet.API.Context;
using MessageGet.API.Dto;
using MessageGet.API.Entities;
using System.Text.Json;

namespace MessageGet.API
{
    public class CheckService(GetContext context, ILogger<CheckService> logger) : BackgroundService
    {
        private readonly string _userDirectory = "../shared/Users";
        private readonly string _messagesDirectory = "../shared/Messages";
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation($"passed {stoppingToken.IsCancellationRequested}");
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("passed here");

                if (Directory.Exists(_messagesDirectory))
                {
                    var files = Directory.GetFiles(_messagesDirectory);
                    foreach (var file in files)
                    {
                        try
                        {
                            string jsonString = File.ReadAllText(file);

                            MessageDto? message = JsonSerializer.Deserialize<MessageDto>(jsonString, _serializerOptions);
                            if (message == null) throw new InvalidOperationException("brrr brrr");
                            logger.LogInformation($"{nameof(CheckService)}: {message}");
                            MessageEntity newMessage = new MessageEntity() { User = message.User, Content=message.Content };
                            logger.LogInformation($"{nameof(CheckService)}: {newMessage}");
                            context.Messages.Add(newMessage);
                            context.SaveChanges();
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                await Task.Delay(5000);

            }
        }
    }
}
