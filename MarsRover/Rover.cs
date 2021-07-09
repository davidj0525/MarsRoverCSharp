using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position = 500)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        /* Have to create a method to recieve the message.  Will 
         * try method to take in a message as an argument, then
         * will parse commands to an array.  Then iterate over array
         * to dictate behavior.
         */

        public void ReceiveMessage(Message message)
        {
            Command[] reachableCommandsArr = message.Commands;

            // tried a try/catch, but changed to an if/else which worked better for me
                foreach (Command comm in reachableCommandsArr)
                {
                    if (comm.CommandType == "MODE_CHANGE")
                    {
                        this.Mode = comm.NewMode;
                    }
                    else
                    {
                        if ((this.Mode == "LOW_POWER") && (this.Position >= 0))
                        {
                            throw new ArgumentOutOfRangeException("Rover can't move while in LOW_POWER mode");
                        }
                        this.Position = comm.NewPostion;
                    }
                }
        }



        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
