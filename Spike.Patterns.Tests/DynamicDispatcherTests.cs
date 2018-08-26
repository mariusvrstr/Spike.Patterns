using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.Patterns.DynamicDispatcher.Events;
using Spike.Patterns.DynamicDispatcher.Handlers;

namespace Spike.Patterns.Tests
{
    [TestClass]
    public class DynamicDispatcherTests
    {
        public UserEventHandler EventHandler { get; set; } = new UserEventHandler();

        ActivationChangedEvent _activateEvent = new ActivationChangedEvent()
        {
            Active = true,
            Name = "John",
            Surname = "Doe"
        };

        RoleChangedEvent _roleChangeEvent = new RoleChangedEvent()
        {
            Roles = new List<string>() { "Admin", "Capture", "Read" },
            Name = "John",
            Surname = "Doe"
        };

        [TestMethod]
        public void RaiseActivationChangeEvent()
        {
            EventHandler.Handle(_activateEvent);
        }

        [TestMethod]
        public void RaiseRoleChangeEvent()
        {
            EventHandler.Handle(_roleChangeEvent);
        }

        [TestMethod]
        public void RaiseEventFromList()
        {
            var events = new List<dynamic>()
            {
                _activateEvent,
                _roleChangeEvent
            };

            foreach (var @event in events)
            {
               // EventHandler.Handle(events);
            }
        }

    }
}
