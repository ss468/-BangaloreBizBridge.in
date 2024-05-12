using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestHub.Core.Entities;
using InvestHub.Core.Interfaces.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InvestHub.DAL.Repositories
{
    public class PitchRepository : IPitchRepository
    {
        private readonly IMongoCollection<PitchEntity> _collection;

        public PitchRepository(IMongoCollection<PitchEntity> collection)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public void Insert(PitchEntity pitch)
        {
            _collection.InsertOne(pitch);
        }

        public IEnumerable<PitchEntity> GetAllPitch(PitchType? pitchType)
        {
            if(pitchType == null)
                return _collection.Find(_ => true).ToList();

            return _collection.Find(p => p.Type == pitchType).ToList();
        }

        public PitchEntity GetById(Guid id)
        {
            return _collection.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Update(PitchEntity pitch)
        {
            _collection.ReplaceOne(p => p.Id == pitch.Id, pitch);
        }

        public void Delete(Guid id)
        {
            _collection.DeleteOne(p => p.Id == id);
        }
    }
}
