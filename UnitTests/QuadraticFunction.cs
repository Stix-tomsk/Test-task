using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    /// <summary>
    /// Набор Unit-тестов квадратичной функции
    /// </summary>
    public class QuadraticFunctionTests
    {
        private MainModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new MainModel();
        }

        [Test]
        public void QuadraticFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.funcData[1].aCoef = 7.5f;
            _model.funcData[1].bCoef = 5.1f;
            _model.funcData[1].curCCoef = 3;
            Assert.AreEqual(92.11f, _model.CalculateFunc(1, 2.2f, 3.1f));
        }

        [Test]
        public void QuadraticFunc_InputBigData_CorrectFuncValue()
        {
            _model.funcData[1].aCoef = 612036.207f;
            _model.funcData[1].bCoef = 179419.372f;
            _model.funcData[1].curCCoef = 1;
            Assert.AreEqual(6.0000704E+15f, _model.CalculateFunc(1, 99012.39f, 12387.52f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoaCoefData_CorrectFuncValue()
        {
            _model.funcData[1].bCoef = 3f;
            Assert.AreEqual(25f, _model.CalculateFunc(1, 4f, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNobCoefData_CorrectFuncValue()
        {
            _model.funcData[1].aCoef = 6f;
            Assert.AreEqual(106f, _model.CalculateFunc(1, 4f, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.funcData[1].aCoef = 5f;
            _model.funcData[1].bCoef = 2f;
            Assert.AreEqual(20f, _model.CalculateFunc(1, 0, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.funcData[1].aCoef = 5f;
            _model.funcData[1].bCoef = 2f;
            Assert.AreEqual(135f, _model.CalculateFunc(1, 5f, 0));
        }
        [Test]
        public void QuadraticFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(10f, _model.CalculateFunc(1, 0, 0));
        }
    }

}
