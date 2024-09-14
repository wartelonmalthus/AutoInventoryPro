﻿using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Models.Interfaces.Repositorires;
using AutoInventoryPro.Models.Interfaces.Services;

namespace AutoInventoryPro.Services.Services;

public class ClientService(IClientRepository clientRepository) : BaseService<Client>(clientRepository), IClientService
{
}