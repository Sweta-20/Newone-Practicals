using AutoMapper;
using RepositoryInCore.Models;
using RepositoryInCore.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryInCore
{
    public class UserProfile :Profile
    {                        
        public UserProfile()
        {
            //CreateMap<User, UserViewModal>();
            CreateMap<User, UserViewModal>()
        .ForMember(dest =>
            dest.LName,
            opt => opt.MapFrom(src => src.LastName))
            .ReverseMap();
            //CreateMap<User>
        }
    }
}
