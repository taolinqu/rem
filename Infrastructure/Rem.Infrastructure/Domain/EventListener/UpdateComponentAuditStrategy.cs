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

using System.Reflection;

namespace Rem.Infrastructure.Domain.EventListener
{
    internal class UpdateComponentAuditStrategy : IComponentAuditStrategy
    {
        private readonly object _oldOwnerValue;
        private readonly object _newOwnerValue;

        public UpdateComponentAuditStrategy(object oldOwnerValue, object newOwnerValue)
        {
            _oldOwnerValue = oldOwnerValue;
            _newOwnerValue = newOwnerValue;
        }

        public bool IsExcludedFromAudit(PropertyInfo propertyInfo)
        {
            object oldValue = GetValue(propertyInfo, _oldOwnerValue);
            object newValue = GetValue(propertyInfo, _newOwnerValue);

            bool result = (oldValue == null && newValue == null) || Equals(oldValue, newValue);

            return result;
        }

        public string GetAuditNoteForNonComponentProperty(PropertyInfo propertyInfo, string columnName)
        {
            object oldValue = GetValue(propertyInfo, _oldOwnerValue);
            object newValue = GetValue(propertyInfo, _newOwnerValue);

            var note = PatientAccessAuditableListenerHelper.GetColumnUpdateNote ( columnName, oldValue, newValue );

            return note;
        }

        public IComponentAuditStrategy GetComponentPropertyAuditStrategy(PropertyInfo propertyInfo)
        {
            object oldValue = GetValue(propertyInfo, _oldOwnerValue);
            object newValue = GetValue(propertyInfo, _newOwnerValue);

            return new UpdateComponentAuditStrategy ( oldValue, newValue );
        }

        private static object GetValue(PropertyInfo propertyInfo, object ownerValue)
        {
            if (ownerValue == null)
            {
                return null;
            }

            return propertyInfo.GetValue(ownerValue, null);
        }
    }
}