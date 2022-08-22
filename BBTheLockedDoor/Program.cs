namespace BBTheLockedDoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a four digit passcode: ");
            int startingPasscode = Convert.ToInt32(Console.ReadLine());

            Door myDoor = new Door(startingPasscode);

            Console.WriteLine("Please enter a new four digit passcode");
            int newPasscode = Convert.ToInt32(Console.ReadLine());

            myDoor.ChangePassCode(startingPasscode, newPasscode);

            Console.WriteLine($"{myDoor.DoorControl("open")}");

            Console.WriteLine($"{myDoor.DoorControl("close")}");            

            Console.WriteLine($"{myDoor.DoorControl("lock")}");

            Console.WriteLine($"{myDoor.DoorControl("unlock", newPasscode)}");

        }
    }

    public class Door
    {
        private int _passcode;

        DoorStatus currentStatus = DoorStatus.Close;

        public Door(int passcode)
        {
            _passcode = passcode;
        }

        public void ChangePassCode(int existingPasscode, int newPasscode)
        {
            if (_passcode == existingPasscode)
            {
                _passcode = newPasscode;
                Console.WriteLine("Passcode changed successfully");
            }
            else
            {
                Console.WriteLine("Incorrect existing Passcode, passcode has not been changed.");
            }
        }

        internal DoorStatus DoorControl(string input, int passcode = 0000)
        {
            if (currentStatus == DoorStatus.Lock && input == "unlock" && passcode == _passcode)
            {
                currentStatus = DoorStatus.Unlock;
            }

            if (currentStatus == DoorStatus.Close && input == "open")
            {
                currentStatus = DoorStatus.Open;
            }

            if (currentStatus == DoorStatus.Open && input == "close")
            {
                currentStatus = DoorStatus.Close;
            }

            if (currentStatus == DoorStatus.Close && input == "lock")
            {
                currentStatus = DoorStatus.Lock;
            }

            return currentStatus;
        }
    }    
    enum DoorStatus { Open, Close, Lock, Unlock };
}