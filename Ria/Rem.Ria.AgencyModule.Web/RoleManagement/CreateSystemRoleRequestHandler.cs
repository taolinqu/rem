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

using AutoMapper;
using Rem.Domain.Core.SecurityModule;
using Rem.Infrastructure.Service;
using Rem.Infrastructure.Service.DataTransferObject;
using Rem.Ria.AgencyModule.Web.Common;

namespace Rem.Ria.AgencyModule.Web.RoleManagement
{
    /// <summary>
    /// Class for handling create system role request.
    /// </summary>
    public class CreateSystemRoleRequestHandler : CommandRequestHandler<CreateSystemRoleRequest, SystemRoleCommandResponse, ValidationFailureDto>
    {
        #region Constants and Fields

        private readonly ISystemRoleFactory _systemRoleFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSystemRoleRequestHandler"/> class.
        /// </summary>
        /// <param name="systemRoleFactory">The system role factory.</param>
        public CreateSystemRoleRequestHandler ( ISystemRoleFactory systemRoleFactory )
        {
            _systemRoleFactory = systemRoleFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the dto from request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A <see cref="Rem.Infrastructure.Service.DataTransferObject.ValidationFailureDto"/></returns>
        protected override ValidationFailureDto CreateDtoFromRequest ( CreateSystemRoleRequest request )
        {
            return new ValidationFailureDto ();
        }

        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        protected override void HandleRequest ( CreateSystemRoleRequest request, SystemRoleCommandResponse response )
        {
            var systemRole = _systemRoleFactory.CreateSystemRole ( request.Name, request.Description, request.SystemRoleType );

            if ( Success )
            {
                FlushSession ();

                var systemRoleDto = new SystemRoleDto ();
                response.SystemRole = Mapper.Map ( systemRole, systemRoleDto );
            }
        }

        #endregion
    }
}
