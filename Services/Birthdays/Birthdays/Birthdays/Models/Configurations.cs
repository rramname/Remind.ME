namespace BirthdayService.Models{
    public class Configurations
    {
        public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
        public string SeqURL { get; set; }
        public string SeqAPIKey { get; set; }
    }
    
}