using NUnit.Framework;
using Test_task;

namespace UnitTests
{
    public class LinearFunctionTests
    {
        private Model _model;
        
        [SetUp]
        public void Setup()
        {
            _model = new Model();
        }

        [Test]
        public void LinearFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.FuncData[0].ACoef = 15.2f;
            _model.FuncData[0].BCoef = 29.7f;
            _model.FuncData[0].CurCCoef = 3;
            Assert.AreEqual(94.5f, _model.CalculateFunc(0, 4f, 12f));
        }

        [Test]
        public void LinearFunc_InputBigData_CorrectFuncValue()
        {
            _model.FuncData[0].ACoef = 791247.421f;
            _model.FuncData[0].BCoef = 923359.321f;
            _model.FuncData[0].CurCCoef = 1;
            Assert.AreEqual(5.4694486E+10f, _model.CalculateFunc(0, 69123.21f, 98312.32f));
        }

        [Test]
        public void LinearFunc_ThereIsNoACoefData_CorrectFuncValue()
        {
            _model.FuncData[0].BCoef = 25f;
            Assert.AreEqual(26f, _model.CalculateFunc(0, 10f, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNoBCoefData_CorrectFuncValue()
        {
            _model.FuncData[0].ACoef = 25f;
            Assert.AreEqual(251f, _model.CalculateFunc(0, 10f, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.FuncData[0].ACoef = 7f;
            _model.FuncData[0].BCoef = 8f;
            Assert.AreEqual(9f, _model.CalculateFunc(0, 0, 5f));
        }

        [Test]
        public void LinearFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.FuncData[0].ACoef = 7f;
            _model.FuncData[0].BCoef = 8f;
            Assert.AreEqual(44f, _model.CalculateFunc(0, 5f, 0));
        }
        [Test]
        public void LinearFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1f, _model.CalculateFunc(0, 0, 0));
        }
    }

    public class QuadraticFunctionTests
    {
        private Model _model;

        [SetUp]
        public void Setup()
        {
            _model = new Model();
        }

        [Test]
        public void QuadraticFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.FuncData[1].ACoef = 7.5f;
            _model.FuncData[1].BCoef = 5.1f;
            _model.FuncData[1].CurCCoef = 3;
            Assert.AreEqual(92.11f, _model.CalculateFunc(1, 2.2f, 3.1f));
        }

        [Test]
        public void QuadraticFunc_InputBigData_CorrectFuncValue()
        {
            _model.FuncData[1].ACoef = 612036.207f;
            _model.FuncData[1].BCoef = 179419.372f;
            _model.FuncData[1].CurCCoef = 1;
            Assert.AreEqual(6.0000704E+15f, _model.CalculateFunc(1, 99012.39f, 12387.52f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoACoefData_CorrectFuncValue()
        {
            _model.FuncData[1].BCoef = 3f;
            Assert.AreEqual(25f, _model.CalculateFunc(1, 4f, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoBCoefData_CorrectFuncValue()
        {
            _model.FuncData[1].ACoef = 6f;
            Assert.AreEqual(106f, _model.CalculateFunc(1, 4f, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.FuncData[1].ACoef = 5f;
            _model.FuncData[1].BCoef = 2f;
            Assert.AreEqual(20f, _model.CalculateFunc(1, 0, 5f));
        }

        [Test]
        public void QuadraticFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.FuncData[1].ACoef = 5f;
            _model.FuncData[1].BCoef = 2f;
            Assert.AreEqual(135f, _model.CalculateFunc(1, 5f, 0));
        }
        [Test]
        public void QuadraticFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(10f, _model.CalculateFunc(1, 0, 0));
        }
    }

    public class CubicFunctionTests
    {
        private Model _model;

        [SetUp]
        public void Setup()
        {
            _model = new Model();
        }

        [Test]
        public void CubicFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.FuncData[2].ACoef = 9.1f;
            _model.FuncData[2].BCoef = 4.4f;
            _model.FuncData[2].CurCCoef = 3;
            Assert.AreEqual(921.76556f, _model.CalculateFunc(2, 3.6f, 4.7f));
        }

        [Test]
        public void CubicFunc_InputBigData_CorrectFuncValue()
        {
            _model.FuncData[2].ACoef = 871239.712f;
            _model.FuncData[2].BCoef = 345907.136f;
            _model.FuncData[2].CurCCoef = 1;
            Assert.AreEqual(1.0835387E+19f, _model.CalculateFunc(2, 23167.48f, 71234.23f));
        }

        [Test]
        public void CubicFunc_ThereIsNoACoefData_CorrectFuncValue()
        {
            _model.FuncData[2].BCoef = 5f;
            Assert.AreEqual(120f, _model.CalculateFunc(2, 2f, 2f));
        }

        [Test]
        public void CubicFunc_ThereIsNoBCoefData_CorrectFuncValue()
        {
            _model.FuncData[2].ACoef = 4f;
            Assert.AreEqual(132f, _model.CalculateFunc(2, 2f, 2f));
        }

        [Test]
        public void CubicFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.FuncData[2].ACoef = 3f;
            _model.FuncData[2].BCoef = 6f;
            Assert.AreEqual(250f, _model.CalculateFunc(2, 0, 5f));
        }

        [Test]
        public void CubicFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.FuncData[2].ACoef = 3f;
            _model.FuncData[2].BCoef = 6f;
            Assert.AreEqual(475f, _model.CalculateFunc(2, 5f, 0));
        }
        [Test]
        public void CubicFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(100f, _model.CalculateFunc(2, 0, 0));
        }
    }

    public class FourthDegreeFunctionTests
    {
        private Model _model;

        [SetUp]
        public void Setup()
        {
            _model = new Model();
        }

        [Test]
        public void FourthDegFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.FuncData[3].ACoef = 6.4f;
            _model.FuncData[3].BCoef = 3.1f;
            _model.FuncData[3].CurCCoef = 3;
            Assert.AreEqual(4222.7993f, _model.CalculateFunc(3, 2.4f, 1.5f));
        }

        [Test]
        public void FourthDegFunc_InputBigData_CorrectFuncValue()
        {
            _model.FuncData[3].ACoef = 3146314.26f;
            _model.FuncData[3].BCoef = 145151.515f;
            _model.FuncData[3].CurCCoef = 1;
            Assert.AreEqual(3.0763373E+24f, _model.CalculateFunc(3, 31445.43f, 43717.72f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoACoefData_CorrectFuncValue()
        {
            _model.FuncData[3].BCoef = 2f;
            Assert.AreEqual(1016f, _model.CalculateFunc(3, 4f, 2f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoBCoefData_CorrectFuncValue()
        {
            _model.FuncData[3].ACoef = 3f;
            Assert.AreEqual(1768f, _model.CalculateFunc(3, 4f, 2f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.FuncData[3].ACoef = 5f;
            _model.FuncData[3].BCoef = 5f;
            Assert.AreEqual(1320f, _model.CalculateFunc(3, 0, 4f));
        }

        [Test]
        public void FourthDegFuncFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.FuncData[3].ACoef = 5f;
            _model.FuncData[3].BCoef = 5f;
            Assert.AreEqual(2280f, _model.CalculateFunc(3, 4f, 0));
        }
        [Test]
        public void FourthDegFuncFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1000f, _model.CalculateFunc(3, 0, 0));
        }
    }

    public class FifthDegreeFunctionTests
    {
        private Model _model;

        [SetUp]
        public void Setup()
        {
            _model = new Model();
        }

        [Test]
        public void FifrthDegFunc_InputSimpleData_CorrectFuncValue()
        {
            _model.FuncData[4].ACoef = 7.2f;
            _model.FuncData[4].BCoef = 1.01f;
            _model.FuncData[4].CurCCoef = 4;
            Assert.AreEqual(85260.25f, _model.CalculateFunc(4, 5.2f, 9.4f));
        }

        [Test]
        public void FifrthDegFunc_InputBigData_CorrectFuncValue()
        {
            _model.FuncData[4].ACoef = 247963.912f;
            _model.FuncData[4].BCoef = 167427.573f;
            _model.FuncData[4].CurCCoef = 1;
            Assert.AreEqual(1.218621E+26f, _model.CalculateFunc(4, 13747.65f, 27427.34f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoACoefData_CorrectFuncValue()
        {
            _model.FuncData[4].BCoef = 4.2f;
            Assert.AreEqual(10004.2f, _model.CalculateFunc(4, 3f, 1f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoBCoefData_CorrectFuncValue()
        {
            _model.FuncData[4].ACoef = 15f;
            Assert.AreEqual(13645f, _model.CalculateFunc(4, 3f, 1f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoXCoefData_CorrectFuncValue()
        {
            _model.FuncData[4].ACoef = 9f;
            _model.FuncData[4].BCoef = 9f;
            Assert.AreEqual(15625f, _model.CalculateFunc(4, 0, 5f));
        }

        [Test]
        public void FifrthDegFunc_ThereIsNoYCoefData_CorrectFuncValue()
        {
            _model.FuncData[4].ACoef = 9f;
            _model.FuncData[4].BCoef = 9f;
            Assert.AreEqual(38125f, _model.CalculateFunc(4, 5f, 0));
        }
        [Test]
        public void FifrthDegFunc_ThereAreNoData_CorrectFuncValue()
        {
            Assert.AreEqual(1000f, _model.CalculateFunc(3, 0, 0));
        }
    }
}
