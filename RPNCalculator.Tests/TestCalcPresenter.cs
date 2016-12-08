using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using RPNCalculator.View;
using RPNCalculator.Presenter;

namespace RPNCalculator.Tests
{
    [TestFixture]
    public class TestCalcPresenter
    {
        ////declare
        //Mock<ICalcView> _mockView;
        //CalcPresenter _presenter;

        //[SetUp]
        //public void SetUp()
        //{
        //    _mockView = new Mock<ICalcView>();
        //    _presenter = new CalcPresenter(_mockView.Object);

        //}

        //[Test]
        //public void TestPushOnStackSuccessful()
        //{
        //    _mockView.Setup(m => m.SetTextCurrentNumber(It.Is<String>(s => s == "12")));
        //    //_mockView.Raise(m => m.StackPush += null, this, new EventArgs<String>(It.Is<String>(s => s == "12")));
        //    //_mockView.Raise(m => m.StackPush += null, this, true);
        //    _mockView.Verify(m => m.SetStackValues(It.Is<String[]>(t => t[0] == "12")));
        //}

        //[Test]
        //public void TestAddition()
        //{

        //    _mockView.Raise(mock => mock.Addition += null, new EventArgs());

        //}
    }
}
