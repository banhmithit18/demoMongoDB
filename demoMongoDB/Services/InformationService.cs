using demoMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoMongoDB.Services
{
    public class InformationService
    {
        private readonly MongoDB.Driver.IMongoCollection<Information> Informations;
        private readonly BoMayDatabaseSettings _settings;

        public InformationService(IOptions<BoMayDatabaseSettings> setting)
        {
            _settings = setting.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            Informations = database.GetCollection<Information>(_settings.BoMaysCollectionName);
        }
        public async Task<List<Information>> GetAll()
        {
            return await Informations.Find(info => info.active == true).ToListAsync();
            
        }
        public async Task<Information> Get(string id) => await Informations.Find(info => info.id == id).FirstOrDefaultAsync();
        public async Task Create(Information info) {
         await Informations.InsertOneAsync(info);
        }
        public async Task Update(string id, Information info) => await Informations.ReplaceOneAsync(info => info.id == id || info.active == true,info);
        public async Task Active(string id,Information info)
        {
            await Informations.ReplaceOneAsync(info => info.id == id || info.active == false,info );
        }
        public async Task Disable(string id, Information info)
        {
            await Informations.ReplaceOneAsync(info => info.id == id || info.active == true, info);
        }

        public async Task Delete(string id) => await Informations.DeleteOneAsync(info => info.id == id||info.active == false);

    }
}
