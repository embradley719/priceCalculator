using System;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare input prices and then initialize to zero.
            double num1 = 0;
            double costToUs = 0;
            double mapPrice = 0;
            double competitorPrice = 0;
            
            // Decalre constants
            double centThreshold = 0.50;

            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            // Intake Cost to Us
            Console.WriteLine("Type the Cost to Us, and then press Enter");
            costToUs = Convert.ToDouble(Console.ReadLine());

            // Intake MAP Price
            Console.WriteLine("Type the Cost to Us, and then press Enter");
            mapPrice = Convert.ToDouble(Console.ReadLine());

            // Intake Competitor Price
            Console.WriteLine("Type the Cost to Us, and then press Enter");
            competitorPrice = Convert.ToDouble(Console.ReadLine());

            // Percent Less than Competitor
            double percentLessThanComp = 0.00;
            if (competitorPrice <= 25)
            {
                percentLessThanComp = 0.05;
            }
            else if (competitorPrice <= 50)
            {
                percentLessThanComp = 0.07;
            }
            else if (competitorPrice <= 100)
            {
                percentLessThanComp = 0.08;
            }
            else if (competitorPrice <= 250)
            {
                percentLessThanComp = 0.09;
            }
            else
            {
                percentLessThanComp = 0.10;
            };

            Console.WriteLine($"Percent less than the Competitor: {percentLessThanComp}");

            // Base Retail Price
            double baseRetailPrice = (competitorPrice - ((competitorPrice - costToUs) * percentLessThanComp));
            Console.WriteLine($"Base Retail Price: {baseRetailPrice}");

            // Retail Price 1
            double retailPriceOne = 0.00;
            double roundedOne = Math.Floor(baseRetailPrice);
            double difOne = baseRetailPrice - roundedOne;
            if (difOne < centThreshold)
            {
                double total = difOne + 0.03;
                retailPriceOne = baseRetailPrice - total;
            }
            else
            {
                retailPriceOne = baseRetailPrice;
            }

            // Retail Price 2 
            double retailPriceTwo = 0.00;
            double negCorrection = ((competitorPrice - mapPrice) * percentLessThanComp);
            double roundedTwo = Math.Floor(negCorrection);
            double difTwo = negCorrection - roundedTwo;
            if (difTwo < centThreshold)
            {
                double total = difTwo + 0.03;
                retailPriceTwo = negCorrection - total;
            }
            else
            {
                retailPriceTwo = negCorrection;
            }

            //Retail Price 3
            double retailPriceThree = 0.00;

            // Internet Price
            double internetPrice = 0.00;
            if ((competitorPrice - mapPrice) < 0)
            {
                internetPrice = retailPriceThree;
            }
            else if (mapPrice > 0)
            {
                internetPrice = retailPriceTwo;
            }
            else
            {
                internetPrice = retailPriceOne;
            }

            Console.WriteLine($"Internet Price: {internetPrice}");

            // Internet Profit
            double internetProfit = (internetPrice - costToUs);
            Console.WriteLine($"Internet Profit: {internetProfit}");

            // Internet Margin
            double internetMargin = (internetProfit / internetPrice);
            Console.WriteLine($"Internet Margin: {internetMargin}");

            // Minimum Percent of Competitor's Margin
            double minPerCompMargin = 0.00;
            if (costToUs <= 25)
            {
                minPerCompMargin = 0.5;
            }
            else if (costToUs <= 50)
            {
                minPerCompMargin = 0.40;
            }
            else if (costToUs <= 100)
            {
                minPerCompMargin = 0.35;
            }
            else if (costToUs <= 250)
            {
                minPerCompMargin = 0.30;
            }
            else
            {
                minPerCompMargin = 0.25;
            };

            Console.WriteLine($"Minimum Percent of Competitor's Margin: {minPerCompMargin}");

            // Minimum Negotiated Price
            double minNegotPrice = 0.00;
            if (mapPrice > 0)
            {
                minNegotPrice = mapPrice;
            }
            else
            {
                minNegotPrice = costToUs + (minPerCompMargin * (competitorPrice - costToUs));
            }

            Console.WriteLine($"Minimum Nogotitated Price: {minNegotPrice}");

            // Negotiated Margin
            double negotMargin = (minNegotPrice - costToUs) / minNegotPrice;
            Console.WriteLine($"Negotiated Margin: {negotMargin}");

            // Negotiated Profit
            double negotProfit = (minNegotPrice - costToUs);
            Console.WriteLine($"Negotiated ProfitL {negotProfit}");
            
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();
        }
    }
}
