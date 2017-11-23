/* 
 * Program Name:    AreaOfACircle
 * Author:          Alfred Massardo
 * Date:            November 23, 2017
 * 
 * Description:     A console application request a radius from a user and calculate the
 *                  area of a circle. It will also validate that the radius is a positive
 *                  numeric. If it is not a positive numeric the radius will be requested
 *                  again until the user enters a positive numeric.
 *                  
 *                  Also, I included a section of code that tries to demonstrate how the
 *                  Double.TryParse(string s, out double result) function works.
 *                  I created my own TryParse(string s, out double result) function that 
 *                  you can step through to see how functions work, and specifically how
 *                  the TryParse might work.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfACircle
{
    class Program
    {
        static void Main(string[] args)
        {

            ///////////////
            // Declarations
            ///////////////

            ///////////////
            // Constants
            ///////////////
            const double exponentTwo = 2;
            const double pI = 3.141593;

            ///////////////
            // Variables
            ///////////////
            double radius = 111;
            double area = 0;

            bool firstTime = true;
            bool isDouble = false;


            // This do/while loop uses the Double.TryParse(string s, out double result) function
            // There is also a commented section below this that uses a function I created to give 
            // you a better idea of how the TryParse function works. 
            // I created my own TryParse(string s, out double result) function that does the same
            // thing as Double.TryParse(string s, out double result), but you can step through my
            // TryParse(string s, out double result) to see how the  Double.TryParse(string s, out double result)
            // might work and how it returns information.
            do
            {

                // If it is the first time through the loop
                if (firstTime == true)
                {
                    // Display the following message to the user
                    Console.Write("Please enter a the radius of the circle: ");
                }
                else
                {
                    // Display the error message to the user
                    Console.Write("\nError!!!\n\tThe radius needs o be a positive number ");
                }

                // check to see if the user input is a double and
                // assign the value that the TryParse function returns
                // to the isDouble variable
                isDouble = Double.TryParse(Console.ReadLine(), out radius);


            } while (!(isDouble)        // if the isDouble is false
                        || radius < 0   // OR if the radius is less than 0 the loop will continue
                    );

            //// Alternate TryParse Start
            //do
            //{
            //    // If it is the first time through the loop
            //    if (firstTime == true)
            //    {
            //        // Display the following message to the user
            //        Console.Write("Please enter a the radius of the circle: ");
            //    }
            //    else
            //    {
            //        // Display the error message to the user
            //        Console.Write("\nError!!!\n\tThe radius needs o be a positive number ");
            //    }

            //    // check to see if the user input is a double and
            //    // assign the value that the TryParse function returns
            //    // to the isDouble variable
            //    isDouble = TryParse(Console.ReadLine(), out radius);  // Uses the custom TryParse

            //} while (!(isDouble)        // if the isDouble is false
            //            || radius < 0   // OR if the radius is less than 0 the loop will continue
            //        );
            //// Alternate TryParse End

            // Processing

            // Calculate the area of the circle
            area = Math.PI * Math.Pow(radius,exponentTwo);

            //OR
            //area = pI * (radius * radius);

            // Show the user the their input and
            // the results of the calculation. 
            Console.Write("\nWith a radius of {0:n1} the area of the circle would be {1:n1},\n",
                        radius,
                        area);

            // Ask the user to press any key to end the program
            // \n - use the newline escape character to move the output to the next line.
            Console.Write("\nPress any key to end this application...");

            // Use the Console ReadKey to pause the program until the user presses any key
            // to end the application.
            Console.ReadKey();

        }

        /// <summary>
        /// This function take a string
        /// </summary>
        /// <param name="s">string value to try and convert to a double</param>
        /// <param name="result">out value that will be assign the double that has been input by string if the string can be converted to a double 
        ///                 or 0 (zero) if the number cannot be converted to a double </param>
        /// <returns>boolean true if the string was converted to a double or false if the string could not be converted to a double</returns>
        static bool  TryParse(string s, out double result)
        {

            // Declarations

            // Variables
            bool returnValue; // will be set to true or false depending on if the s (string) variable could be converted to a double

            // "try/catch" statements are similar to an "if" statement 
            // try everything in the try block ( start { One and end } Two  ) and if something does not work between the { One and } Two,
            // jump to the catch block ( start { three and end } Four  )  and do everything between the { three and } four
            try
            { // One

                // convert the s variable to a double
                result = Convert.ToDouble(s);

                // if the value converted assign returnValue to true
                // if it did not convert it will not get to this point it would
                // have already jumped to the catch statement below.
                returnValue = true;

            } // Two
            catch //(Exception ex)
            { // Three

                // if it did not convert because the string did not represent a number
                // then you will be here in the catch block

                // set the result value to 0 (zero)
                result = 0;

                // set the return value to false
                returnValue = false;

            } // Four

            // return the value in the returnValue variable
            return returnValue;

        }

    }
}
