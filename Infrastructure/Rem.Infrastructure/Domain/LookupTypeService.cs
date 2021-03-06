#region License
// Open Behavioral Health Information Technology Architecture (OBHITA.org)
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the <organization> nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Pillar.Common.Bootstrapper;
using Rem.Domain.Core.CommonModule;

namespace Rem.Infrastructure.Domain
{
    /// <summary>
    /// This class is an implementation of <see cref="ILookupTypeService"/>.
    /// </summary>
    public class LookupTypeService : ILookupTypeService
    {
        private readonly IAssemblyLocator _assemblyLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupTypeService"/> class.
        /// </summary>
        /// <param name="assemblyLocator">The assembly locator.</param>
        public LookupTypeService(IAssemblyLocator assemblyLocator)
        {
            _assemblyLocator = assemblyLocator;
        }

        /// <summary>
        /// Gets the type of the lookup.
        /// </summary>
        /// <param name="lookupName">Name of the lookup.</param>
        /// <returns>A Type.</returns>
        public Type GetLookupType ( string lookupName )
        {
            var types = new List<Type>();

            foreach (var assembly in _assemblyLocator.LocateDomainAssemblies())
            {
                types.AddRange(assembly.GetTypes());
            }

            var query = from type in types
                        where ( type.Name == lookupName && type.IsSubclassOf ( typeof( LookupBase ) ) )
                        select type;
            var lookupType = query.SingleOrDefault ();
            if ( lookupType == null )
            {
                throw new ArgumentException ( string.Format ( "Unknown Lookup: {0}", lookupName ) );
            }
            return lookupType;
        }
    }
}