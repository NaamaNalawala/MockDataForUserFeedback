using System;

namespace InsertDataToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            IMockData mockData = new MockData();
           string data= mockData.GetJSONObjectFromMockData(1000);
        }
    }
}
