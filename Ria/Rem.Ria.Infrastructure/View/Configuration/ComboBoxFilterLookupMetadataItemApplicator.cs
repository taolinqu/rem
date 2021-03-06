﻿#region License

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
using Pillar.Common.Metadata.Dtos;
using Rem.Ria.Infrastructure.Common.Extension;
using Rem.Ria.Infrastructure.View.Behavior;
using Telerik.Windows.Controls;

namespace Rem.Ria.Infrastructure.View.Configuration
{
    /// <summary>
    /// Class for applicating combo box filter lookup metadata item.
    /// </summary>
    public class ComboBoxFilterLookupMetadataItemApplicator :
        MetadataItemApplicatorBase<RadComboBox, FilterLookupMetadataItemDto>
    {
        #region Methods

        /// <summary>
        /// Applies the specified combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="metadataItem">The metadata item.</param>
        /// <param name="localStorage">The local storage.</param>
        protected override void Apply ( RadComboBox comboBox, FilterLookupMetadataItemDto metadataItem, IDictionary<Type, object> localStorage )
        {
            var multiBindingsBehavior = comboBox.GetBehaviors<MultiBindingsBehavior> ().FirstOrDefault ();
            if ( multiBindingsBehavior != null )
            {
                var multiBinding = multiBindingsBehavior.MultiBindings[0];
                if ( !localStorage.ContainsKey ( MetadataItemType ) )
                {
                    localStorage.Add ( MetadataItemType, multiBinding.ConverterParameter );
                }
                multiBinding.ConverterParameter = metadataItem.WellKnownNames;
            }
        }

        /// <summary>
        /// Unapplies the specified combo box.
        /// </summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="metadataItem">The metadata item.</param>
        /// <param name="localStorage">The local storage.</param>
        protected override void Unapply ( RadComboBox comboBox, FilterLookupMetadataItemDto metadataItem, IDictionary<Type, object> localStorage )
        {
            var multiBindingsBehavior = comboBox.GetBehaviors<MultiBindingsBehavior> ().FirstOrDefault ();
            if ( multiBindingsBehavior != null )
            {
                var multiBinding = multiBindingsBehavior.MultiBindings[0];
                IEnumerable<string> storedValue = null;
                if ( localStorage.ContainsKey ( MetadataItemType ) )
                {
                    storedValue = ( IEnumerable<string> )localStorage[MetadataItemType];
                }

                multiBinding.ConverterParameter = storedValue;
            }
        }

        #endregion
    }
}
