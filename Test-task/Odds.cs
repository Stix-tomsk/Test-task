using System.Collections.Generic;

namespace Test_task
{
    /// <summary>
    /// Класс, содержащий поля для хранения коэффициентов функции
    /// </summary>
    public class Odds
    {
        public float aCoef { get; set; }
        public float bCoef { get; set; }
        public int[] cCoef { get; set; }
        public int curCCoef { get; set; }
        public List<float> xCoefs { get; set; }
        public List<float> yCoefs { get; set; }


        public Odds(int[] values)
        {
            aCoef = 0;
            bCoef = 0;
            cCoef = values;
            curCCoef = 0;
            xCoefs = new List<float>();
            yCoefs = new List<float>();
        }
    }
}
