using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Users.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Results;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entites.Identity;

namespace SchoolProject.Core.Feature.Users.Queries.Handler
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUsersQuery, PaginatedResult<GetUsersDto>>,
        IRequestHandler<GetUserById, Response<GetUserByIdDto>>


    {
        #region Field
        private readonly IStringLocalizer<SharedResources> stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion
        #region  Constractor
        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper _mapper, UserManager<User> _userManager) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this._mapper = _mapper;
            this._userManager = _userManager;
        }

        #endregion
        #region Handle Function


        public async Task<PaginatedResult<GetUsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var pagnatedList = await _mapper.ProjectTo<GetUsersDto>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            pagnatedList.Meta = new { Count = pagnatedList.Data.Count() };
            return pagnatedList;
        }

        public async Task<Response<GetUserByIdDto>> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return NotFound<GetUserByIdDto>(stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var result = _mapper.Map<GetUserByIdDto>(user);
            return Success(result);

            #endregion
        }
    }
}