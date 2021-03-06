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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pillar.Common.Commands;
using Pillar.Security.AccessControl;
using Rem.Ria.Infrastructure.Commands;
using Rem.Ria.Infrastructure.DataTransferObject;
using Rem.Ria.Infrastructure.Service;
using Rem.Ria.Infrastructure.ViewModel;
using Rem.Ria.Infrastructure.Web.DataTransferObject;
using TerminologyService.Client.SL;
using TerminologyService.WebService;

namespace Rem.Ria.PatientModule.DtsSearch
{
    /// <summary>
    /// View Model for MedicationDtsSearch class.
    /// </summary>
    public class MedicationDtsSearchViewModel : DTSSearchViewModel
    {
        //private const string NamespaceToUse = "ICD-9-CM-C1"; 

        #region Constants and Fields

        private const string NamespaceToUse = "RXNORMR";
        private readonly string _codeSystemIdentifier = "2.16.840.1.113883.6.88";
        private readonly string _codeSystemName = "RxNorm";

        #endregion

        //private const string SubsetName = "RxNorm Ingredients and Branded Names";

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicationDtsSearchViewModel"/> class.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="userDialogService">The user dialog service.</param>
        /// <param name="accessControlManager">The access control manager.</param>
        /// <param name="commandFactory">The command factory.</param>
        public MedicationDtsSearchViewModel (
            ITerminologyProxy proxy,
            IUserDialogService userDialogService,
            IAccessControlManager accessControlManager,
            ICommandFactory commandFactory )
            : base ( proxy, userDialogService, accessControlManager, commandFactory, NamespaceToUse )
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the command factory helper.
        /// </summary>
        /// <param name="commandFactory">The command factory.</param>
        /// <returns>A <see cref="Rem.Ria.Infrastructure.Commands.ICommandFactoryHelper"/></returns>
        protected override ICommandFactoryHelper CreateCommandFactoryHelper ( ICommandFactory commandFactory )
        {
            return CommandFactoryHelper.CreateHelper ( this, commandFactory );
        }

        /// <summary>
        /// Maps the terminolgy concepts to search result.
        /// </summary>
        /// <param name="concepts">The concepts.</param>
        /// <returns>A <see cref="ObservableCollection&lt;ISearchResultDto&gt;"/></returns>
        protected override ObservableCollection<ISearchResultDto> MapTerminolgyConceptsToSearchResult ( IEnumerable<TerminologyConcept> concepts )
        {
            var conceptDtos = new ObservableCollection<ISearchResultDto> ();
            foreach ( var concept in concepts )
            {
                conceptDtos.Add (
                    new CodedConceptDto
                        {
                            CodedConceptCode = concept.Code,
                            CodeSystemIdentifier = _codeSystemIdentifier,
                            CodeSystemName = _codeSystemName,
                            DisplayName = concept.DisplayName,
                        } );
            }
            return conceptDtos;
        }

        #endregion
    }
}
