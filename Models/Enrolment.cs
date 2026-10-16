namespace RaceDAY_API.Models
{//start of namspace 
    public class Enrolment
    {//start of class
        public int enrolmentID { get; set; }
        public DateTime enrolmentDate { get; set; }
        public int userID { get; set; }
        public int eventID { get; set; }
        public int categoryID { get; set; }
    }// end of class
}//end of namespace
