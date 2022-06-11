using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Test_task
{
    class ViewModel : ViewModelBase
    {
        /// <summary>
        /// Field for containing a function id 
        /// </summary>
        private int CurrentFunc { get; set; }

        /// <summary>
        /// Six fields for containing function odd values
        /// </summary>
        private ObservableCollection<string> _COdds;
        private string _CurCCoef;
        private string _BCoef;
        private string _ACoef;
        private string _XCoef;
        private string _YCoef;

        /// <summary>
        /// Field for containing a result of calculated function
        /// </summary>
        private string _FuncResult;

        /// <summary>
        /// Field for containing a content of boofer between View and ViewModel
        /// Due to it, was made a separation between visual actions for View
        /// and functional actions for Model
        /// </summary>
        private string _Buffer;

        /// <summary>
        /// Field for containing an error message content
        /// </summary>
        private string _ErrorLabel;

        /// <summary>
        /// Field for communication between ViewModel and Model
        /// </summary>
        public Model model = new Model();

        /// <summary>
        /// Binded field for updating an A coefficient value in Model
        /// and displaying it in View
        /// </summary>
        public string ACoef { 
            get { return _ACoef; }
            set 
            { 
                if (!model.ValidateData(value))
                {
                    ErrorLabel = ErrorLabel = "Input float type value!";
                    return;
                }
                _ACoef = value;
                model.UpdateData(CurrentFunc, "Acoef", value);
                ErrorLabel = "";
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binded field for updating an B coefficient value in Model
        /// and displaying it in View
        /// </summary>
        public string BCoef
        {
            get { return _BCoef; }
            set 
            { 
                if (!model.ValidateData(value))
                {
                    ErrorLabel = ErrorLabel = "Input float type value!";
                    return;
                }
                _BCoef = value;
                model.UpdateData(CurrentFunc, "Bcoef", value);
                ErrorLabel = "";
                RaisePropertyChanged(); 
            }
        }

        /// <summary>
        /// Binded field for updating a choosed C coefficient value in Model
        /// and displaying it in View
        /// </summary>
        public string CurCCoef
        {
            get { return _CurCCoef; }
            set 
            { 
                _CurCCoef = value;
                model.UpdateData(CurrentFunc, "Ccoef", value);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binded field for displaying C odds of choosed function in View
        /// </summary>
        public ObservableCollection<string> COdds
        {
            get { return _COdds; }
            set 
            { 
                _COdds = new ObservableCollection<string>(model.GetItemList(CurrentFunc));
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binded field for containing an X coefficient value in ViewModel
        /// and displaying it in View
        /// </summary>
        public string XCoef
        {
            get { return _XCoef; }
            set { _XCoef = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Binded field for containing an Y coefficient value in ViewModel
        /// and displaying it in View
        /// </summary>
        public string YCoef
        {
            get { return _YCoef; }
            set { _YCoef = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Binded field for calculating a choosed function result in Model
        /// and displaying it in View
        /// </summary>
        public string FuncResult
        {
            get { return _FuncResult; }
            set 
            { 
                _FuncResult = value;
                try
                {
                    model.CalculateFunc(CurrentFunc, Convert.ToSingle(XCoef), Convert.ToSingle(YCoef));
                    ErrorLabel = "";
                }
                catch (FormatException e)
                {
                    ErrorLabel = "Input float type value!";
                }
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Binded field for displaying an error message in View
        /// </summary>
        public string ErrorLabel
        {
            get { return _ErrorLabel; }
            set { _ErrorLabel = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Binded field for updating choosed function id in ViewModel
        /// and odds values in View
        /// </summary>
        public string Buffer
        {
            get { return _Buffer; }
            set {
                _Buffer = value;
                RaisePropertyChanged();
                CurrentFunc = model.IdentFuncId(value);
                _COdds = new ObservableCollection<string>(model.GetItemList(CurrentFunc));
                RaisePropertyChanged("COdds");
                
                string[] odds = model.UpdataOddFields(CurrentFunc);
                
                _ACoef = odds[0];
                RaisePropertyChanged("ACoef");
                
                _BCoef = odds[1];
                RaisePropertyChanged("BCoef");
                
                _CurCCoef = odds[2];
                RaisePropertyChanged("CurCCoef");
            }
        }

        /// <summary>
        /// Event handler for updating choosed function id in ViewModel
        /// and odds values in View
        /// </summary>
        public ICommand GetChoosedFunc
        {
            get
            {
                return new DelegateCommand<string>(i =>
                {
                    Buffer = i;
                });
            }
        }

        /// <summary>
        /// Event handler for calculating a choosed function result,
        /// store it in ViewModel and displaying in View 
        /// </summary>
        public ICommand GetFunctionResult
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        FuncResult = (model.CalculateFunc(CurrentFunc, Convert.ToSingle(XCoef), Convert.ToSingle(YCoef))).ToString();
                        ErrorLabel = "";
                    }
                    catch (FormatException e)
                    {
                        FuncResult = null;
                        ErrorLabel = "Input float type value!";
                    }
                });
            }
        }
    }
}
