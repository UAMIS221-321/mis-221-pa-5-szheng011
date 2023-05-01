namespace mis_221_pa_5_szheng011
{
    public class ListingUtility
    {
        public Listing[] listings;
        Trainer[] trainers;

        //Listing Utility constructor
        public ListingUtility(Listing[] listings, Trainer[] trainers){
            this.listings = listings;
            this.trainers = trainers;
        }

        //Populates an array of listings from file
        public void GetAllListingsFromFile(Listing[] listings){
            //open
            StreamReader inFile = new StreamReader("listings.txt");
            //process
            string input  = inFile.ReadLine();
            while(input != null){
                string[] temp = input.Split('#');
                int tempID = int.Parse(temp[0]);
                DateTime tempDateTime = DateTime.Parse(temp[2]);
                double tempCostOfSession = double.Parse(temp[3]);
                int tempTrainerID = int.Parse(temp[4]);

                listings[Listing.GetListingIDCount()] = new Listing(tempID, temp[1], tempDateTime, tempCostOfSession,tempTrainerID,temp[5],temp[6]);
                Listing.IncListingCount();
                Listing.SetListingIDCount(tempID + 1);
                input = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }

        //Add a listing to the listings.txt file
        public void AddListing(){
            Listing newListing = new Listing();

            System.Console.WriteLine("Please enter the first name for the trainer of this listing:");
            string tempTrainerFirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter the last name for the trainer of this listing:");
            string tempTrainerLastName = Console.ReadLine();
            System.Console.WriteLine("Please enter the trainer ID for the trainer of this listing:");
            int tempTrainerID;
            int index = SearchByTrainerName(tempTrainerFirstName, tempTrainerLastName);

            if((int.TryParse(Console.ReadLine(), out tempTrainerID)) &&(SearchByTrainerName(tempTrainerFirstName, tempTrainerLastName) != -1) && (tempTrainerID == trainers[index].GetTrainerID())){
                newListing.SetTrainerID(tempTrainerID);
                newListing.SetTrainerFirstName(tempTrainerFirstName);
                newListing.SetTrainerLastName(tempTrainerLastName);

                newListing.SetListingID(Listing.GetListingIDCount());
                System.Console.WriteLine("Please enter the name for the listing:");
                newListing.SetListingName(Console.ReadLine());
                System.Console.WriteLine("Please enter the date and time for the listing");
                System.Console.WriteLine("Please follow the format MM/DD/YYYY HH:MM AM/PM");
                System.Console.WriteLine("For example: 4/21/2023 8:18 PM");
                DateTime dateTime = new DateTime();
                if(DateTime.TryParse(Console.ReadLine(), out dateTime)){
                    newListing.SetDateTime(dateTime);
                }
                else{
                    bool isInvalidDateTime = true;

                    while(isInvalidDateTime == true){
                        System.Console.WriteLine("Invalid input, please try again");
                        System.Console.WriteLine("Please enter the date and time for the listing");
                        System.Console.WriteLine("Please follow the format MM/DD/YYYY HH:MM AM/PM");
                        System.Console.WriteLine("For example: 4/21/2023 8:18 PM");
                        if(DateTime.TryParse(Console.ReadLine(), out dateTime)){
                            newListing.SetDateTime(dateTime);
                            isInvalidDateTime = false;
                        }
                    }
                }

                System.Console.WriteLine("Please enter the amount for the cost of the session:");
                double costOfSession;
                if(double.TryParse(Console.ReadLine(), out costOfSession)){
                    newListing.SetCostOfSession(costOfSession);
                }
                else{
                    bool isInvalidCost = true;

                    while(isInvalidCost == true){
                        System.Console.WriteLine("Invalid input, please try again");
                        System.Console.WriteLine("Please enter the amount for the cost of the session:");
                        if(double.TryParse(Console.ReadLine(), out costOfSession)){
                            newListing.SetCostOfSession(costOfSession);
                            isInvalidCost = false;
                        }
                    }
                } 

                listings[Listing.GetListingIDCount()] = newListing; 
                Listing.IncListingCount();
                Listing.IncListingIDCount();

                Save();
            }
            else{
                System.Console.WriteLine("Invalid input, please try again");
            }
        }

        //Only allows operator to edit a listing by using listing ID in case there are listings with the same name
        public void EditListing(){
            System.Console.WriteLine("Please enter the ID# of the listing that you would like to edit:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Search(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Editing mode......");
                System.Console.WriteLine("Please enter the first name for the trainer of this listing:");
                string tempTrainerFirstName = Console.ReadLine();
                System.Console.WriteLine("Please enter the last name for the trainer of this listing:");
                string tempTrainerLastName = Console.ReadLine();
                System.Console.WriteLine("Please enter the trainer ID for the trainer of this listing:");
                int tempTrainerID;
                int index = SearchByTrainerName(tempTrainerFirstName, tempTrainerLastName);

                if((int.TryParse(Console.ReadLine(), out tempTrainerID)) &&(SearchByTrainerName(tempTrainerFirstName, tempTrainerLastName) != -1) && (tempTrainerID == trainers[index].GetTrainerID())){
                    listings[foundIndex].SetTrainerFirstName(tempTrainerFirstName);
                    listings[foundIndex].SetTrainerLastName(tempTrainerLastName);

                    // listings[foundIndex].SetListingID(Listing.GetListingIDCount());
                    System.Console.WriteLine("Please enter the name for the listing:");
                    listings[foundIndex].SetListingName(Console.ReadLine());
                    System.Console.WriteLine("Please enter the date and time for the listing");
                    System.Console.WriteLine("Please follow the format MM/DD/YYYY HH:MM AM/PM");
                    System.Console.WriteLine("For example: 4/21/2023 8:18 PM");
                    DateTime dateTime = new DateTime();
                    if(DateTime.TryParse(Console.ReadLine(), out dateTime)){
                        listings[foundIndex].SetDateTime(dateTime);
                    }
                    else{
                        bool isInvalidDateTime = true;

                        while(isInvalidDateTime == true){
                            System.Console.WriteLine("Invalid input, please try again");
                            System.Console.WriteLine("Please enter the date and time for the listing");
                            System.Console.WriteLine("Please follow the format MM/DD/YYYY HH:MM AM/PM");
                            System.Console.WriteLine("For example: 4/21/2023 8:18 PM");
                            if(DateTime.TryParse(Console.ReadLine(), out dateTime)){
                                listings[foundIndex].SetDateTime(dateTime);
                                isInvalidDateTime = false;
                            }
                        }
                    }

                    System.Console.WriteLine("Please enter the amount for the cost of the session:");
                    double costOfSession;
                    if(double.TryParse(Console.ReadLine(), out costOfSession)){
                        listings[foundIndex].SetCostOfSession(costOfSession);
                    }
                    else{
                        bool isInvalidCost = true;

                        while(isInvalidCost == true){
                            System.Console.WriteLine("Invalid input, please try again");
                            System.Console.WriteLine("Please enter the amount for the cost of the session:");
                            if(double.TryParse(Console.ReadLine(), out costOfSession)){
                                listings[foundIndex].SetCostOfSession(costOfSession);
                                isInvalidCost = false;
                            }
                        }
                    } 
                    Save();
                }
                else{
                    System.Console.WriteLine("Invalid input, please try again");
                }
            }
            else{
                System.Console.WriteLine("Invalid input, please try again");

            }
        }

        public void DeleteListing(){
            System.Console.WriteLine("Please enter the ID# of the listing you would like to delete:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Search(searchVal);

            if(foundIndex != -1){
                listings[foundIndex].SetListingID(-1);
                listings[foundIndex].SetListingName("DeletedListing");
                DateTime deletedListing = new DateTime(0001,01,01,01,01,01);
                listings[foundIndex].SetDateTime(deletedListing);
                listings[foundIndex].SetCostOfSession(0);
                listings[foundIndex].SetIsListingTaken("Deleted");
                Trainer.DecTrainerCount();
            }
            else{
                System.Console.WriteLine("Listing was not found :(");
            }
            Listing.DecListingCount();
            Save();
        }

        public void ViewAvailableSessions(){
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetListingIDCount(); i++){
                if(listings[i].GetIsListingTaken().CompareTo("Not Taken") == 0){
                    System.Console.WriteLine(listings[i].ToString());
                    System.Console.WriteLine();
                }
            }
            Save();
            outFile.Close();
        }

        private void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetListingIDCount(); i++){
                if(listings[i].GetListingID() != -1){
                    outFile.WriteLine(listings[i].ToFile());
                }

            }
            outFile.Close();
        }

        public int Search(int searchVal){
            for(int i = 0; i< Listing.GetListingIDCount(); i++){
                if(listings[i].GetListingID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        //Sequential search to find the ID of trainer in trainers.txt to edit by returning the index
        public int SearchByTrainerID(int searchVal){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if(trainers[i].GetTrainerID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        //Sequential search to find the name of trainer in trainers.txt to edit by returning the index
        public int SearchByTrainerName(string firstName, string lastName){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if((trainers[i].GetTrainerFirstName().CompareTo(firstName) == 0) && (trainers[i].GetTrainerLastName().CompareTo(lastName) == 0)){
                    return i;
                }
            }
            return -1;
        }
    }
}
