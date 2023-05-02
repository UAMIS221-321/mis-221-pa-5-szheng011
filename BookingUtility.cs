namespace mis_221_pa_5_szheng011
{
    public class BookingUtility
    {
        Booking[] bookings;
        Trainer[] trainers;
        Listing[] listings;

        //constructor
        public BookingUtility(Booking[] bookings, Trainer[] trainers, Listing[] listings){
            this.bookings = bookings;
            this.trainers = trainers;
            this.listings = listings;
        }

        //Populates an array of trainers from file
        public void GetAllTransactionsFromFile(Booking[] bookings, Listing[] listings){
            //open
            StreamReader inFile = new StreamReader("transactions.txt");
            //process
            string input  = inFile.ReadLine();
            while(input != null){
                string[] temp = input.Split('#');
                int tempID = int.Parse(temp[0]);
                DateTime tempDateTime = DateTime.Parse(temp[4]);
                int tempTrainerID = int.Parse(temp[5]);
                double tempCostOfSession = double.Parse(temp[8]);

                bookings[Booking.GetSessionIDCount()] = new Booking(tempID,temp[1],temp[2],temp[3],tempDateTime,tempTrainerID,temp[6],temp[7],tempCostOfSession);
                Booking.IncSessionCount();
                Booking.SetSessionIDCount(tempID + 1);
                input = inFile.ReadLine();
            }
            //close
            inFile.Close();

            for(int i = 0; i < Booking.GetSessionCount();i++){
                for(int j = 0; j<Listing.GetListingIDCount();j++){
                    if((bookings[i].GetSessionStatus() == "Booked") && (listings[j].GetDateTime() == bookings[i].GetTrainingDate()) &&(listings[j].GetTrainerID() == bookings[i].GetTrainerID())){
                        listings[j].SetListingToTaken();
                    }
                }
            }
        }

        public void BookSession(){
            Booking newBooking = new Booking();

            //Verifying that the listing exist
            System.Console.WriteLine("Please enter the listing ID of the listing the customer wants to book:");
            int tempListingID;

            if(int.TryParse(Console.ReadLine(), out tempListingID) && (SearchListingByID(tempListingID) != -1)){ //the listing exists
                newBooking.SetSessionID(Booking.GetSessionIDCount());
                System.Console.WriteLine("Please enter the first name of the customer:");
                newBooking.SetCustomerFirstName(Console.ReadLine());
                System.Console.WriteLine("Please enter the last name of the customer:");
                newBooking.SetCustomerLastName(Console.ReadLine());
                System.Console.WriteLine("Please enter the email of the customer:");
                newBooking.SetCustomerEmail(Console.ReadLine());
                newBooking.SetTrainingDate(listings[SearchListingByID(tempListingID)].GetDateTime());
                newBooking.SetTrainerID(listings[SearchListingByID(tempListingID)].GetTrainerID());
                newBooking.SetTrainerFirstName(listings[SearchListingByID(tempListingID)].GetTrainerFirstName());
                newBooking.SetTrainerLastName(listings[SearchListingByID(tempListingID)].GetTrainerLastName());
                newBooking.SetCostOfSession(listings[SearchListingByID(tempListingID)].GetCostOfSession());


            }
            else{
                bool isInvalidInt = true;

                while(isInvalidInt == true){
                    System.Console.WriteLine("Invalid input, please try again");
                    System.Console.WriteLine("Please enter the listing ID of the listing you want to book:");
                    if(int.TryParse(Console.ReadLine(), out tempListingID) && (SearchListingByID(tempListingID) != -1)){ //the listing exists
                        newBooking.SetSessionID(Booking.GetSessionIDCount());
                        System.Console.WriteLine("Please enter the first name of the customer:");
                        newBooking.SetCustomerFirstName(Console.ReadLine());
                        System.Console.WriteLine("Please enter the last name of the customer:");
                        newBooking.SetCustomerLastName(Console.ReadLine());
                        System.Console.WriteLine("Please enter the email of the customer:");
                        newBooking.SetCustomerEmail(Console.ReadLine());
                        newBooking.SetTrainingDate(listings[SearchListingByID(tempListingID)].GetDateTime());
                        newBooking.SetTrainerID(listings[SearchListingByID(tempListingID)].GetTrainerID());
                        newBooking.SetTrainerFirstName(listings[SearchListingByID(tempListingID)].GetTrainerFirstName());
                        newBooking.SetTrainerLastName(listings[SearchListingByID(tempListingID)].GetTrainerLastName());
                        newBooking.SetCostOfSession(listings[SearchListingByID(tempListingID)].GetCostOfSession());

                        isInvalidInt = false;
                    }
                }  
            }

            //Sets the listing to taken once someone books the session
            listings[tempListingID].SetIsListingTaken("Taken");

            bookings[Booking.GetSessionIDCount()] = newBooking;
            Booking.IncSessionCount();
            Booking.IncSessionIDCount();

            Save();
        }

        public void CancelCustomerApptmt(){
            System.Console.WriteLine("Please enter the Session ID to change the status of the session to Cancelled");
            int tempSessionID;

            if((int.TryParse(Console.ReadLine(),out tempSessionID)) && (SearchSessionByID(tempSessionID) != -1)){
                bookings[tempSessionID].SetSessionStatus("Cancelled");
            }
            else{
                bool isInvalidSessID = true;

                while(isInvalidSessID == true){
                    System.Console.WriteLine("Invalid input, please try again");
                    System.Console.WriteLine("Please enter the Session ID to change the status of the session to Cancelled");
                    if((int.TryParse(Console.ReadLine(),out tempSessionID)) && (SearchSessionByID(tempSessionID) != -1)){
                        bookings[tempSessionID].SetSessionStatus("Cancelled");
                        isInvalidSessID = false;
                    }
                }
            }

            Save();
        }

        public void CompleteCustomerApptmt(){
            System.Console.WriteLine("Please enter the Session ID to change the status of the session to Completed");
            int tempSessionID;

            if((int.TryParse(Console.ReadLine(),out tempSessionID)) && (SearchSessionByID(tempSessionID) != -1)){
                bookings[tempSessionID].SetSessionStatus("Completed");
            }
            else{
                bool isInvalidSessID = true;

                while(isInvalidSessID == true){
                    System.Console.WriteLine("Invalid input, please try again");
                    System.Console.WriteLine("Please enter the Session ID to change the status of the session to Completed");
                    if((int.TryParse(Console.ReadLine(),out tempSessionID)) && (SearchSessionByID(tempSessionID) != -1)){
                        bookings[tempSessionID].SetSessionStatus("Completed");
                        isInvalidSessID = false;
                    }
                }
            }

            Save();
        }

        public int SearchListingByID(int searchVal){
            for(int i = 0; i<= Listing.GetListingIDCount(); i++){
                if(listings[i].GetListingID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        public int SearchSessionByID(int searchVal){
            for(int i = 0; i<= Booking.GetSessionIDCount(); i++){
                if(bookings[i].GetSessionID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        //Writes transaction info to the file: transactions.txt
        private void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetSessionIDCount(); i++){
                if(bookings[i].GetSessionID() != -1){
                    outFile.WriteLine(bookings[i].ToFile());
                }
            }
            outFile.Close();
        }

    }
}
