using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.Patterns.State_Machine;

namespace Spike.Patterns.Tests
{
    [TestClass]
    public class StateMachineTests
    {
        [TestMethod]
        public void TestNominalResolvePath()
        {
            var stateMachine = new HelpDesk();

            stateMachine.AcknowledgeTicket();
            stateMachine.ResolveTicket();

           Assert.AreEqual(HelpDeskState.Resolved, stateMachine.GetCurrentState);
        }

        [TestMethod]
        public void TestNominalClosePath()
        {
            var stateMachine = new HelpDesk();

            stateMachine.AcknowledgeTicket();
            stateMachine.CloseTicket();

            Assert.AreEqual(HelpDeskState.Closed, stateMachine.GetCurrentState);
        }

        [TestMethod]
        public void TestNominalReOpenPath()
        {
            var stateMachine = new HelpDesk();

            stateMachine.AcknowledgeTicket();
            stateMachine.ResolveTicket();
            stateMachine.ReopenTicket();

            Assert.AreEqual(HelpDeskState.ReOpened, stateMachine.GetCurrentState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFailInvalidTransition()
        {
            var stateMachine = new HelpDesk();
            stateMachine.ResolveTicket();

            Assert.AreEqual(HelpDeskState.Resolved, stateMachine.GetCurrentState);
        }
    }
}
