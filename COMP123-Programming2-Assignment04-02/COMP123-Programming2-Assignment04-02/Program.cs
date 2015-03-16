﻿/*
 * studentName:Bin Liang | studentNumber:300788322
 * Date last Modified:March 14th,2015
 * Program description:COMP123_Assignment04,Array Practice-Airline Reservations System.
 * Revision	History:
 * 1.Debug successfully.
 * 2.Never assign a seat that has already been assigned.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_Programming2_Assignment04_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // random number generator
            Random rand= new Random();
            bool[] seats = new bool[10];
            
            //To keep a separate list of seats taken         
            List<int> seatsBooked = new List<int>();
            int inputI = 0;
            char inputS = ' ';
            bool quit = false;
            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Please type [1] for First Class" +
                                 " \nPlease type [2] for Economy" +
                                  "\nPlease type [3] to exit the order system");
                inputI = Int32.Parse(Console.ReadLine());
                switch (inputI)
                {
                    case 1:                                                
                        int seatAssignF; //Variable moved from main loop
                        //Are there any seats booked already or this is the first?
                        if (seatsBooked.Count == 0) //if this is the first seat to be booked...
                        {
                            seatAssignF = rand.Next(0, 5);
                            seats[seatAssignF] = true;
                            seatsBooked.Add(seatAssignF);  //Add seat to the list of booked seats.                           
                        }
                        else
                        {
                            do //while there are available seats and current seat has not being assigned before.
                            {
                                seatAssignF = rand.Next(0, 5);
                                if (!seatsBooked.Contains(seatAssignF)) //if seatAssingF is not booked.
                                {
                                    seats[seatAssignF] = true;                                   
                                }
                                //repeat while the random seat number is already booked and there are  avaialable seats
                            } while (seatsBooked.Contains(seatAssignF) && seatsBooked.Count < 5);

                            if (seatsBooked.Count < 5) //if seatsBooked list is not full for First Class
                            {
                                seatsBooked.Add(seatAssignF); //Add current random-generated seat to the list.
                            } 
                        }
                        //
                        if (seatsBooked.Count >= 5)
                        {
                            Console.WriteLine("All seats for First Class are booked");
                            Console.WriteLine("If it’s acceptable to be placed in the economy-class?");
                            Console.WriteLine("Please type [2] for Economy Class" +
                                 " \nPlease type [n] to exit the order systemy");
                            inputS = Char.Parse(Console.ReadLine());
                            if (inputS == '2')
                            {
                                Console.WriteLine("Press enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine("Next flight leaves in 3 hours.");
                                Console.WriteLine("Press enter to continue...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your seat: {0}", seatAssignF + 1);
                            Console.WriteLine("Press enter to continue...");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        int seatAssignE;
                        if (seatsBooked.Count == 0) //if this is the economy seat to be booked...
                        {
                            seatAssignE = rand.Next(5, 10);
                            seats[seatAssignE] = true;
                            seatsBooked.Add(seatAssignE);  //Add seat to the list of booked seats.                           
                        }
                        else
                        {
                            do //while there are available seats and current seat has not being assigned before.
                            {
                                seatAssignE = rand.Next(5, 10);
                                if (!seatsBooked.Contains(seatAssignE)) //if seatAssingE is not booked.
                                {
                                    seats[seatAssignE] = true;
                                }
                                //repeat while the random seat number is already booked and there are  avaialable seats
                            } while (seatsBooked.Contains(seatAssignE) && seatsBooked.Count < 5);

                            if (seatsBooked.Count < 5) //if seatsBooked list is not full for Economy Class
                            {
                                seatsBooked.Add(seatAssignE); //Add current random-generated seat to the list.
                            }
                        }
                        if (seatsBooked.Count >= 5)
                        {
                            Console.WriteLine("All seats for Economy Class are booked");
                            Console.WriteLine("If it’s acceptable to be placed in the First-class?");
                            Console.WriteLine("Please type [y] for First Class" +
                                 " \nPlease type [n] to exit the order systemy");
                            inputS = Char.Parse(Console.ReadLine());
                            if (inputS == 'y')
                            {
                                Console.WriteLine("Please type [1] for First-class.");
                                Console.WriteLine("Press enter to continue...");
                            }
                            else
                            {
                                Console.WriteLine("Next flight leaves in 3 hours.");
                                Console.WriteLine("Press enter to continue...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your seat: {0}", seatAssignE + 1);
                            Console.WriteLine("Press enter to continue...");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("ERROR::INVALID SELECTION");
                        quit = true;
                        break;
                }
            } 

            waitForAnyKey();
        }

        private static void waitForAnyKey()
        {
            Console.Write("\n");
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Console.WriteLine("Please hit any key to exit....");
            Console.ReadKey();
        }
    }
}
