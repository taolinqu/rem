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

using Agatha.Common;

namespace Rem.Ria.AgencyModule.Web.StaffEditor
{
    /// <summary>
    /// RemoveStaffTaskRoleRequest class.
    /// </summary>
    public class RemoveStaffTaskRoleRequest : Request
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveStaffTaskRoleRequest"/> class.
        /// </summary>
        /// <param name="staffKey">The staff key.</param>
        /// <param name="taskSystemRoleKey">The task system role key.</param>
        public RemoveStaffTaskRoleRequest ( long staffKey, long taskSystemRoleKey )
        {
            StaffKey = staffKey;
            TaskSystemRoleKey = taskSystemRoleKey;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="RemoveStaffTaskRoleRequest"/> class from being created.
        /// </summary>
        private RemoveStaffTaskRoleRequest ()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the staff key.
        /// </summary>
        /// <value>The staff key.</value>
        public long StaffKey { get; set; }

        /// <summary>
        /// Gets or sets the task system role key.
        /// </summary>
        /// <value>The task system role key.</value>
        public long TaskSystemRoleKey { get; set; }

        #endregion
    }
}
