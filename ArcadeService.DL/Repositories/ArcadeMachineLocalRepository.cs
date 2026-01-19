using ArcadeService.DL.Interfaces;
using ArcadeService.Models.Configurations;
using ArcadeService.Models.Dto;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ArcadeService.DL.Repositories
{
    internal class ArcadeMachineLocalRepository : IArcadeMachineRepository
    {
        private readonly IOptionsMonitor<MongoDbConfiguration> _mongoDbConfiguration;
        private readonly ILogger<ArcadeMachineLocalRepository> _logger;
        private readonly IMongoCollection<ArcadeMachine> _arcadeMachinesCollection;

        public ArcadeMachineLocalRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoDbConfiguration,
            ILogger<ArcadeMachineLocalRepository> logger)
        {
            _mongoDbConfiguration = mongoDbConfiguration;
            _logger = logger;

            var client = new MongoClient(_mongoDbConfiguration.CurrentValue.ConnectionString);
            var database = client.GetDatabase(_mongoDbConfiguration.CurrentValue.DatabaseName);

            _arcadeMachinesCollection =
                database.GetCollection<ArcadeMachine>($"{nameof(ArcadeMachine)}s");
        }

        public void Add(ArcadeMachine arcadeMachine)
        {
            if (arcadeMachine == null) return;

            try
            {
                _arcadeMachinesCollection.InsertOne(arcadeMachine);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error adding arcade machine to the DB: {Message} - {StackTrace}",
                    e.Message, e.StackTrace);
            }
        }

        public void Delete(Guid id)
        {
            if (id == Guid.Empty) return;

            try
            {
                var result = _arcadeMachinesCollection.DeleteOne(m => m.Id == id);

                if (result.DeletedCount == 0)
                {
                    _logger.LogWarning(
                        "No arcade machine found with Id: {Id} to delete.", id);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error in method {Method}: {Message} - {StackTrace}",
                    nameof(Delete), e.Message, e.StackTrace);
            }
        }

        public List<ArcadeMachine> GetAll()
        {
            return _arcadeMachinesCollection.Find(_ => true).ToList();
        }

        public ArcadeMachine? GetById(Guid id)
        {
            if (id == Guid.Empty) return null;

            try
            {
                return _arcadeMachinesCollection
                    .Find(m => m.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError(
                    "Error in method {Method}: {Message} - {StackTrace}",
                    nameof(GetById), e.Message, e.StackTrace);
            }

            return null;
        }
    }
}
