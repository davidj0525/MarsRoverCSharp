using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            /* I need to have the rover receive a message which will be 
             * an array of commands.  The rover needs to parse through
             * the array and act on the command contained.  I will try
             * to make a method that goes through each command and acts
             * according to some if/else statements. 
             */


            Rover myRover = new Rover(20);
            Console.WriteLine(myRover.ToString());

            Command[] firstCommand = { new Command("MODE_CHANGE", "NORMAL"), new Command("MOVE", 50) };

            Message firstMessage = new Message("Testing", firstCommand);

            myRover.ReceiveMessage(firstMessage);

            Console.WriteLine(myRover.ToString());

            // OK, it works, now let's try low power mode.

            Command[] secondCommand = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 500) };

            Message secondMessage = new Message("Low power move try", secondCommand);

            myRover.ReceiveMessage(secondMessage);

            Console.WriteLine(myRover.ToString());


            //Command[] test2 = { new Command("MOVE", 100) };

            //Message kaka = new Message("Yet another test", test2);

            //myRover.ReceiveMessage(kaka);

            //Console.WriteLine(myRover.ToString());


        }
    }
}
