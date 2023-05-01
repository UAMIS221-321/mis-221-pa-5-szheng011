namespace mis_221_pa_5_szheng011
{
    public class ReviewUtility
    {
        Booking[] bookings;
        Trainer[] trainers;
        Listing[] listings;
        Review[] reviews;

        public ReviewUtility(Booking[] bookings, Trainer[] trainers, Listing[] listings, Review[] reviews){
            this.bookings = bookings;
            this.trainers = trainers;
            this.listings = listings;
            this.reviews = reviews;
        }

        //Populates an array of reviews
        public void GetAllReviewsFromFile(Review[] reviews){
            //open
            StreamReader inFile = new StreamReader("reviews.txt");
            //process
            string input  = inFile.ReadLine();
            while(input != null){
                string[] temp = input.Split('#');
                int tempID = int.Parse(temp[0]);
                int tempListingID = int.Parse(temp[2]);
                int tempRating = int.Parse(temp[4]);
                reviews[Review.GetReviewCount()] = new Review(tempID,temp[1],tempListingID,temp[3], tempRating);
                Review.IncReviewCount();
                Review.IncReviewIDCount();

                input = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }

        public void AddReview(){
            Review newReview = new Review();
            //Verify the customer exists
            System.Console.WriteLine("Please enter your first name:");
            string tempFirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter your last name:");
            string tempLastName = Console.ReadLine();
            System.Console.WriteLine("Please enter your email:");
            string tempCustomerEmail = Console.ReadLine();

            if((SearchCustomerByName(tempFirstName,tempLastName)!= -1)){ //the customer exists
                int index = SearchCustomerByName(tempFirstName, tempLastName);
                if(tempCustomerEmail.CompareTo(bookings[index].GetCustomerEmail()) == 0){ //the customer's email matches
                    //Verifying that the listing exists
                    System.Console.WriteLine("Please enter the listing ID of the event you want to react to:");
                    int tempListingID;
                    
                    if(int.TryParse(Console.ReadLine(), out tempListingID) && (SearchListingByID(tempListingID) != -1)){
                        newReview.SetID(Review.GetReviewID());
                        newReview.SetCustomerEmail(tempCustomerEmail);
                        newReview.SetListingID(listings[SearchListingByID(tempListingID)].GetListingID());
                        System.Console.WriteLine("Please enter your comment:");
                        newReview.SetComment(Console.ReadLine());
                        System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                        
                        int tempRating;
                        if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){ //error handling
                            newReview.SetRating(tempRating);
                        }
                        else{
                            bool isInvalidRating = true;
                            while(isInvalidRating == true){
                                System.Console.WriteLine("Invalid input, please try again");
                                System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
                                    newReview.SetRating(tempRating);
                                    isInvalidRating = false;
                                }
                            }
                        }
                    }
                    else{
                        bool isInvalidInt2 = true;

                        while(isInvalidInt2 == true){
                            System.Console.WriteLine("Invalid input, please try again");
                            System.Console.WriteLine("Please enter the event ID of the event you want to react to:");
                            if(int.TryParse(Console.ReadLine(), out tempListingID) && (SearchListingByID(tempListingID) != -1)){
                                newReview.SetID(Review.GetReviewID());
                                newReview.SetCustomerEmail(tempCustomerEmail);
                                newReview.SetListingID(listings[SearchListingByID(tempListingID)].GetListingID());
                                System.Console.WriteLine("Please enter your comment:");
                                newReview.SetComment(Console.ReadLine());
                                System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                
                                int tempRating;
                                if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){ //error handling
                                    newReview.SetRating(tempRating);
                                }
                                else{
                                    bool isInvalidRating = true;
                                    while(isInvalidRating == true){
                                        System.Console.WriteLine("Invalid input, please try again");
                                        System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                        if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
                                            newReview.SetRating(tempRating);
                                            isInvalidRating = false;
                                        }
                                    }
                                }
                            }
                                isInvalidInt2 = false;
                        }
                    }
                }
                else{
                    System.Console.WriteLine("Customer with the specified email was not found:(");
                }
            }
            else{
                System.Console.WriteLine("Customer with the specified first and last name was not found:(");
                return;
            }
            reviews[Review.GetReviewID()] = newReview;
            Review.IncReviewCount();
            Review.IncReviewIDCount();

            Save();
            
            
        }

        //Prints the current array of reviews to reactions.txt
        private void Save(){
            StreamWriter outFile = new StreamWriter("reviews.txt");

            for(int i = 0; i < Review.GetReviewCount(); i++){ 
                if(reviews[i].GetID() != -1){
                    outFile.WriteLine(reviews[i].ToFile());
                }
            }
            outFile.Close();
        }

        public int SearchReviewByID(int searchVal){
            for(int i = 0; i< Review.GetReviewCount(); i++){ 
                if(reviews[i].GetID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        public int SearchCustomerByName(string firstName, string lastName){
            for(int i = 0; i< Booking.GetSessionIDCount(); i++){ 
                if((bookings[i].GetCustomerFirstName().CompareTo(firstName) == 0) && (bookings[i].GetCustomerLastName().CompareTo(lastName) == 0) ){
                    return i;
                }
            }
            return -1;
        }

        public int SearchCustomerByEmail(string email){
            for(int i = 0; i< Booking.GetSessionIDCount(); i++){ 
                if((bookings[i].GetCustomerEmail().CompareTo(email) == 0) ){
                    return i;
                }
            }
            return -1;
        }

        public int SearchListingByID(int searchVal){
            for(int i = 0; i< Listing.GetListingIDCount(); i++){ 
                if(listings[i].GetListingID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
    }
}