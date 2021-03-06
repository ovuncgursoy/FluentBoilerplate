﻿/*
   Copyright 2014 Chris Hannon

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 */

using FluentBoilerplate.Providers;
using FluentBoilerplate.Runtime;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate.Tests
{
    internal static class MockILogExtensions
    {
        public static Mock<ILogProvider> AllowEveryError(this Mock<ILogProvider> mock)
        {
            mock.Setup(x => x.Error(It.IsAny<string>(), It.IsAny<Exception>()));
            return mock;
        }

        public static Mock<ILogProvider> AllowErrorsWithMessage(this Mock<ILogProvider> mock, string message)
        {
            mock.Setup(x => x.Error(It.Is<string>(p => p == message), It.IsAny<Exception>()));
            return mock;
        }
    }
}
