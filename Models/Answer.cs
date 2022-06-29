namespace APIDEMO01.Models{
    public record Answer {
        public int ID { get; init; }
        public bool answerType { get; init; }
        public string description { get; init; }
        public string dateCreated { get; init; }
        public int answerPriority { get; init; }
        public int questionID { get; init; }
    }
}


/*

--	ID int IDENTITY(1,1) PRIMARY KEY,
--	answerType BIT not null,
--	description text not null,
--	dateCreated DateTime,
--	answerPriority int null,
--	questionID int FOREIGN KEY REFERENCES question(ID)

*/