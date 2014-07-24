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
using FluentBoilerplate.Runtime.Providers;
using FluentBoilerplate.Runtime.Providers.Translation;
using FluentBoilerplate.Runtime.Providers.Validation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate.Runtime.Contexts
{   
    public class ContextBundle
    {
        protected readonly IImmutableErrorContext errorContext;
        protected readonly IConnectionAccessProvider serviceProvider;
        protected readonly IConnectionAccessProvider dataProvider;
        protected readonly ITranslationProvider translationProvider;
        protected readonly IValidationProvider validationProvider;
        protected readonly IPermissionsProvider permissionsProvider;

        public IPermissionsProvider Permissions { get { return this.permissionsProvider; } }
        public IValidationProvider Validation { get { return this.validationProvider; } }
        public IImmutableErrorContext Errors { get { return errorContext; } }
        public IConnectionAccessProvider Services { get { return serviceProvider; } }
        public IConnectionAccessProvider Data { get { return dataProvider; } }
        public ITranslationProvider Translation { get { return translationProvider; } }

        public ContextBundle(IPermissionsProvider permissionsProvider = null, 
                             IImmutableErrorContext errorContext = null, 
                             IConnectionAccessProvider serviceProvider = null, 
                             IConnectionAccessProvider dataProvider = null, 
                             ITranslationProvider translationProvider = null, 
                             IValidationProvider validationProvider = null)
        {
            this.permissionsProvider = permissionsProvider ?? PermissionsProvider.Empty;
            this.errorContext = errorContext ?? ImmutableErrorContext.Empty;
            this.serviceProvider = serviceProvider; //TODO: Create empty service/data providers
            this.dataProvider = dataProvider;
            this.translationProvider = translationProvider ?? TranslationProvider.Empty;
            this.validationProvider = validationProvider ?? ValidationProvider.Empty;
        }

        public ContextBundle Copy(IPermissionsProvider permissionsProvider = null,
                                  IImmutableErrorContext errorContext = null,
                                  IConnectionAccessProvider serviceProvider = null,
                                  IConnectionAccessProvider dataProvider = null,
                                  ITranslationProvider translationProvider = null,
                                  IValidationProvider validationProvider = null)
        {
            return new ContextBundle(permissionsProvider ?? this.permissionsProvider,
                                     errorContext ?? this.errorContext,
                                     serviceProvider ?? this.serviceProvider,
                                     dataProvider ?? this.dataProvider,
                                     translationProvider ?? this.translationProvider,
                                     validationProvider ?? this.validationProvider);
        }
    }
}