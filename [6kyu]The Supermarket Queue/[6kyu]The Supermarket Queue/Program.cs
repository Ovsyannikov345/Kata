using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kata
{
    public static long QueueTime(int[] queue, int tillsCount)
    {
        List<int> customers = new List<int>(queue);

        int elapsedTime = 0;

        while (customers.Count > tillsCount)
        {
            int fastestCustomer = customers[0];

            for (var i = 1; i < tillsCount; i++)
            {
                if (customers[i] < fastestCustomer)
                {
                    fastestCustomer = customers[i];
                }
            }

            int customersInProgress = tillsCount;

            for (var i = 0; i < customersInProgress; i++)
            {
                if (customers[i] > fastestCustomer)
                {
                    customers[i] -= fastestCustomer;
                }
                else
                {
                    customers.RemoveAt(i);
                    customersInProgress--;
                    i--;
                }
            }

            elapsedTime += fastestCustomer;
        }

        if (customers.Count > 0)
        {
            elapsedTime += customers.Max();
        }

        return elapsedTime;
    }
}