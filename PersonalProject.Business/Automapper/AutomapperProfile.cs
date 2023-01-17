using AutoMapper;
using PersonalProject.Data.DTO;
using PersonalProject.Data.Models;

public class AutomapperProfile: Profile
    {
        public AutomapperProfile(){
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<PatientsAppointment, PatientsAppointmentDTO>().AfterMap((patient, patientdto) => {
                if(patient.IdPatientNavigation != null){
                    Patient a = patient.IdPatientNavigation;
                    patientdto.PatientFullName = string.Concat(a.Name, " ", a.LastName);
                }
            }).ReverseMap();
            CreateMap<Patient, PatientDTO>().AfterMap((patient, patientdto) => {
                if(patient.IdAddressNavigation != null){
                    Address a = patient.IdAddressNavigation;
                    patientdto.Address = string.Concat(a.Street, " ", a.Apartment, " " , a.City, " ", a.State, " ", a.Country);
                }
            }).ReverseMap();
        }
    }