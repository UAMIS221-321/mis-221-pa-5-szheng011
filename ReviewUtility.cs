// namespace mis_221_pa_5_szheng011
// {
//     public class ReviewUtility
//     {
//         Booking[] bookings;
//         Trainer[] trainers;
//         Listing[] listings;
//         Review[] reviews;

//         public ReviewUtility(Booking[] bookings, Trainer[] trainers, Listing[] listings, Review[] reviews){
//             this.bookings = bookings;
//             this.trainers = trainers;
//             this.listings = listings;
//             this.reviews = reviews;
//         }

//         //Populates an array of reviews
//         public void GetAllReviewsFromFile(Review[] reviews){
//             //open
//             StreamReader inFile = new StreamReader("reviews.txt");
//             //process
//             string input  = inFile.ReadLine();
//             while(input != null){
//                 string[] temp = input.Split('#');
//                 int tempID = int.Parse(temp[0]);
//                 int tempCustomerID = int.Parse(temp[1]);
//                 int tempListingID = int.Parse(temp[4]);
//                 int tempRating = int.Parse(temp[6]);
//                 reviews[Review.GetReviewCount()] = new Review(tempID, tempCustomerID, temp[2], temp[3], tempListingID, temp[5], tempRating);
//                 Review.IncReviewCount();
//                 Review.IncReviewIDCount();

//                 input = inFile.ReadLine();
//             }
//             //close
//             inFile.Close();
//         }

//         public void AddReview(){
//             //Verify the customer exists
//             System.Console.WriteLine("Please enter your first name:");
//             string tempFirstName = Console.ReadLine();
//             System.Console.WriteLine("Please enter your last name:");
//             string tempLastName = Console.ReadLine();
//             System.Console.WriteLine("Please enter your email:");
//             string tempCustomerEmail;

//             if(int.TryParse(Console.ReadLine(), out tempCustomerID)){
//                 if((SearchCustomerByName(tempFirstName,tempLastName)!= -1)){ //the customer exists
//                     int index = SearchCustomerByName(tempFirstName, tempLastName);
//                     if(tempCustomer == bookings[index].GetCustomerEmail()){ //the customer's matches
//                         //Verifying that the event exists
//                         System.Console.WriteLine("Please enter the event ID of the event you want to react to:");
//                         int tempEventID;
                        
//                         if(int.TryParse(Console.ReadLine(), out tempEventID) && (SearchEventByID(tempEventID) != -1)){
//                             newReaction.SetID(Reaction.GetReactionID());
//                             newReaction.SetStudentID(tempStudentID);
//                             newReaction.SetFirstName(tempFirstName);
//                             newReaction.SetLastName(tempLastName);
//                             newReaction.SetEventName(events[SearchEventByID(tempEventID)].GetName());
//                             System.Console.WriteLine("Please enter your comment:");
//                             newReaction.SetComment(Console.ReadLine());
//                             System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                            
//                             int tempRating;
//                             if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){ //error handling
//                                 newReaction.SetRating(tempRating);
//                             }
//                             else{
//                                 bool isInvalidRating = true;
//                                 while(isInvalidRating == true){
//                                     System.Console.WriteLine("Invalid input, please try again");
//                                     System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
//                                     if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
//                                         newReaction.SetRating(tempRating);
//                                         isInvalidRating = false;
//                                     }
//                                 }
//                             }
//                         }
//                         else{
//                             bool isInvalidInt2 = true;

//                             while(isInvalidInt2 == true){
//                                 System.Console.WriteLine("Invalid input, please try again");
//                                 System.Console.WriteLine("Please enter the event ID of the event you want to react to:");
//                                 if(int.TryParse(Console.ReadLine(), out tempEventID) && (SearchEventByID(tempEventID) != -1)){ //error handling
//                                     newReaction.SetID(Reaction.GetReactionID());
//                                     newReaction.SetStudentID(tempStudentID);
//                                     newReaction.SetFirstName(tempFirstName);
//                                     newReaction.SetLastName(tempLastName);
//                                     newReaction.SetEventName(events[SearchEventByID(tempEventID)].GetName());
//                                     System.Console.WriteLine("Please enter your comment:");
//                                     newReaction.SetComment(Console.ReadLine());
//                                     System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                    
//                                     int tempRating;
//                                     if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){ //error handling
//                                         newReaction.SetRating(tempRating);
//                                     }
//                                     else{
//                                         bool isInvalidRating = true;
//                                         while(isInvalidRating == true){
//                                             System.Console.WriteLine("Invalid input, please try again");
//                                             System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
//                                             if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
//                                                 newReaction.SetRating(tempRating);
//                                                 isInvalidRating = false;
//                                             }
//                                         }
//                                     }
//                                     isInvalidInt2 = false;
//                                 }
//                             }
//                         }
//                     }
//                     else{
//                     System.Console.WriteLine("Student with the specified student ID was not found:(");
//                     }
//                 }
//                 else{
//                     System.Console.WriteLine("Student with the specified first and last name was not found:(");
//                     return;
//                 }
                
