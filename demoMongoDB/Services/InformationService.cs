using demoMongoDB.Models;
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
        public InformationService(IBoMayDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            Informations = database.GetCollection<Information>(setting.BoMaysCollectionName);
        }
        public List<Information> GetAll() => Informations.Find(info => info.active == true).ToList();
        public Information Get(string id) => Informations.Find(info => info.id == id).FirstOrDefault();
        public void Create(Information info) {
        Informations.InsertOne(info);
        }
        public void Update(string id, Information info) => Informations.ReplaceOne(info => info.id == id || info.active == true,info);
        public void Active(string id,Information info)
        {
            Informations.ReplaceOne(info => info.id == id || info.active == false,info );
        }
        public void Disable(string id, Information info)
        {
            Informations.ReplaceOne(info => info.id == id || info.active == true, info);
        }

        public void Delete(string id) => Informations.DeleteOne(info => info.id == id||info.active == false);

    }
}
