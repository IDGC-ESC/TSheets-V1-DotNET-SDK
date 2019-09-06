﻿// *******************************************************************************
// <copyright file="FilterAppliesToTests.cs" company="Intuit">
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
    public class FilterAppliesToTests
    {
        [TestMethod, TestCategory("Unit")]
        public void FilterAppliesTo_StringValuesAreCorrect()
        {
            const int expectedCount = 3;
            int actualCount = Enum.GetNames(typeof(FilterAppliesTo)).Length;
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} enum values.");

            Assert.AreEqual("jobcodes", FilterAppliesTo.Jobcodes.StringValue());
            Assert.AreEqual("users", FilterAppliesTo.Users.StringValue());
            Assert.AreEqual("groups", FilterAppliesTo.Groups.StringValue());
        }
    }
}