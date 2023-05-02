using mis_221_pa_5_szheng011;

//start main//
StreamReader inFile = new StreamReader("userManual.txt");
string userManual = inFile.ReadToEnd();
System.Console.WriteLine(userManual);
System.Console.WriteLine("\n");

Trainer[] trainers = new Trainer[100];
TrainerUtility trainerUtility = new TrainerUtility(trainers);

Listing[] listings = new Listing[100];
ListingUtility listingUtility = new ListingUtility(listings, trainers);

Booking[] bookings = new Booking[100];
BookingUtility bookingUtility = new BookingUtility(bookings,trainers,listings);

ReportUtility reportUtility = new ReportUtility(bookings,trainers,listings);

Review[] reviews = new Review[1000];
ReviewUtility reviewUtility = new ReviewUtility(bookings,trainers,listings,reviews);

trainerUtility.GetAllTrainersFromFile(trainers);
listingUtility.GetAllListingsFromFile(listings);
bookingUtility.GetAllTransactionsFromFile(bookings, listings);
reviewUtility.GetAllReviewsFromFile(reviews);

int userInput = -1;

while(userInput != 3){//program keeps going until userInput is 3
    MainMenu();
    if(IsValidOption(ref userInput)){
        RouteToPortal(ref userInput, trainerUtility, listingUtility, bookingUtility, reportUtility, reviewUtility);
    }
}
return;
//end main//

static void MainMenu(){
    System.Console.WriteLine("Main Menu:\nEnter 1 to Access Customer Portal\nEnter 2 to Access Operator Portal\nEnter 3 to Exit System");
}

static void CustomerMenu(){
    System.Console.WriteLine("Please enter:\n1 To Look at the list of available listings\n2 to Book an available listing\n3 to Add a Review for a previous session\n4 to View your Detailed Customer Report\n5 to Go back to Main Menu");
}

static void OperatorMenu(){
    System.Console.WriteLine("Please enter:\n1 to Manage Trainer Data\n2 to Manage Listing Data\n3 to Manage Customer Booking Data\n4 to Run Reports\n5 to Go back to Main Menu");
}

static void ManageTrainerMenu(){
    System.Console.WriteLine("Please enter:\n1 to Add a Trainer\n2 to Edit a Trainer\n3 to Delete a Trainer\n4 to Go back to Operator Menu");
}

static void ManageListingMenu(){
    System.Console.WriteLine("Please enter:\n1 to Add a Listing\n2 to Edit a Listing\n3 to Delete a Listing\n4 to Go back to Operator Menu");
}

static void ManageBookingMenu(){
    System.Console.WriteLine("Please enter:\n1 to View Available Training Sessions\n2 to Book a Training Session\n3 to Cancel a Customer Appointment\n4 to Mark a Customer Training Session as Complete\n5 to Go back to Operator Menu");
}

static void RunReportsMenu(){
    System.Console.WriteLine("Please enter which report you would like to run:\n1 for Individual Customer Session\n2 for Historical Customer Session\n3 for Historical Revenue Report\n4 for Detailed Customer Report\n5 for Trainer Report\n6 to Go back to Operator Menu");
}


