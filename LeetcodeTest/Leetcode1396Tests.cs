using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeTest
{
    [TestFixture]
    public class LeetCode1396Test
    {
    }

    public class UndergroundSystem
    {
        private readonly List<CustomerWithTravelInfo> CustomerWithTravelInfos = new List<CustomerWithTravelInfo>();
        private readonly List<CustomerTravelPeriod> CustomerTravelPeriods = new List<CustomerTravelPeriod>();
        public UndergroundSystem() {
        
        }
    
        public void CheckIn(int id, string stationName, int t)
        {
            CustomerWithTravelInfos.Add(new CustomerWithTravelInfo
            {
                CustomerId = id,
                CheckInStation = stationName,
                CheckInTime = t,
            });
        }
    
        public void CheckOut(int id, string stationName, int t)
        {
            var customerWithTravelInfo = CustomerWithTravelInfos.First(customerWithTravelInfo  => customerWithTravelInfo.CustomerId == id);
            customerWithTravelInfo.CheckOutStation = stationName;
            customerWithTravelInfo.CheckOutTime = t;
            CustomerTravelPeriods.Add(new CustomerTravelPeriod
            {
                CheckInStation = customerWithTravelInfo.CheckInStation,
                CheckOutStation = customerWithTravelInfo.CheckOutStation,
                Period = customerWithTravelInfo.CheckOutTime - customerWithTravelInfo.CheckInTime
            });
            CustomerWithTravelInfos.Remove(customerWithTravelInfo);
        }
    
        public double GetAverageTime(string startStation, string endStation)
        {
            return CustomerTravelPeriods.Where(x => x.CheckInStation == startStation && x.CheckOutStation == endStation)
                .Average(x => x.Period);
        }

        private class CustomerWithTravelInfo
        {
            public int CustomerId { get; set; }
            public string CheckInStation { get; set; }
            public int CheckInTime { get; set; }
            public string CheckOutStation { get; set; }
            public int CheckOutTime { get; set; }
        }

        private class CustomerTravelPeriod
        {
            public string CheckInStation { get; set; }
            public string CheckOutStation { get; set; }
            public int Period { get; set; }
        }
    }

 
}