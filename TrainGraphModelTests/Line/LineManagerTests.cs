using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainGraphModel.Line;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainGraphModel.Line.Tests
{
    [TestClass()]
    public class LineManagerTests
    {
        [TestMethod()]
        public void InitTest()
        {
            var lineManager = LineManager.Instance;
        }
    }
}