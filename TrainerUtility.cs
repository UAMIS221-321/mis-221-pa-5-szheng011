namespace mis_221_pa_5_szheng011
{
    public class TrainerUtility
    {
        public Trainer[] trainers;

        //constructor
        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        //Populates an array of trainers from file
        public void GetAllTrainersFromFile(Trainer[] trainers){
            //open
            StreamReader inFile = new StreamReader("trainers.txt");
            //process
            string input  = inFile.ReadLine();
            while(input != null){
                string[] temp = input.Split('#');
                int tempID = int.Parse(temp[0]);

                trainers[Trainer.GetTrainerIDCount()] = new Trainer(tempID, temp[1],temp[2],temp[3],temp[4]);
                Trainer.IncTrainerCount();
                //Trainer.SetTrainerIDCount(Trainer.GetTrainerIDCount() + 1);
                Trainer.SetTrainerIDCount(tempID + 1);
                input = inFile.ReadLine();
            }
            //close
            inFile.Close();
        }

        //Adds a trainer to the file: trainers.txt
        public void AddTrainer(){
            Trainer newTrainer = new Trainer();

            newTrainer.SetTrainerID(Trainer.GetTrainerIDCount());
            System.Console.WriteLine("Please enter the first name of the trainer:");
            newTrainer.SetTrainerFirstName(Console.ReadLine());
            System.Console.WriteLine("Please enter the last name of the trainer:");
            newTrainer.SetTrainerLastName(Console.ReadLine());
            System.Console.WriteLine("Please enter the mailing address of the trainer:");
            newTrainer.SetTrainerMailingAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the email address of the trainer:");
            newTrainer.SetTrainerEmailAddress(Console.ReadLine());

            trainers[Trainer.GetTrainerIDCount()] = newTrainer; 
            Trainer.IncTrainerCount();
            Trainer.IncTrainerIDCount();

            Save();
        }

        //Updates a trainer's information in the file: trainers.txt
        public void EditTrainer(){
            System.Console.WriteLine("What value would you like to search by to edit a trainer?");
            System.Console.WriteLine("Enter 1 to Search Trainer by ID\nEnter 2 to Search Trainer by Name");

            bool isValidSearchOpt = false;
            bool isValidSearchVal = false;
            int searchOpt;
            int foundIndex;
            int searchVal;

            while(isValidSearchOpt == false){ //error handling
                if(int.TryParse(Console.ReadLine(), out searchOpt) && (searchOpt == 1 || searchOpt == 2)){
                    isValidSearchOpt = true;
                    if(searchOpt == 1){ //Search by Trainer ID
                        System.Console.WriteLine("Please enter the ID of the trainer you would like to edit:");
                        while(isValidSearchVal == false){
                            if(int.TryParse(Console.ReadLine(), out searchVal)){ //error handling
                                foundIndex = SearchByID(searchVal);
                                if(foundIndex != -1){ //the trainer exists
                                    System.Console.WriteLine("Editing mode.......");
                                    System.Console.WriteLine("Please enter the first name of the trainer:");
                                    trainers[foundIndex].SetTrainerFirstName(Console.ReadLine());
                                    System.Console.WriteLine("Please enter the last name of the trainer:");
                                    trainers[foundIndex].SetTrainerLastName(Console.ReadLine());
                                    System.Console.WriteLine("Please enter the mailing address of the trainer:");
                                    trainers[foundIndex].SetTrainerMailingAddress(Console.ReadLine());
                                    System.Console.WriteLine("Please enter the email address of the trainer:");
                                    trainers[foundIndex].SetTrainerEmailAddress(Console.ReadLine());

                                    Save();
                                }
                                else{
                                    System.Console.WriteLine("Trainer with the specified ID was not found:(");
                                }
                                isValidSearchVal = true;
                            }
                            else{
                                System.Console.WriteLine("Please try again and enter a valid input:");
                                System.Console.WriteLine("Please enter the ID of the trainer you would like to edit:");
                            }
                        }
                            
                    }
                    else if(searchOpt == 2){ //Search by Trainer Name
                        System.Console.WriteLine("Please enter the first name of the trainer you would like to edit:");
                        string firstName = Console.ReadLine();
                        System.Console.WriteLine("Please enter the last name of the trainer you would like to edit:");
                        string lastName = Console.ReadLine();

                        foundIndex = SearchByName(firstName, lastName);
                            
                        if(foundIndex != -1){
                            System.Console.WriteLine("Editing mode.......");
                            System.Console.WriteLine("Please enter the first name of the trainer:");
                            trainers[foundIndex].SetTrainerFirstName(Console.ReadLine());
                            System.Console.WriteLine("Please enter the last name of the trainer:");
                            trainers[foundIndex].SetTrainerLastName(Console.ReadLine());
                            System.Console.WriteLine("Please enter the mailing address of the trainer:");
                            trainers[foundIndex].SetTrainerMailingAddress(Console.ReadLine());
                            System.Console.WriteLine("Please enter the email address of the trainer:");
                            trainers[foundIndex].SetTrainerEmailAddress(Console.ReadLine());

                            Save();
                        }
                        else{
                            System.Console.WriteLine("Trainer with the specified first and last name was not found:(");
                        }
                    }
                    isValidSearchOpt = true;
                }
                else{
                    System.Console.WriteLine("Invalid input, please try again");
                    System.Console.WriteLine("Enter 1 to Search Trainer by ID\nEnter 2 to Search Trainer by Name");
                }
            }
        }

        //Deletes a trainer's information from the file: trainers.txt
        //Only allows operator to delete a trainer by using trainer ID in case there are trainers with the same name
        public void DeleteTrainer(){
            System.Console.WriteLine("Please enter the Trainer ID of the trainer you want to delete");
            int searchVal;
            int foundIndex;
            bool isValidSearchVal = false;

            while(isValidSearchVal == false){
                if(int.TryParse(Console.ReadLine(), out searchVal)){
                    foundIndex = SearchByID(searchVal);
                    isValidSearchVal = true;

                    if(foundIndex != -1){
                        trainers[foundIndex].SetTrainerID(-1);
                        trainers[foundIndex].SetTrainerFirstName("DeletedTrainer");
                        trainers[foundIndex].SetTrainerLastName("DeletedTrainer");
                        trainers[foundIndex].SetTrainerMailingAddress("DeletedTrainer");
                        trainers[foundIndex].SetTrainerEmailAddress("DeletedTrainer");
                        Trainer.DecTrainerCount();
                    }
                    else{
                        System.Console.WriteLine("Trainer with the specified ID was not found:");
                    }
                }
                else{
                    System.Console.WriteLine("Invalid input, please try again.");
                    System.Console.WriteLine("Please enter the Trainer ID of the student you want to delete");
                }
                Trainer.DecTrainerCount();
                Save();
            }
        }

        //Writes trainer info to the file: trainers.txt
        private void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetTrainerIDCount(); i++){
                if(trainers[i].GetTrainerID() != -1){
                    outFile.WriteLine(trainers[i].ToFile());
                }

            }

            outFile.Close();
        }

        //Sequential search to find the ID of trainer in trainers.txt to edit by returning the index
        public int SearchByID(int searchVal){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if(trainers[i].GetTrainerID() == searchVal){
                    return i;
                }
            }
            return -1;
        }

        //Sequential search to find the name of trainer in trainers.txt to edit by returning the index
        public int SearchByName(string firstName, string lastName){
            for(int i = 0; i< Trainer.GetTrainerIDCount(); i++){
                if((trainers[i].GetTrainerFirstName().CompareTo(firstName) == 0) && (trainers[i].GetTrainerLastName().CompareTo(lastName) == 0)){
                    return i;
                }
            }
            return -1;
        }

    }
}