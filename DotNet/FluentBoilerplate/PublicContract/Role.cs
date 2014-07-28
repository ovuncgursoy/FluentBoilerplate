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

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBoilerplate
{
    public class Role:IRole
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public IImmutableSet<IRight> Rights { get; private set; }

        public Role(int id, string description, IImmutableSet<IRight> rights)
        {
            this.Id = id;
            this.Description = description;
            this.Rights = rights;
        }
    }
}