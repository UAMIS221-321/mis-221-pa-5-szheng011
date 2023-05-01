namespace mis_221_pa_5_szheng011
{
    public class Trainer
    {
        //instance variables
        private int trainerID;
        private string trainerFirstName;
        private string trainerLastName;

        private string trainerMailingAddress;
        private string trainerEmailAddress;

        /////////////////
        static private int trainerCount = 0;
        static private int trainerIDCount = 0;
        /////////////////

        //no arg constructor
        public Trainer(){

        }

        //arg constructor
        public Trainer(int trainerID, string trainerFirstName,string trainerLastName, string trainerMailingAddress, string trainerEmailAddress){
            this.trainerID = trainerID;
            this.trainerFirstName = trainerFirstName;
            this.trainerLastName = trainerLastName;
            this.trainerMailingAddress = trainerMailingAddress;
            this.trainerEmailAddress = trainerEmailAddress;
        }

        //Getters and setters
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

        public void SetTrainerMailingAddress(string trainerMailingAddress){
            this.trainerMailingAddress = trainerMailingAddress;
        }

        public string GetTrainerMailingAddress(){
            return trainerMailingAddress;
        }

        public void SetTrainerEmailAddress(string trainerEmailAddress){
            this.trainerEmailAddress = trainerEmailAddress;
        }

        public string GetTrainerEmailAddress(){
            return trainerEmailAddress;
        }

        static public void IncTrainerCount(){
            Trainer.trainerCount++;
        }

        static public void DecTrainerCount(){
            Trainer.trainerCount--;
        }

        static public int GetTrainerCount(){
            return Trainer.trainerCount;
        }

        static public void IncTrainerIDCount(){
            Trainer.trainerIDCount++;
        }

        static public void SetTrainerIDCount(int trainerIDCount){
            Trainer.trainerIDCount = trainerIDCount;
        }

        static public int GetTrainerIDCount(){
            return Trainer.trainerIDCount;
        }
        //////////////////

        public override string ToString()
        {
            return $"Trainer ID:{trainerID}, Trainer Name:{trainerFirstName} {trainerLastName}, Trainer Address:{trainerMailingAddress}, Trainer Email:{trainerEmailAddress}";
        }
        public string ToFile()
        {
            return $"{trainerID}#{trainerFirstName}#{trainerLastName}#{trainerMailingAddress}#{trainerEmailAddress}";
        }
    }
}