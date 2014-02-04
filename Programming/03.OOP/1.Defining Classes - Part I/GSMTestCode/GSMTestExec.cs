namespace Mobile
{
    /// <summary>
    /// Task 7: "Write a class GSMTest to test the GSM class:
    ///             - Create an array of few instances of the GSM class.
    ///             - Display the information about the GSMs in the array.
    ///             - Display the information about the static property IPhone4S."
    /// </summary>
    public class GSMTestExec
    {
        public static void Main()
        {
            GSMTest testGSMclass = new GSMTest(5);
            testGSMclass.Initialize();
            testGSMclass.Print();
        }
    }
}