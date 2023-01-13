using AutoMapper;
using PersonalProject.Data.DTO;
using PersonalProject.Data.Models;

public class AutomapperProfile: Profile
    {
        public AutomapperProfile(){
            CreateMap<User,  UserDTO>().ReverseMap();
        }
    }