namespace mis_221_pa_5_szheng011
{
    public class Booking
    {
        private int sessionID;
        private string customerFirstName;
        private string customerLastName;

        private string customerEmail;

        private DateTime trainingDate;
        private int trainerID;
        private string trainerFirstName;
        private string trainerLastName;
        private double costOfSession;
        private string sessionStatus = "Booked";
        static private int sessionCount = 0;
        static private int sessionIDCount = 0;

        public Booking()
        {

        }

        public Booking(int sessionID,string customerFirstName, string customerLastName, string customerEmail, DateTime trainingDate, int trainerID, string trainerFirstName, string trainerLastName, double costOfSession){
            this.sessionID = sessionID;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerFirstName = trainerFirstName;
            this.trainerLastName = trainerLastName;
            this.costOfSession = costOfSession;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }

        public int GetSessionID(){
            return sessionID;
        }

        public void SetCustomerFirstName(string customerFirstName){
            this.customerFirstName = customerFirstName;
        }

        public string GetCustomerFirstName(){
            return customerFirstName;
        }

        public void SetCustomerLastName(string customerLastName){
            this.customerLastName = customerLastName;
        }

        public string GetCustomerLastName(){
            return customerLastName;
        }

        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail(){
            return customerEmail;
        }

        public void SetTrainingDate(DateTime trainingDate){
            this.trainingDate = trainingDate;
        }

        public DateTime GetTrainingDate(){
            return trainingDate;
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

        public void SetCostOfSession(double costOfSession){
            this.costOfSession = costOfSession;
        }
        public double GetCostOfSession(){
            return costOfSession;
        }

        public void SetSessionStatus(string sessionStatus){
            this.sessionStatus = sessionStatus;
        }

        public string GetSessionStatus(){
            return sessionStatus;
        }

        static public void IncSessionCount(){
            Booking.sessionCount++;
        }

        static public void DecSessionCount(){
            Booking.sessionCount--;
        }

        static public int GetSessionCount(){
            return Booking.sessionCount;
        }

        static public void IncSessionIDCount(){
            Booking.sessionIDCount++;
        }

        static public void SetSessionIDCount(int sessionIDCount){
            Booking.sessionIDCount = sessionIDCount;
        }

        static public int GetSessionIDCount(){
            return Booking.sessionIDCount;
        }

        public override string ToString()
        {
            return $"Session ID:{sessionID}, Training Date:{trainingDate}\nCustomer Name:{customerFirstName} {customerLastName}, Customer Email:{customerEmail}\nTrainer Name:{trainerFirstName} {trainerLastName}, Session Status:{sessionStatus}";
        }

        public string ToFile()
        {
            return $"{sessionID}#{customerFirstName}#{customerLastName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerFirstName}#{trainerLastName}#{costOfSession}#{sessionStatus}";
        }
    }
}