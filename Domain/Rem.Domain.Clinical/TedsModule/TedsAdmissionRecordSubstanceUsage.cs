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
using Pillar.Common;
using Pillar.Common.Utility;
using Pillar.Domain;

namespace Rem.Domain.Clinical.TedsModule
{
    /// <summary>
    /// This class defines an TendsAdmissionInterview aggregate node value object for substance usage.
    /// </summary>
    public class TedsAdmissionRecordSubstanceUsage : TedsAdmissionRecordAggregateNodeBase, IAggregateNodeValueObject, IValuesEquatable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TedsAdmissionRecordSubstanceUsage"/> class.
        /// </summary>
        protected internal TedsAdmissionRecordSubstanceUsage ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TedsAdmissionRecordSubstanceUsage"/> class.
        /// </summary>
        /// <param name="substanceUsageAtAdmission">The substance usage at admission.</param>
        public TedsAdmissionRecordSubstanceUsage(
            SubstanceUsageAtAdmission substanceUsageAtAdmission)
        {
            Check.IsNotNull(substanceUsageAtAdmission, () => SubstanceUsageAtAdmission);
            SubstanceUsageAtAdmission = substanceUsageAtAdmission;
        }

        #endregion

        /// <summary>
        /// Gets the substance usage at admission.
        /// </summary>
        [NotNull]
        public virtual SubstanceUsageAtAdmission SubstanceUsageAtAdmission { get; private set; }

        /// <summary>
        /// Checks if all the values of the object are equal.
        /// </summary>
        /// <param name="obj">The object to check equality with.</param>
        /// <returns>
        /// A bool indicating whether objects are equal.
        /// </returns>
        public virtual bool ValuesEqual(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }

            return ValuesEqual(obj as TedsAdmissionRecordSubstanceUsage);
        }

        /// <summary>
        /// Valueses the equal.
        /// </summary>
        /// <param name="substanceUsage">The substance usage.</param>
        /// <returns>A bool indicating whether objects are equal.</returns>
        public virtual bool ValuesEqual(TedsAdmissionRecordSubstanceUsage substanceUsage)
        {
            if (substanceUsage == null)
            {
                return false;
            }

            var valuesEqual =
                Equals(SubstanceUsageAtAdmission, substanceUsage.SubstanceUsageAtAdmission);

            return valuesEqual;
        }
    }
}
