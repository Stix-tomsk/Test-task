using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    /// <summary>
    /// Набор Unit-тестов линейной функции
    /// </summary>
    public class LinearFunctionTests
    {
        private MainModel _model;
        
        [SetUp]
        public void Setup()
        {
            _model = new MainModel();
        }

        [Test]
        public void LinearFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.funcData[0].aCoef = 15.2f;
            _model.funcData[0].bCoef = 29.7f;
            _model.funcData[0].curCCoef = 3;
            Assert.AreEqual(94.5f, _model.CalculateFunc(0, 4f, 12f));
        }

        [Test]
        public void LinearFunc_InputBigData_CorrectFuncValue()
        {
            _model.funcData[0].aCoef = 791247.421f;
            _model.funcData[0].bCoef = 923359.321f;
            _model.funcData[0].curCCoef = 1;
            Assert.AreEqual(5.4694486E+10f, _model.CalculateFunc(0, 69123.21f, 98312.32f));
        }

        [Test]
        public void LinearFunc_ThereIsNoaCoefData_CorrectFuncValue()
        {
            _model.funcData[0].bCoef = 25f;
            Assert.AreEqual(26f, _model.CalculateFunc(0, 10f, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNobCoefData_CorrectFuncValue()
        {
            _model.funcData[0].aCoef = 25f;
            Assert.AreEqual(251f, _model.CalculateFunc(0, 10f, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.funcData[0].aCoef = 7f;
            _model.funcData[0].bCoef = 8f;
            Assert.AreEqual(9f, _model.CalculateFunc(0, 0, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.funcData[0].aCoef = 7f;
            _model.funcData[0].bCoef = 8f;
            Assert.AreEqual(44f, _model.CalculateFunc(0, 5f, 0));
        }
        [Test]
        public void LinearFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1f, _model.CalculateFunc(0, 0, 0));
        }
    }
    
}