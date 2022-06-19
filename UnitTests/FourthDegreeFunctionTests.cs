using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    /// <summary>
    /// Набор Unit-тестов функции 4-ой степени
    /// </summary>
    public class FourthDegreeFunctionTests
    {
        private MainModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new MainModel();
        }

        [Test]
        public void FourthDegFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.funcData[3].aCoef = 6.4f;
            _model.funcData[3].bCoef = 3.1f;
            _model.funcData[3].curCCoef = 3;
            Assert.AreEqual(4222.7993f, _model.CalculateFunc(3, 2.4f, 1.5f));
        }

        [Test]
        public void FourthDegFunc_InputBigData_CorrectFuncValue()
        {
            _model.funcData[3].aCoef = 3146314.26f;
            _model.funcData[3].bCoef = 145151.515f;
            _model.funcData[3].curCCoef = 1;
            Assert.AreEqual(3.0763373E+24f, _model.CalculateFunc(3, 31445.43f, 43717.72f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoaCoefData_CorrectFuncValue()
        {
            _model.funcData[3].bCoef = 2f;
            Assert.AreEqual(1016f, _model.CalculateFunc(3, 4f, 2f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNobCoefData_CorrectFuncValue()
        {
            _model.funcData[3].aCoef = 3f;
            Assert.AreEqual(1768f, _model.CalculateFunc(3, 4f, 2f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.funcData[3].aCoef = 5f;
            _model.funcData[3].bCoef = 5f;
            Assert.AreEqual(1320f, _model.CalculateFunc(3, 0, 4f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.funcData[3].aCoef = 5f;
            _model.funcData[3].bCoef = 5f;
            Assert.AreEqual(2280f, _model.CalculateFunc(3, 4f, 0));
        }
        [Test]
        public void FourthDegFuncFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1000f, _model.CalculateFunc(3, 0, 0));
        }
    }

}
