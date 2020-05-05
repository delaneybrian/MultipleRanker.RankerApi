using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultipleRanker.RankerApi.Contracts;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure.Persistance.Mongo
{
    public class MongoParticipantRepository : IParticipantRepository
    {
        private readonly IMongoCollection<ParticipantEntity> _participantCollection;

        public MongoParticipantRepository()
        {
            var client = new MongoClient(
                "mongodb://briandelaney:.$RC2SpD2Zsh!eM@ds016148.mlab.com:16148/multipleranker?retryWrites=false"
            );

            var database = client.GetDatabase("multipleranker");

            _participantCollection = database.GetCollection<ParticipantEntity>("participants");
        }

        public async Task AddParticipant(Participant participant)
        {
            var participantEntity = participant.ToParticipantEntity();

            await _participantCollection.InsertOneAsync(participantEntity);
        }

        public async Task DeleteParticipant(Guid participantId)
        {
            var filterDefinitionBuilder = new FilterDefinitionBuilder<ParticipantEntity>();

            var ratingsEntityCursor = await _participantCollection
                .DeleteOneAsync(filterDefinitionBuilder.Eq(x => Guid.Parse(x.Id), participantId));
        }

        public async Task<Participant> GetParticipant(Guid participantId)
        {
            var participantEntity = await _participantCollection
                .Find(x => x.Id == participantId.ToString())
                .Limit(1)
                .SingleAsync();

            return participantEntity.ToParticipant();
        }
    }
}