//             }
//             else{
//                 bool isInvalidInt = true;

//                 while(isInvalidInt == true){
//                     System.Console.WriteLine("Invalid input, please try again");
//                     System.Console.WriteLine("Please enter your student ID:");
//                     if(int.TryParse(Console.ReadLine(), out tempStudentID)){
//                         if((SearchStudentByName(tempFirstName,tempLastName)!= -1)){ //the student exists
//                             int index = SearchStudentByName(tempFirstName, tempLastName);
//                             if(tempStudentID == students[index].GetID()){ //the student's ID matches
//                                 //Verifying that the event exists
//                                 System.Console.WriteLine("Please enter the event ID of the event you want to react to:");
//                                 int tempEventID;
                                
//                                 if(int.TryParse(Console.ReadLine(), out tempEventID) && (SearchEventByID(tempEventID) != -1)){
//                                     newReaction.SetID(Reaction.GetReactionID());
//                                     newReaction.SetStudentID(tempStudentID);
//                                     newReaction.SetFirstName(tempFirstName);
//                                     newReaction.SetLastName(tempLastName);
//                                     newReaction.SetEventName(events[SearchEventByID(tempEventID)].GetName());
//                                     System.Console.WriteLine("Please enter your comment:");
//                                     newReaction.SetComment(Console.ReadLine());
//                                     System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                    
//                                     int tempRating;
//                                     if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
//                                         newReaction.SetRating(tempRating);
//                                     }
//                                     else{
//                                         bool isInvalidRating = true;
//                                         while(isInvalidRating == true){
//                                             System.Console.WriteLine("Invalid input, please try again");
//                                             System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
//                                             if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
//                                                 newReaction.SetRating(tempRating);
//                                                 isInvalidRating = false;
//                                             }
//                                         }
//                                     }
//                                 }
//                                 else{
//                                     bool isInvalidInt2 = true;

//                                     while(isInvalidInt2 == true){ //error handling
//                                         System.Console.WriteLine("Invalid input, please try again");
//                                         System.Console.WriteLine("Please enter the event ID of the event you want to react to:");
//                                         if(int.TryParse(Console.ReadLine(), out tempEventID) && (SearchEventByID(tempEventID) != -1)){
//                                             newReaction.SetID(Reaction.GetReactionID());
//                                             newReaction.SetStudentID(tempStudentID);
//                                             newReaction.SetFirstName(tempFirstName);
//                                             newReaction.SetLastName(tempLastName);
//                                             newReaction.SetEventName(events[SearchEventByID(tempEventID)].GetName());
//                                             System.Console.WriteLine("Please enter your comment:");
//                                             newReaction.SetComment(Console.ReadLine());
//                                             System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
                                            
//                                             int tempRating;
//                                             if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){ //error handling
//                                                 newReaction.SetRating(tempRating);
//                                             }
//                                             else{
//                                                 bool isInvalidRating = true;
//                                                 while(isInvalidRating == true){
//                                                     System.Console.WriteLine("Invalid input, please try again");
//                                                     System.Console.WriteLine("Please enter your rating on a scale of 1 to 10, with 10 being the best:");
//                                                     if(int.TryParse(Console.ReadLine(), out tempRating) && (tempRating > 0 && tempRating < 11)){
//                                                         newReaction.SetRating(tempRating);
//                                                         isInvalidRating = false;
//                                                     }
//                                                 }
//                                             }
//                                             isInvalidInt2 = false;
//                                         }
//                                     }
//                                 }
//                             }
//                             else{
//                             System.Console.WriteLine("Student with the specified student ID was not found:(");
//                             }
//                         }
//                         else{
//                             System.Console.WriteLine("Student with the specified first and last name was not found:(");
//                             return;
//                         }

//                         isInvalidInt = false;
//                     }
//                 }
//             }
//             reactions[Reaction.GetReactionID()] = newReaction;
//             Reaction.IncReactionCount();
//             Reaction.IncReactionIDCount();

//             Save();
            
//         }
//     }
// }