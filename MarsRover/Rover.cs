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

        public void ReceiveMessage(Message message)
        {
            Command[] reachableCommandsArr = message.Commands;

            //try
            //{
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
            //}
            //catch
            //{
            //    if ((this.Mode == "LOW_POWER") && (this.Position >= 0))
            //    {
            //        throw new ArgumentOutOfRangeException("Rover can't move while in LOW_POWER mode");
            //    }
            //}
        }

        //public void ReceiveMessage(Message message)
        //{
        //    Command[] commArr = message.Commands;
        //    try
        //    {
        //        foreach (Command command in commArr)
        //        {
        //            if (Mode == "MODE_CHANGE")
        //            {
        //                this.Mode = command.NewMode;

        //            }

        //            else
        //            {
        //                this.Position = command.NewPostion;
        //            }
        //        }

        //        catch
        //        {
        //            if ((this.Mode == "LOW_POWER") && (this.Position >= 0))
        //            {
        //                throw new ArgumentOutOfRangeException("Rover can't move while in LOW_POWER mode");
        //            }

        //        }
        //    }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