static bool IsValidOption(ref int userInput){//returns whether the user entered a valid menu option (1,2,3)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3"){
        userInput = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidCustomerOpt(ref int customerMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4,5)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5"){
        customerMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidOperatorOpt(ref int operatorMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4,5)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5"){
        operatorMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidTrainerOpt(ref int trainerMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4"){
        trainerMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidListingOpt(ref int listingMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4"){
        listingMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidBookingOpt(ref int bookingMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4,5)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5"){
        bookingMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static bool IsValidReportOpt(ref int reportMenuOpt){//returns whether the user entered a valid menu option (1,2,3,4)
    string option = (Console.ReadLine());

    if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6"){
        reportMenuOpt = int.Parse(option);
        return true;
    }
    else {
        System.Console.WriteLine("Invalid Choice, please try again:");//reprompts the user if they entered an invalid menu option
        return false;
    }
}

static void RouteToPortal(ref int userInput, TrainerUtility trainerUtility, ListingUtility listingUtility, BookingUtility bookingUtility, ReportUtility reportUtility, ReviewUtility reviewUtility)
{
    if(userInput == 1){
        int customerMenuOpt = -1;
        Console.Clear();
        while(customerMenuOpt !=5){
            CustomerMenu();
            if(IsValidCustomerOpt(ref customerMenuOpt)){
                RouteToCustomer(ref customerMenuOpt, listingUtility, bookingUtility, reviewUtility, reportUtility);
            }
        }
    }
    else if(userInput == 2){
        int operatorMenuOpt = -1;
        Console.Clear();
        while(operatorMenuOpt != 5){
            OperatorMenu();
            if(IsValidOperatorOpt(ref operatorMenuOpt)){
                RouteToOperator(ref operatorMenuOpt, trainerUtility, listingUtility, bookingUtility, reportUtility);
            }
        }
    }
    else{
        return;
    }
}

static void RouteToCustomer(ref int customerMenuOpt, ListingUtility listingUtility, BookingUtility bookingUtility, ReviewUtility reviewUtility, ReportUtility reportUtility)
{
    if( customerMenuOpt == 1){
        Console.Clear();
        listingUtility.ViewAvailableSessions();
    }
    else if(customerMenuOpt == 2){
        Console.Clear();
        bookingUtility.BookSession();
    }
    else if(customerMenuOpt == 3){
        Console.Clear();
        reviewUtility.AddReview();
        
    }
    else if(customerMenuOpt == 4){
        Console.Clear();
        reportUtility.DetailedCustomerReport();
    }
    else{
        Console.Clear();
        return; //Go back to Main Menu
    }
}

static void RouteToOperator(ref int operatorMenuOpt, TrainerUtility trainerUtility, ListingUtility listingUtility, BookingUtility bookingUtility, ReportUtility reportUtility)
{
    if(operatorMenuOpt == 1){
        int manageTrainerOpt = -1;
        Console.Clear();
        while(manageTrainerOpt != 4){
            ManageTrainerMenu();
            if(IsValidTrainerOpt(ref manageTrainerOpt)){
                RouteToManageTrainer(ref manageTrainerOpt, trainerUtility);
            }
        }
    }
    else if(operatorMenuOpt == 2){
        int manageListingOpt = -1;
        Console.Clear();
        while(manageListingOpt != 4){
            ManageListingMenu();
            if(IsValidListingOpt(ref manageListingOpt)){
                RouteToManageListing(ref manageListingOpt, listingUtility);
            }
        }  
    }
    else if(operatorMenuOpt == 3){
       int manageBookingOpt = -1;
        Console.Clear();
        while(manageBookingOpt !=5){
            ManageBookingMenu();
            if(IsValidBookingOpt(ref manageBookingOpt)){
                RouteToManageBooking(ref manageBookingOpt, bookingUtility, listingUtility);
            }
        } 
    }
    else if(operatorMenuOpt == 4){
        int reportOpt = -1;
        Console.Clear();
        while(reportOpt != 6){
            RunReportsMenu();
            if(IsValidReportOpt(ref reportOpt)){
                RouteToRunReport(ref reportOpt, reportUtility);
            }
        } 
    }
    else if(operatorMenuOpt == 5){
        Console.Clear();
        return;
    }
}

static void RouteToManageTrainer(ref int manageTrainerOpt, TrainerUtility trainerUtility)
{
    if(manageTrainerOpt == 1){
        trainerUtility.AddTrainer();
    }
    else if(manageTrainerOpt == 2){
        trainerUtility.EditTrainer();
    }
    else if(manageTrainerOpt == 3){
        trainerUtility.DeleteTrainer();
    }
    else{
        return;
    }  
}

static void RouteToManageListing(ref int manageListingOpt, ListingUtility listingUtility)
{
    if(manageListingOpt == 1){
        listingUtility.AddListing();
    }
    else if(manageListingOpt == 2){
        listingUtility.EditListing();
    }
    else if(manageListingOpt== 3){
        listingUtility.DeleteListing();
    }  
    else{
        return;
    }
}

static void RouteToManageBooking(ref int manageBookingOpt, BookingUtility bookingUtility, ListingUtility listingUtility)
{
    if(manageBookingOpt == 1){
        listingUtility.ViewAvailableSessions();
    }
    else if(manageBookingOpt == 2){
        bookingUtility.BookSession();
    }
    else if(manageBookingOpt == 3){
        bookingUtility.CancelCustomerApptmt();
    }  
    else if(manageBookingOpt == 4){
        bookingUtility.CompleteCustomerApptmt();
    } 
    else{
        return;
    }
}

static void RouteToRunReport(ref int manageReportOpt, ReportUtility reportUtility)
{
    if(manageReportOpt == 1){
        reportUtility.IndivCustSessReport();
    }
    else if(manageReportOpt == 2){
        reportUtility.SortByCustDate();
        reportUtility.HistCustSessReport();
    }
    else if(manageReportOpt== 3){
        reportUtility.SortByMonthYear();
        reportUtility.HistRevSessReport();
    }
    else if(manageReportOpt== 4){
        reportUtility.DetailedCustomerReport(); //extra
    }  
    else if(manageReportOpt== 5){
        reportUtility.TrainerReport(); //extra
    }    
    else{
        return;
    }
}

