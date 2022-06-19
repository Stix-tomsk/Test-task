using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Test_task
{
    /// <summary>
    /// Реализация ViewModel логики приложения
    /// </summary>
    class MainViewModel : ViewModelBase
    {

        /// <summary>
        /// Шесть полей для хранения значений коэффициентов функций
        /// </summary>
        private ObservableCollection<string> _cOdds;
        private string _curCCoef;
        private string _bCoef;
        private string _aCoef;
        private string _xCoef;
        private string _yCoef;

        /// <summary>
        /// Три поля для хранения индексов выбранных ячеек таблицы
        /// </summary>
        private string _funcIndex;
        private string _xIndex;
        private string _yIndex;

        /// <summary>
        /// Три поля для хранения содержимого колонок таблицы
        /// </summary>
        private ObservableCollection<TextBox> _funcColumn;
        private ObservableCollection<TextBox> _xColumn;
        private ObservableCollection<TextBox> _yColumn;

        /// <summary>
        /// Поле для хранения сообщения об ошибке
        /// </summary>
        private string _errorLabel;

        /// <summary>
        /// Поле для реализации взаимодействия между ViewModel и Model
        /// </summary>
        private MainModel model { get;set; }

        /// <summary>
        /// Поле для хранения состояния ошибки ввода в ячейках таблицы
        /// </summary>
        private bool thereIsError { get; set; }

        /// <summary>
        /// Связанное поле для обновления значения коэффициента А в Model
        /// и отображения во View
        /// </summary>
        public string aCoef
        {
            get { return _aCoef; }
            set
            {
                if (!model.ValidateData(value))
                {
                    errorLabel = "Input float type value!";
                    return;
                }
                _aCoef = value;
                model.UpdateData(Convert.ToInt32(_funcIndex), nameof(aCoef), value);
                UpdateFuncCol();
                errorLabel = null;
            }
        }

        /// <summary>
        /// Связанное поле для обновления значения коэффициента B в Model
        /// и отображения во View
        /// </summary>
        public string bCoef
        {
            get { return _bCoef; }
            set
            {
                if (!model.ValidateData(value))
                {
                    errorLabel = "Input float type value!";
                    return;
                }
                _bCoef = value;
                model.UpdateData(Convert.ToInt32(_funcIndex), nameof(bCoef), value);
                UpdateFuncCol();
                errorLabel = null;
            }
        }

        /// <summary>
        /// Связанное поле для обновления выбранного значения коэффициента C
        /// в Model и отображения во View
        /// </summary>
        public string curCCoef
        {
            get { return _curCCoef; }
            set
            {
                _curCCoef = value;
                model.UpdateData(Convert.ToInt32(_funcIndex), nameof(curCCoef), value);
                UpdateFuncCol();
            }
        }

        /// <summary>
        /// Связанное поле для обновления колонки f(x,y) во View
        /// </summary>
        public ObservableCollection<TextBox> funcColumn
        {
            get { return _funcColumn; }
            set
            {
                model.CalculateFuncColumn(Convert.ToInt32(_funcIndex));
                _funcColumn = new ObservableCollection<TextBox>(model.GetColumn(Convert.ToInt32(_funcIndex), 0));
            }
        }

        /// <summary>
        /// Связанное поле для обновления колонки значений коэффициента X во View
        /// </summary>
        public ObservableCollection<TextBox> xColumn
        {
            get { return _xColumn; }
            set
            {
                _xColumn = new ObservableCollection<TextBox>(model.GetColumn(Convert.ToInt32(_funcIndex), 1));
            }
        }

        /// <summary>
        /// Связанное поле для обновления колонки значений коэффициента Y во View
        /// </summary>
        public ObservableCollection<TextBox> yColumn
        {
            get { return _yColumn; }
            set
            {
                _yColumn = new ObservableCollection<TextBox>(model.GetColumn(Convert.ToInt32(_funcIndex), 2));
            }
        }

        /// <summary>
        /// Связанное поле для отображения коэффициентов C выбранной функции во View
        /// </summary>
        public ObservableCollection<string> cOdds
        {
            get { return _cOdds; }
            set
            {
                _cOdds = new ObservableCollection<string>(model.GetItemList(Convert.ToInt32(_funcIndex)));
            }
        }

        /// <summary>
        /// Связанное поле для хранения текущего значения коэффициента X во ViewModel
        /// и отображения во View
        /// </summary>
        public string xCoef
        {
            get { return _xCoef; }
            set
            {
                if (value == null || !Validation(value.Split(":")[1])) return;

                _xCoef = value.Split(":")[1];
                model.UpdateData(Convert.ToInt32(_funcIndex), nameof(xCoef), _xCoef, Convert.ToInt32(_xIndex));
                UpdateFuncCol();
            }
        }

        /// <summary>
        /// Связанное поле для хранения текущего значения коэффициента Y во ViewModel
        /// и отображения во View
        /// </summary>
        public string yCoef
        {
            get { return _yCoef; }
            set
            {
                if (value == null || !Validation(value.Split(":")[1])) return;

                _yCoef = value.Split(":")[1];
                model.UpdateData(Convert.ToInt32(_funcIndex), nameof(yCoef), _yCoef, Convert.ToInt32(_yIndex));
                UpdateFuncCol();
            }
        }

        /// <summary>
        /// Связанное поле для хранения индекса выбранной функции во ViewModel
        /// </summary>
        public string funcIndex
        {
            get { return _funcIndex; }
            set
            {
                _funcIndex = value;

                _cOdds = new ObservableCollection<string>(model.GetItemList(Convert.ToInt32(_funcIndex)));
                RaisePropertyChanged("COdds");

                string[] odds = model.UpdataOddFields(Convert.ToInt32(_funcIndex));

                _aCoef = odds[0];
                RaisePropertyChanged(nameof(aCoef));

                _bCoef = odds[1];
                RaisePropertyChanged(nameof(bCoef));

                _curCCoef = odds[2];
                RaisePropertyChanged(nameof(curCCoef));

                model.CalculateFuncColumn(Convert.ToInt32(_funcIndex));
                ObservableCollection<TextBox>[] newTable = model.GetTable(Convert.ToInt32(_funcIndex));

                funcColumn = newTable[0];
                RaisePropertiesChanged(nameof(funcColumn));

                xColumn = newTable[1];
                RaisePropertiesChanged(nameof(xColumn));

                yColumn = newTable[2];
                RaisePropertiesChanged(nameof(yColumn));
            }
        }

        /// <summary>
        /// Связанное поле для хранения индекса выбранной ячейки колонки
        /// коэффициентов X во ViewModel
        /// </summary>
        public string xIndex
        {
            get { return _xIndex; }
            set { _xIndex = value; }
        }

        /// <summary>
        /// Связанное поле для хранения индекса выбранной ячейки колонки
        /// коэффициентов Y во ViewModel
        /// </summary>
        public string yIndex
        {
            get { return _yIndex; }
            set { _yIndex = value; }
        }

        /// <summary>
        /// Связанное поле для отображения сообщения об ошибке во View
        /// </summary>
        public string errorLabel
        {
            get { return _errorLabel; }
            set { _errorLabel = value; RaisePropertiesChanged(); }
        }

        /// <summary>
        /// Конструктор класса MainViewModel, в котором происходит 
        /// инициализация полей model и thereIsError
        /// </summary>
        public MainViewModel()
        {
            model = new MainModel();
            thereIsError = false;
        }
        
        /// <summary>
        /// Функция для обновления значений в колонке f(x,y) во View
        /// </summary>
        private void UpdateFuncCol()
        {
            if (thereIsError) return;

            model.CalculateFuncColumn(Convert.ToInt32(_funcIndex));
            funcColumn = model.GetColumn(Convert.ToInt32(_funcIndex), 0);
            RaisePropertiesChanged(nameof(funcColumn));
        }

        /// <summary>
        /// Функция для валидации полученных из пользовательского ввода
        /// данных, генерирования сообщения об ошибке и состояния ошибки
        /// <param name="value"> Проверяемое строковое значение </param>
        /// <returns> Булево значение корректности данных </returns>
        /// </summary>
        private bool Validation(string value)
        {
            if (!model.ValidateData(value))
            {
                thereIsError = true;
                errorLabel = "Input float type value!";
                return false;
            }
            thereIsError = false;
            errorLabel = null;
            return true;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку добавления строки,
        /// реализация добавления строки в данных Model, отображение во View
        /// </summary>
        public ICommand AddRow
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    model.CalculateFuncColumn(Convert.ToInt32(_funcIndex));
                    ObservableCollection<TextBox>[] newTable = model.GetTable(Convert.ToInt32(_funcIndex), true);

                    funcColumn = newTable[0];
                    RaisePropertiesChanged(nameof(funcColumn));

                    xColumn = newTable[1];
                    RaisePropertiesChanged(nameof(xColumn));

                    yColumn = newTable[2];
                    RaisePropertiesChanged(nameof(yColumn));
                });
            }
        }
    }
}
