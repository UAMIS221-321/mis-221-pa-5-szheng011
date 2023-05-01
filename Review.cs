namespace mis_221_pa_5_szheng011
{
    public class Review
    {
        private int iD;
        private string customerEmail;
        private int listingID;
        private string comment;
        private int rating;
        static private int reviewCount = 0;
        static private int reviewID = 0;

        public Review(){

        }

        public Review(int iD, string customerEmail, int listingID, string comment, int rating){
            this.iD =iD;
            this.customerEmail= customerEmail;
            this.listingID =listingID;
            this.comment = comment;
            this.rating = rating;
        }

        public void SetID(int iD){
            this.iD = iD;
        }

        public int GetID(){
            return iD;
        }

        public void SetListingID(int listingID){
            this.listingID = listingID;
        }

        public int GetListingID(){
            return listingID;
        }

        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetCustomerEmail(){
            return customerEmail;
        }

        public void SetComment(string comment){
            this.comment = comment;
        }

        public string GetComment(){
            return comment;
        }

        public void SetRating(int rating){
            this.rating = rating;
        }

        public int GetRating(){
            return rating;
        }

        static public void IncReviewCount(){
            Review.reviewCount++;
        }

        static public void DecReviewCount(){
            Review.reviewCount--;
        }

        static public int GetReviewCount(){
            return Review.reviewCount;
        }

        static public void IncReviewIDCount(){
            Review.reviewID++;
        }

        static public void SetReviewID(int reviewID){
            Review.reviewID= reviewID;
        }

        static public int GetReviewID(){
            return Review.reviewID;
        }

        public string ToFile()
        {
            return $"{iD}#{customerEmail}#{listingID}#{comment}#{rating}";
        }
    }
}