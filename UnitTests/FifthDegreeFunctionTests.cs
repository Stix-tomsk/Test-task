using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    /// <summary>
    /// Набор Unit-тестов функции 5-ой степени
    /// </summary>
    public class FifthDegreeFunctionTests
    {
        private MainModel _model;

        [SetUp]
        public void Setup()
        {
            _model = new MainModel();
        }

        [Test]
        public void FifrthDegFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.funcData[4].aCoef = 7.2f;
            _model.funcData[4].bCoef = 1.01f;
            _model.funcData[4].curCCoef = 4;
            Assert.AreEqual(85260.25f, _model.CalculateFunc(4, 5.2f, 9.4f));
        }

        [Test]
        public void FifrthDegFunc_InputBigData_CorrectFuncValue()
        {
            _model.funcData[4].aCoef = 247963.912f;
            _model.funcData[4].bCoef = 167427.573f;
            _model.funcData[4].curCCoef = 1;
            Assert.AreEqual(1.218621E+26f, _model.CalculateFunc(4, 13747.65f, 27427.34f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoaCoefData_CorrectFuncValue()
        {
            _model.funcData[4].bCoef = 4.2f;
            Assert.AreEqual(10004.2f, _model.CalculateFunc(4, 3f, 1f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNobCoefData_CorrectFuncValue()
        {
            _model.funcData[4].aCoef = 15f;
            Assert.AreEqual(13645f, _model.CalculateFunc(4, 3f, 1f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.funcData[4].aCoef = 9f;
            _model.funcData[4].bCoef = 9f;
            Assert.AreEqual(15625f, _model.CalculateFunc(4, 0, 5f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.funcData[4].aCoef = 9f;
            _model.funcData[4].bCoef = 9f;
            Assert.AreEqual(38125f, _model.CalculateFunc(4, 5f, 0));
        }
        [Test]
        public void FifrthDegFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1000f, _model.CalculateFunc(3, 0, 0));
        }
    }
}
