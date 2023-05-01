namespace mis_221_pa_5_szheng011
{
    public class Listing
    {
        //instance variables
        private int listingID;
        private string listingName;
        private DateTime listingDateTime;
        private double costOfSession;
        private string isListingTaken = "Not Taken";
        private int trainerID;

        private string trainerFirstName;
        private string trainerLastName;        
        static private int listingCount = 0;
        static private int listingIDCount = 0;

        //no arg(default) constructor
        public Listing(){

        }

        //arg(overloaded) constructor
        public Listing(int listingID, string listingName, DateTime listingDateTime, double costOfSession, int trainerID, string trainerFirstName, string trainerLastName){
            this.listingID = listingID;
            this.listingName = listingName;
            this.listingDateTime = listingDateTime;
            this.costOfSession =costOfSession;
            this.trainerID = trainerID;
            this.trainerFirstName = trainerFirstName;
            this.trainerLastName = trainerLastName;
        }

        public void SetListingID(int listingID){
            this.listingID = listingID;
        }

        public int GetListingID(){
            return listingID;
        }

        public void SetListingName(string listingName){
            this.listingName = listingName;
        }

        public string GetListingName(){
            return listingName;
        }

        public void SetDateTime(DateTime listingDateTime){
            this.listingDateTime = listingDateTime;
        }

        public DateTime GetDateTime(){
            return listingDateTime;
        }

        public void SetCostOfSession(double costOfSession){
            this.costOfSession = costOfSession;
        }

        public double GetCostOfSession(){
            return costOfSession;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerFirstName(string trainerFirstName){
            this.trainerFirstName = trainerFirstName;
        }

        public string GetTrainerFirstName(){
            return trainerFirstName;
        }

        public void SetTrainerLastName(string trainerLastName){
            this.trainerLastName = trainerLastName;
        }

        public string GetTrainerLastName(){
            return trainerLastName;
        }

        public void SetIsListingTaken(string isListingTaken){
            this.isListingTaken = isListingTaken;
        }

        public void SetListingToTaken(){
            this.isListingTaken = "Taken";
        }

        public string GetIsListingTaken(){
            return isListingTaken;
        }

        static public void IncListingCount(){
            Listing.listingCount++;
        }

        static public void DecListingCount(){
            Listing.listingCount--;
        }

        static public int GetListingCount(){
            return Listing.listingCount;
        }

        static public void IncListingIDCount(){
            Listing.listingIDCount++;
        }

        static public void SetListingIDCount(int listingIDCount){
            Listing.listingIDCount = listingIDCount;
        }

        static public int GetListingIDCount(){
            return Listing.listingIDCount;
        }

        public override string ToString()
        {
            return $"Listing ID:{listingID}, Listing Name:{listingName}\nDate and Time of Session:{listingDateTime}, Cost of Session:${costOfSession}, Is Listing Taken?:{isListingTaken}";
        }
        public string ToFile()
        {
            return $"{listingID}#{listingName}#{listingDateTime}#{costOfSession}#{trainerID}#{trainerFirstName}#{trainerLastName}";
        }
    }
}

// 0#Yoga#6/1/2023 10:00:00 AM#60#0#Sandy#Zheng
// 1#Cardio#6/3/2023 9:00:00 AM#50#3#Jane#Doe
// 2#Weight-lifting#6/5/2023 1:00:00 PM#70#2#John#Doe