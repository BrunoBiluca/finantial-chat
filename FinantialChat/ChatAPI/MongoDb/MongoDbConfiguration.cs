namespace ChatAPI {
    public class MongoDbConfiguration {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
