using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IPOC.VendorAndCustomer.ClientAppService;
using IPOC.VendorAndCustomer;
using IPOC.VendorAndCustomer.ClientLedgerAppService;
using IPOC.VendorAndCustomer.VendorAppService;
using IPOC.VendorAndCustomer.VendorLedgerService;

namespace IPOC.Mapper.VendorAndClientMapper;
public class ClientApplicationAutoMapperProfile : Profile
{
    public ClientApplicationAutoMapperProfile()
    {
        CreateMap<Client, ClientDto>();
        CreateMap<CreateUpdateClientDto, Client>();

        // Client Ledger
        CreateMap<ClientLedger, ClientLedgerDto>()
          .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.FullName));
        CreateMap<CreateUpdateClientLedgerDto, ClientLedger>();

        // Vendor 
        CreateMap<Vendor, VendorDto>().ReverseMap();
        CreateMap<CreateUpdateVendorDto, Vendor>();

        CreateMap<VendorLedgerEntry, VendorLedgerEntryDto>().ReverseMap();
        CreateMap<CreateUpdateVendorLedgerEntryDto, VendorLedgerEntry>();



    }
}

