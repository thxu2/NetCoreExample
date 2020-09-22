using System;

namespace SampleApi.Domain
{
    public class DataBaseItem
    {
        public DataBaseItem()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}