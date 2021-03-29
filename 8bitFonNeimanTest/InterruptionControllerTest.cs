using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _8bitVonNeiman.InterruptionController;

namespace _8bitFonNeimanTest {
    [TestClass]
    [Ignore]
    public class InterruptionControllerTest {
        [TestMethod]
        public void TestHasNoInterruptionByDefault() {
            InterruptionController controller = new InterruptionController();
            Assert.IsFalse(controller.HasInterruptionRequests());
        }
        [TestMethod]
        public void TestHasInterruptionAfterMakeInterruption() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            controller.MakeInterruption(irq);
            Assert.IsTrue(controller.HasInterruptionRequests());
        }
        [TestMethod]
        public void TestAcknolegdeInterruptionAfterMakeInterruption() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            controller.MakeInterruption(irq);
            Assert.AreEqual(irq, controller.AcknowledgeInterruption());
        }
        [TestMethod]
        public void TestAcknoledgeInterruptionWhenNoRequests() {
            InterruptionController controller = new InterruptionController();
            byte noAckIrq = 255;
            Assert.AreEqual(noAckIrq, controller.AcknowledgeInterruption());
        }
        [TestMethod]
        public void TestHasNoInterruptionAfterAcknowledgeWhenSingle() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            controller.MakeInterruption(irq);
            controller.AcknowledgeInterruption();
            Assert.IsFalse(controller.HasInterruptionRequests());
        }
        [TestMethod]
        public void TestHasInterruptionAfterAcknowledgeWhenMultiple() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            byte irq2 = 4;
            controller.MakeInterruption(irq);
            controller.MakeInterruption(irq2);
            controller.AcknowledgeInterruption();
            Assert.IsTrue(controller.HasInterruptionRequests());
        }
        [TestMethod]
        public void TestClearInterruptionsClearOnlyCurrent() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            controller.MakeInterruption(irq);
            controller.ClearInterruptions();
            Assert.IsTrue(controller.HasInterruptionRequests());
        }
        [TestMethod]
        public void TestHasNoInterruptionAfterClear() {
            InterruptionController controller = new InterruptionController();
            byte irq = 3;
            controller.MakeInterruption(irq);
            controller.Clear();
            Assert.IsFalse(controller.HasInterruptionRequests());
        }
    }
}
