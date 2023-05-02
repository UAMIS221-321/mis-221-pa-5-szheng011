namespace mis_221_pa_5_szheng011
{
    public class ReportUtility
    {
        Booking[] bookings;
        Trainer[] trainers;
        Listing[] listings;

        //constructor
        public ReportUtility(Booking[] bookings, Trainer[] trainers, Listing[] listings){
            this.bookings = bookings;
            this.trainers = trainers;
            this.listings = listings;
        }

        //Prints the report for the individual customer's sessions
        public void IndivCustSessReport(){
            System.Console.WriteLine("Please enter the email of the customer:");
            string tempCustomerEmail = Console.ReadLine();
            int count = 0;
            string reportContent = "";

            System.Console.WriteLine("Individual Customer Report:");
            if(SearchByCustEmail(tempCustomerEmail) != -1){
                for(int i = 0; i < Booking.GetSessionIDCount(); i++){
                    if(bookings[i].GetCustomerEmail().CompareTo(tempCustomerEmail) == 0){
                        reportContent+=bookings[i].ToString();
                        reportContent+="\n";
                        count++;
                    }
                }
            }
            reportContent+="This customer has a total of " + count + " previous training session transactions\n";
            System.Console.WriteLine(reportContent);
            SaveReportToFile(reportContent);
        }

        public void SortByCustDate(){
            for(int i = 0; i < Booking.GetSessionIDCount(); i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetSessionIDCount(); j++){
                    // int dateCompare = DateTime.Compare(bookings[j].GetTrainingDate(),bookings[min].GetTrainingDate());
                    // System.Console.WriteLine("_________" + dateCompare);
                    if((bookings[j].GetCustomerFirstName().CompareTo(bookings[min].GetCustomerFirstName()) < 0) ||
                    (bookings[j].GetCustomerFirstName() == bookings[min].GetCustomerFirstName() && bookings[j].GetTrainingDate()<bookings[min].GetTrainingDate())){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min,i);
                }
            }
        }

        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }

        //Prints the array sorted by customer then by date
        //Displays the total session for each individual customer from the sorted array
        public void HistCustSessReport(){
            string reportContent = "";
            for(int i = 0; i<Booking.GetSessionIDCount(); i++){
                reportContent+=bookings[i].ToString();
                reportContent+="\n";
            }

            string currName = bookings[0].GetCustomerFirstName() + " " + bookings[0].GetCustomerLastName();
            int totalSessCount = 1;
            for(int i = 1; i < Booking.GetSessionIDCount(); i++){
                if(bookings[i].GetCustomerFirstName()+ " " + bookings[i].GetCustomerLastName() == currName){
                    totalSessCount++;
                }
                else{
                    ProcessBreak(i,ref currName, ref totalSessCount, bookings, ref reportContent);
                }
            }
            ProcessBreak(ref currName, ref totalSessCount, ref reportContent);
            System.Console.WriteLine(reportContent);
            SaveReportToFile(reportContent);
        }

        public void ProcessBreak(int i, ref string currName, ref int totalSessCount, Booking[] bookings, ref string reportContent){
            string line2 = ("The total number of sessions for " + currName + " is: " + totalSessCount+"\n------------------------------------------------------\n");
            reportContent+=line2;

            currName = bookings[i].GetCustomerFirstName() + " " + bookings[i].GetCustomerLastName();
            totalSessCount = 1;
        }

        public void ProcessBreak(ref string currName, ref int totalSessCount,ref string reportContent){
            string line3 = ("The total number of sessions for " + currName + " is: " + totalSessCount+"\n------------------------------------------------------\n");
            reportContent+=line3;

        }

        //Sequential search to find the customer in transactions.txt to generate the report by returning the index
        public int SearchByCustEmail(string email){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if(bookings[i].GetCustomerEmail().CompareTo(email) == 0){
                    return i;
                }
            }
            return -1;
        }

        //Saves the report to the specified file
        public void SaveReportToFile(string reportContent){
            System.Console.WriteLine("Would you like to save this report to a file?\nEnter 1 for Yes\nEnter 2 for No");
            
            int input = -1;
            if(int.TryParse(Console.ReadLine(), out input) && (input == 1 || input == 2)){
                if(input == 1){
                    System.Console.WriteLine("Please enter the name of the output file where the report will be saved to:\nPlease include the .txt extention");
                    StreamWriter outFile = new StreamWriter(Console.ReadLine());

                    outFile.WriteLine(reportContent);

                    outFile.Close();
                }
                if(input == 2){
                    return;
                }
            }
            else{
                System.Console.WriteLine("Invalid input");
                return;
            }
        }

        public void SortByMonthYear(){
            for(int i = 0; i < Booking.GetSessionIDCount(); i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetSessionIDCount(); j++){
                    if(bookings[j].GetTrainingDate()<bookings[min].GetTrainingDate()){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min,i);
                }
            }
            //This for loop shows the sorted bookings by month and year
            // System.Console.WriteLine("------");
            // for(int i = 0; i<Booking.GetSessionIDCount(); i++){
            //     System.Console.WriteLine(bookings[i].ToString());
            // }
        }


        public void HistRevSessReport(){
            //Historical Revenue Report by Month
            string reportContent = "";
            string curr = bookings[0].GetTrainingDate().ToString("MMMM");
            int year = bookings[0].GetTrainingDate().Year;
            double revenue = bookings[0].GetCostOfSession();

            for(int i = 1; i < Booking.GetSessionIDCount(); i++){
                if(bookings[i].GetTrainingDate().ToString("MMMM") == curr && (bookings[i].GetTrainingDate().Year == year)){
                    revenue+=bookings[i].GetCostOfSession();
                }
                else{
                    ProcessBreak1(i,ref curr, ref year, ref revenue, bookings, ref reportContent);
                }
            }
            ProcessBreak1(ref curr,ref year,ref revenue, ref reportContent);

            //Historical Revenue Report by Year
            year = bookings[0].GetTrainingDate().Year;
            revenue = bookings[0].GetCostOfSession();


            for(int i = 1; i < Booking.GetSessionIDCount(); i++){
                if(bookings[i].GetTrainingDate().Year == year){
                    revenue+=bookings[i].GetCostOfSession();
                }
                else{
                    ProcessBreak2(i,ref year, ref revenue, bookings, ref reportContent);
                }
            }
            ProcessBreak2(ref year,ref revenue, ref reportContent);


            System.Console.WriteLine(reportContent);
            SaveReportToFile(reportContent);
        }

        public void ProcessBreak1(int i , ref string curr,ref int year,ref double revenue,Booking[] bookings, ref string reportContent){
            string line = curr+ " "+ year +": $" + revenue+ "\n";
            reportContent+=line;

            curr = bookings[i].GetTrainingDate().ToString("MMMM");
            revenue = bookings[i].GetCostOfSession();
            year = bookings[i].GetTrainingDate().Year;
        }

        public void ProcessBreak1(ref string curr, ref int year, ref double revenue, ref string reportContent){
            string line = curr + " "+ year +": $" + revenue + "\n";
            reportContent+=line;
        }

        public void ProcessBreak2(int i ,ref int year,ref double revenue,Booking[] bookings, ref string reportContent){
            string line = year +": $" + revenue+ "\n";
            reportContent+=line;

            revenue = bookings[i].GetCostOfSession();
            year = bookings[i].GetTrainingDate().Year;
        }

        public void ProcessBreak2(ref int year, ref double revenue, ref string reportContent){
            string line = year +": $" + revenue + "\n";
            reportContent+=line;
        }

        //Report includes a list of training sessions the customer has booked before, total number of training sessions booked,
        //total amount spent, and average amount spent by the individual customer
        public void DetailedCustomerReport(){
            System.Console.WriteLine("Please enter your(customer) email:");
            string tempCustomerEmail = Console.ReadLine();
            int count = 0;
            double totalSpent = 0;
            string reportContent = "Detailed Customer Report:\n";

            if(SearchByCustEmail(tempCustomerEmail) != -1){
                for(int i = 0; i < Booking.GetSessionIDCount(); i++){
                    if(bookings[i].GetCustomerEmail().CompareTo(tempCustomerEmail) == 0){
                        totalSpent+=bookings[i].GetCostOfSession();
                        reportContent+=bookings[i].ToString();
                        reportContent+="\n";
                        count++;
                    }
                }

                reportContent+="You have accumulated a total of " + count + " previous training session transactions\n";
                reportContent+="You have spent a total of $"+totalSpent+" at our gym\n";
                reportContent+="You spend an average of $" +(totalSpent/count)+" for each training session\n";

                System.Console.WriteLine(reportContent);
                SaveReportToFile(reportContent);
            }
            else{
                System.Console.WriteLine("Invalid input");
            }
        }


        //Report includes a list of training sessions the trainer has listed before, total number of training sessions listed,
        //total amount earned, and average amount earned per session by the individual trainer
        public void TrainerReport(){
            System.Console.WriteLine("Please enter the trainer ID");
            int tempTrainerID;
            int count = 0;
            double totalEarned = 0;
            string reportContent = "";


            if(int.TryParse(Console.ReadLine(), out tempTrainerID) &&(SearchTrainerByID(tempTrainerID) != -1)){
                for(int i = 0; i < Listing.GetListingIDCount(); i++){
                    if(listings[i].GetTrainerID() == tempTrainerID){
                        totalEarned+=listings[i].GetCostOfSession();
                        reportContent+=listings[i].ToString();
                        reportContent+="\n";
                        count++;
                    }
                }
                reportContent+="You have accumulated a total of " + count + " training session listings\n";
                reportContent+="You have earned a total of $"+totalEarned+" at our gym\n";
                reportContent+="You earned an average of $" +(totalEarned/count)+" for each training session\n";

                System.Console.WriteLine(reportContent);
                SaveReportToFile(reportContent);
            }
            else{
                System.Console.WriteLine("Invalid Input");
            }
        }

        //Sequential search to find the ID of trainer in trainers.txt to edit by returning the index
        public int SearchTrainerByID(int searchVal){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if(trainers[i].GetTrainerID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

    }
}