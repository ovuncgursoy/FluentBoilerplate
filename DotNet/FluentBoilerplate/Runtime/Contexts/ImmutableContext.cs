﻿/*
   Copyright 2015 Chris Hannon

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

using FluentBoilerplate.Contexts;
using FluentBoilerplate.Messages;
using FluentBoilerplate.Messages.Developer;
using FluentBoilerplate.Providers;
using FluentBoilerplate.Runtime.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate.Runtime.Contexts
{
#if DEBUG
    public
#else
    internal 
#endif
        abstract class ImmutableContext 
    {
        protected readonly IContextBundle bundle;

        internal ImmutableContext(IContextBundle bundle)
        {
            this.bundle = bundle;
        }

        protected IContextBundle DowngradeErrorHandling()
        {
            var downgradedErrorContext = this.bundle.Errors.Copy(includeHandlers: false);
            return this.bundle.Copy(errorContext: downgradedErrorContext);
        }

        protected void Error(string message, Exception thrownException, params object[] loggedInstances)
        {
            this.bundle.Log.Error(message, thrownException, loggedInstances);
        }

        protected void Warning(string message, params object[] loggedInstances)
        {
            this.bundle.Log.Warning(message, loggedInstances);
        }

        protected void Info(string message, params object[] loggedInstances)
        {
            this.bundle.Log.Info(message, loggedInstances);
        }

        protected void Debug(string message, params object[] loggedInstances)
        {
            this.bundle.Log.Debug(message, loggedInstances);
        }
    }
}
