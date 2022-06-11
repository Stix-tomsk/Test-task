using System;

namespace Test_task
{
    public class Model
    {
        /// <summary>
        /// Field for containing function odd values 
        /// </summary>
        public Odds[] FuncData { get; set; }

        public Model()
        {
            FuncData = new Odds[5];

            for (int i = 0; i < 5; i++)
            {
                int[] COdds = new int[5];
                for (int j = 0; j < 5; j++)
                    COdds[j] = (int)((j + 1) * Math.Pow(10, i));
                FuncData[i] = new Odds(COdds);
            }
        }

        /// <summary>
        /// Function for calculating value of necessary function
        /// <param name="funcId"> A value of choosed function id </param>
        /// <param name="x"> A value X coefficient of function </param>
        /// <param name="y"> A value Y coefficient of function </param>
        /// <returns> A float value obtained as a result of the calculation of the function</returns>
        /// </summary>
        public float CalculateFunc(int funcId, float x, float y)
        {
            return ((float)(FuncData[funcId].ACoef * Math.Pow(x, funcId + 1) + FuncData[funcId].BCoef * Math.Pow(y, funcId) + FuncData[funcId].CCoef[FuncData[funcId].CurCCoef]));
        }

        /// <summary>
        /// Function for updating data of each function odds
        /// <param name="funcId"> A value of choosed function id </param>
        /// <param name="coef"> A name of necessary function </param>
        /// <param name="data"> A data that must be updated </param>
        /// </summary>
        public void UpdateData(int funcIndex, string coef, string data)
        {
            switch (coef)
            {
                case "Acoef":
                    if (data == "")
                        FuncData[funcIndex].ACoef = 0;
                    else
                        FuncData[funcIndex].ACoef = Convert.ToSingle(data);
                    break;
                case "Bcoef":
                    if (data == "")
                        FuncData[funcIndex].BCoef = 0;
                    else
                        FuncData[funcIndex].BCoef = Convert.ToSingle(data);
                    break;
                case "Ccoef":
                    for (int i = 0; i < 5; i++)
                        if (FuncData[funcIndex].CCoef[i] == Convert.ToInt32(data))
                            FuncData[funcIndex].CurCCoef = i;
                    break;
            }

        }

        /// <summary>
        /// Function for generating string odds values so the ViewModel can send them to View 
        /// <param name="funcId"> A value of choosed function id </param>
        /// <returns> A string array stored current values of necessary function</returns>
        /// </summary>
        public string[] UpdataOddFields(int funcId) => new string[3]{
            FuncData[funcId].ACoef.ToString(),
            FuncData[funcId].BCoef.ToString(),
            FuncData[funcId].CCoef[FuncData[funcId].CurCCoef].ToString()
        };

        /// <summary>
        /// Function for identification of choosed fucntion id 
        /// <param name="funcName"> A name of choosed function </param>
        /// <returns> An id value of choosed function </returns>
        /// </summary>
        public int IdentFuncId(string funcName)
        {
            string[] funcs = new string[5] { "linear", "quadratic", "cubic", "fourthDegree", "fifthDegree" };
            for (int i = 0; i < funcs.Length; i++)
                if (funcs[i] == funcName)
                    return i;
            return 0;
        }

        /// <summary>
        /// Function for generating string list of C coefficient values 
        /// so the ViewModel can send them to View  
        /// <param name="funcId"> A value of choosed function id </param>
        /// <returns> A string array stored current values of current function C odds </returns>
        /// </summary>
        public string[] GetItemList(int funcId)
        {
            string[] itemList = new string[5];
            for (int i = 0; i < 5; i++)
                itemList[i] = (FuncData[funcId].CCoef[i].ToString());
            return itemList;
        }

        /// <summary>
        /// Function for validation of an input data
        /// <param name="value"> An input data </param>
        /// <returns> A data validity bool value</returns>
        /// </summary>
        public bool ValidateData(string value)
        {
            try
            {
                Convert.ToSingle(value);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
    }
}
