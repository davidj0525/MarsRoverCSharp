using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPostion { get; set; }
        public string NewMode { get; set; }


        //public Command(string commandType, int position = 500, string mode = "")
        //{
        //    CommandType = commandType;
        //    NewPostion = position;
        //    NewMode = mode;
        //    if(String.IsNullOrEmpty(commandType))
        //    {
        //        throw new ArgumentNullException(commandType, "Command type required.");
        //    }
        //    if (String.IsNullOrEmpty(mode))
        //    {
        //        throw new ArgumentNullException(mode, "Mode required.");
        //    }
        //}

        public Command(string commandType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, string newMode)
        {
            CommandType = commandType;
            NewMode = newMode;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, int? value)
        {
            CommandType = commandType;
            
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }

            if (value != null)
            {
                NewPostion = (int)value;
            }

        }

    }
}
