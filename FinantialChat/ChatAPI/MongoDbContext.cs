using MongoDB.Driver;
using System;

namespace ChatAPI {
    public class MongoDbContext {
        public const string ChatMessagesCollection = "chat_messages";

        public static MongoDbConfiguration Configuration;

        private IMongoDatabase Database { get; }

        public MongoDbContext() {
            try {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(Configuration.ConnectionString));

                MongoInternalIdentity internalIdentity = new MongoInternalIdentity("admin", Configuration.Username);
                PasswordEvidence passwordEvidence = new PasswordEvidence(Configuration.Password);
                MongoCredential mongoCredential = new MongoCredential("SCRAM-SHA-1", internalIdentity, passwordEvidence);
                settings.Credential = mongoCredential;
                if(Configuration.IsSSL) {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(Configuration.DatabaseName);
            } catch(Exception ex) {
                throw new Exception("Could not connect to the server.", ex);
            }
        }

        public IMongoCollection<ChatMessage> ChatMessages {
            get {
                return Database.GetCollection<ChatMessage>(ChatMessagesCollection);
            }
        }
    }
}
