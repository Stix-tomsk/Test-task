using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Test_task
{
    /// <summary>
    /// Реализация Model логики приложения
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// Поле для хранения значений коэффициентов функций
        /// </summary>
        public Odds[] funcData { get; set; }
        
        /// <summary>
        /// Поле для хранения значений результатов вычисления функций
        /// </summary>
        public List<float>[] funcResults { get; set; }

        /// <summary>
        /// Конструктор класса MainModel, в котором происходит 
        /// инициализация полей funcData и funcResults,
        /// а также заполнение коэффициентов C и создание трех
        /// пустых строк таблицы для каждой функции
        /// </summary>
        public MainModel()
        {
            funcData = new Odds[5];
            funcResults = new List<float>[5];

            for (int i = 0; i < 5; i++)
            {
                int[] COdds = new int[5];
                for (int j = 0; j < 5; j++)
                    COdds[j] = (int)((j + 1) * Math.Pow(10, i));
                funcData[i] = new Odds(COdds);
                funcResults[i] = new List<float>();
                for (int j = 0; j < 3; j++)
                {
                    funcData[i].xCoefs.Add(0f);
                    funcData[i].yCoefs.Add(0f);
                    funcResults[i].Add(0f);
                }
            }
        }

        /// <summary>
        /// Функция для вычисления значения выбранной функции
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <param name="x"> Значение коэффициента X выбранной функции </param>
        /// <param name="y"> Значение коэффициента Y выбранной функции </param>
        /// <returns> Значение полученное в результате вычисления выбранной функции</returns>
        /// </summary>
        public float CalculateFunc(int funcId, float x, float y)
        {
            return ((float)(funcData[funcId].aCoef * Math.Pow(x, funcId + 1) + funcData[funcId].bCoef * Math.Pow(y, funcId) + funcData[funcId].cCoef[funcData[funcId].curCCoef]));
        }

        /// <summary>
        /// Функция для вычисления значений выбранной функции для
        /// каждой строки таблицы
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// </summary>
        public void CalculateFuncColumn(int funcId)
        {
            for (int i = 0; i < funcData[funcId].xCoefs.Count; i++)
                (funcResults[funcId])[i] = CalculateFunc(funcId, funcData[funcId].xCoefs[i], funcData[funcId].yCoefs[i]);
        }

        /// <summary>
        /// Функция для обновления значений коэффициентов функций
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <param name="coef"> Имя изменяемого коэффициента </param>
        /// <param name="data"> Обновленное значение выбранного коэффициента </param>
        /// </summary>
        public void UpdateData(int funcId, string coef, string data, int valueId = 0)
        {
            switch (coef)
            {
                case nameof(OddNames.aCoef):
                    if (data == "")
                        funcData[funcId].aCoef = 0;
                    else
                        funcData[funcId].aCoef = Convert.ToSingle(data);
                    break;
                case nameof(OddNames.bCoef):
                    if (data == "")
                        funcData[funcId].bCoef = 0;
                    else
                        funcData[funcId].bCoef = Convert.ToSingle(data);
                    break;
                case nameof(OddNames.curCCoef):
                    for (int i = 0; i < 5; i++)
                        if (funcData[funcId].cCoef[i] == Convert.ToInt32(data))
                            funcData[funcId].curCCoef = i;
                    break;
                case nameof(OddNames.xCoef):
                    funcData[funcId].xCoefs[valueId] = Convert.ToSingle(data);
                    break;
                case nameof(OddNames.yCoef):
                    funcData[funcId].yCoefs[valueId] = Convert.ToSingle(data);
                    break;
            }

        }

        /// <summary>
        /// Функция для генерации строкового массива с введенными коэффициентами A, B
        /// и выбранным C необходимой функции
        /// для передачи их во View через ViewModel
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <returns> Строковый массив, содержащий необходимые коэффициенты выбранной функции </returns>
        /// </summary>
        public string[] UpdataOddFields(int funcId) => new string[3]{
            funcData[funcId].aCoef.ToString(),
            funcData[funcId].bCoef.ToString(),
            funcData[funcId].cCoef[funcData[funcId].curCCoef].ToString()
        };

        /// <summary>
        /// Функция для генерации строкового массива списка коэффициентов C
        /// выбранной функции для передачи их во View через ViewModel
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <returns> Строковый массив коэффициентов C выбранной функции </returns>
        /// </summary>
        public string[] GetItemList(int funcId)
        {
            string[] itemList = new string[5];
            for (int i = 0; i < 5; i++)
                itemList[i] = (funcData[funcId].cCoef[i].ToString());
            return itemList;
        }

        /// <summary>
        /// Функция для генерации выбранной колонки таблицы
        /// необходимой функции для передачи их во View через ViewModel
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <param name="colId"> Индекс выбранной колонки </param>
        /// <returns> Список элементов TextBox с необходимыми значениями ячеек </returns>
        /// </summary>
        public ObservableCollection<TextBox> GetColumn(int funcId, int colId)
        {
            ObservableCollection<TextBox> column = new ObservableCollection<TextBox>();
            switch (colId)
            {
                case 0:
                    for (int i = 0; i < funcData[funcId].xCoefs.Count; i++)
                    {
                        TextBox textBox = CreateTextBox((funcResults[funcId])[i].ToString());
                        textBox.IsReadOnly = true;
                        column.Add(textBox);
                    }
                    break;
                case 1:
                    for (int i = 0; i < funcData[funcId].xCoefs.Count; i++)
                    {
                        TextBox textBox = CreateTextBox(funcData[funcId].xCoefs[i].ToString());
                        column.Add(textBox);
                    }
                    break;
                case 2:
                    for (int i = 0; i < funcData[funcId].xCoefs.Count; i++)
                    {
                        TextBox textBox = CreateTextBox(funcData[funcId].yCoefs[i].ToString());
                        column.Add(textBox);
                    }
                    break;
            }
            return column;
        }

        /// <summary>
        /// Функция для создания элемента TextBox 
        /// <param name="value"> Значение элемента TextBox </param>
        /// <returns> TextBox элемент с указанным значением </returns>
        /// </summary>
        private TextBox CreateTextBox(string value)
        {
            TextBox textBox = new TextBox();
            textBox.Text = value;
            return textBox;
        }

        /// <summary>
        /// Функция для генерации таблицы необходимой функции
        /// для передачи во View через ViewModel
        /// <param name="funcId"> Индекс выбранной функции </param>
        /// <param name="scaling"> Флаг масштабирования таблицы </param>
        /// <returns> Массив списков элементов TextBox, содержащий колонки таблицы </returns>
        /// </summary>
        public ObservableCollection<TextBox>[] GetTable(int funcId, bool scaling = false)
        {
            if (scaling)
            {
                funcData[funcId].xCoefs.Add(0f);
                funcData[funcId].yCoefs.Add(0f);
                funcResults[funcId].Add(0f);
            }
            
            ObservableCollection<TextBox>[] table = new ObservableCollection<TextBox>[3];
            for (int i = 0; i < 3; i++)
            {
                table[i] = GetColumn(funcId, i);
            }

            return table;
        }

        /// <summary>
        /// Функция для валидации переданных данных
        /// <param name="value"> Переданные данные </param>
        /// <returns> Булево значение корректности данных </returns>
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
