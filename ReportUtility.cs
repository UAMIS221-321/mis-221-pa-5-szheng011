namespace mis_221_pa_5_szheng011
{
    public class ReportUtility
    {
        Booking[] bookings;
        Trainer[] trainers;
        Listing[] listings;
        //Report[] reports;

        //constructor
        public ReportUtility(Booking[] bookings, Trainer[] trainers, Listing[] listings){
            this.bookings = bookings;
            this.trainers = trainers;
            this.listings = listings;
        }

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
            System.Console.WriteLine("------");
            for(int i = 0; i<Booking.GetSessionIDCount(); i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }


        public void HistRevSessReport(){
            string reportContent = "";
            string curr = listings[0].GetDateTime().ToString("MMMM");
            int year = listings[0].GetDateTime().Year;
            double revenue = listings[0].GetCostOfSession();

            for(int i = 1; i < Listing.GetListingIDCount(); i++){
                if(listings[i].GetDateTime().ToString("MMMM") == curr && (listings[i].GetDateTime().Year == year)){
                    revenue+=listings[i].GetCostOfSession();
                }
                else{
                    ProcessBreak1(i,ref curr, ref year, ref revenue, listings, ref reportContent);
                }
                ProcessBreak1(ref curr,ref year,ref revenue, ref reportContent);
            }

            curr = listings[0].GetDateTime().ToString("MMMM");
            year = listings[0].GetDateTime().Year;
            revenue = listings[0].GetCostOfSession();


            for(int i = 1; i < Listing.GetListingIDCount(); i++){
                if(listings[i].GetDateTime().Year == year){
                    revenue+=listings[i].GetCostOfSession();
                }
                else{
                    ProcessBreak2(i,ref year, ref revenue, listings, ref reportContent);
                }
                ProcessBreak2(ref year,ref revenue, ref reportContent);
            }


            System.Console.WriteLine(reportContent);
            SaveReportToFile(reportContent);
        }

        public void ProcessBreak1(int i , ref string curr,ref int year,ref double revenue, Listing[] listings, ref string reportContent){
            string line = curr+ " "+ year +": $" + revenue+ "\n";
            reportContent+=line;

            curr = listings[i].GetDateTime().ToString("MMMM");
            revenue = listings[i].GetCostOfSession();
        }

        public void ProcessBreak1(ref string curr, ref int year, ref double revenue, ref string reportContent){
            string line = curr + " "+ year +": $" + revenue + "\n";
            reportContent+=line;
        }

        public void ProcessBreak2(int i ,ref int year,ref double revenue, Listing[] listings, ref string reportContent){
            string line = year +": $" + revenue+ "\n";
            reportContent+=line;

            revenue = listings[i].GetCostOfSession();
        }

        public void ProcessBreak2(ref int year, ref double revenue, ref string reportContent){
            string line = year +": $" + revenue + "\n";
            reportContent+=line;
        }
    }
}