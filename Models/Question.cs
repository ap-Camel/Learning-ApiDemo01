using System.ComponentModel.DataAnnotations;

namespace APIDEMO01.Models {

    public record Question{

        public Question(InsertQuestion i){
            this.description = i.description;
            this.hasUrl = i.hasUrl;
            this.pictureUrl = i.pictureUrl;
            this.questionType = i.questionType;
            this.difficultyLvl = i.difficultyLvl;
        }

        public Question(){}

        public int ID {get; init;}
        [Required]
        public string description {get; init;}
        [Required]
        public bool hasUrl { get; init; }
        public string pictureUrl { get; init; }
        [Required]
        public string questionType { get; init; }
        public string dateCreated { get; init; }
        public int difficultyLvl { get; init; }

    }
}


/*

--  ID int IDENTITY(1,1) PRIMARY KEY,
--	description text not null,
--	hasUrl BIT null,
--	pictureUrl text null,
--	questionType varchar(124),
--	dateCreated DateTime,
--	difficultyLvl int


*/