using System;
namespace Timeline.Models
{
    public class TimelineDatabaseSettings : ITimelineDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string HitsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITimelineDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string HitsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
