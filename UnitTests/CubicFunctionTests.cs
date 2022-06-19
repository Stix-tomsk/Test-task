using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    /// <summary>
    /// Набор Unit-тестов кубической функции
    /// </summary>
    public class CubicFunctionTests
    {
        private MainModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new MainModel();
        }

        [Test]
        public void CubicFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.funcData[2].aCoef = 9.1f;
            _model.funcData[2].bCoef = 4.4f;
            _model.funcData[2].curCCoef = 3;
            Assert.AreEqual(921.76556f, _model.CalculateFunc(2, 3.6f, 4.7f));
        }

        [Test]
        public void CubicFunc_InputBigData_CorrectFuncValue()
        {
            _model.funcData[2].aCoef = 871239.712f;
            _model.funcData[2].bCoef = 345907.136f;
            _model.funcData[2].curCCoef = 1;
            Assert.AreEqual(1.0835387E+19f, _model.CalculateFunc(2, 23167.48f, 71234.23f));
        }

        [Test]
        public void CubicFunc_ThereIsNoaCoefData_CorrectFuncValue()
        {
            _model.funcData[2].bCoef = 5f;
            Assert.AreEqual(120f, _model.CalculateFunc(2, 2f, 2f));
        }

        [Test]
        public void CubicFunc_ThereIsNobCoefData_CorrectFuncValue()
        {
            _model.funcData[2].aCoef = 4f;
            Assert.AreEqual(132f, _model.CalculateFunc(2, 2f, 2f));
        }

        [Test]
        public void CubicFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.funcData[2].aCoef = 3f;
            _model.funcData[2].bCoef = 6f;
            Assert.AreEqual(250f, _model.CalculateFunc(2, 0, 5f));
        }

        [Test]
        public void CubicFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.funcData[2].aCoef = 3f;
            _model.funcData[2].bCoef = 6f;
            Assert.AreEqual(475f, _model.CalculateFunc(2, 5f, 0));
        }
        [Test]
        public void CubicFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(100f, _model.CalculateFunc(2, 0, 0));
        }
    }

}
