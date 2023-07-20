﻿// *******************************************************************************
// <copyright file="EndpointsTests.cs" company="Intuit">
// Copyright (c) 2019 Intuit
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
// *******************************************************************************

namespace Intuit.TSheets.Tests.Unit.Model.Enums
{
    using System;
    using Intuit.TSheets.Model.Enums;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EndpointsTests
    {
        [TestMethod, TestCategory("Unit")]
        public void Endpoints_StringValuesAreCorrect()
        {
            const int expectedCount = 15;
            int actualCount = Enum.GetNames(typeof(Endpoints)).Length;
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} enum values.");

            Assert.AreEqual("current_user", Endpoints.CurrentUser.StringValue());
            Assert.AreEqual("customfields", Endpoints.CustomFields.StringValue());
            Assert.AreEqual("customfielditems", Endpoints.CustomFieldItems.StringValue());
            Assert.AreEqual("effective_settings", Endpoints.EffectiveSettings.StringValue());
            Assert.AreEqual("geolocations", Endpoints.Geolocations.StringValue());
            Assert.AreEqual("jobcodes", Endpoints.Jobcodes.StringValue());
            Assert.AreEqual("jobcode_assignments", Endpoints.JobcodeAssignments.StringValue());
            Assert.AreEqual("timesheets", Endpoints.Timesheets.StringValue());
            Assert.AreEqual("timesheets_deleted", Endpoints.TimesheetsDeleted.StringValue());
            Assert.AreEqual("users", Endpoints.Users.StringValue());
            Assert.AreEqual("reminders", Endpoints.Reminders.StringValue());
            Assert.AreEqual("locations", Endpoints.Locations.StringValue());
            Assert.AreEqual("geofence_configs", Endpoints.GeofenceConfigs.StringValue());
            Assert.AreEqual("time_off_requests", Endpoints.TimeOffRequests.StringValue());
            Assert.AreEqual("time_off_request_entries", Endpoints.TimeOffRequestEntries.StringValue());
        }
    }
}