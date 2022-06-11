namespace Test_task
{
    public class Odds
    {
        public float ACoef { get; set; }
        public float BCoef { get; set; }
        public int[] CCoef { get; set; }
        public int CurCCoef { get; set; }

        public Odds(int[] values)
        {
            ACoef = 0;
            BCoef = 0;
            CCoef = values;
            CurCCoef = 0;
        }
    }
}
