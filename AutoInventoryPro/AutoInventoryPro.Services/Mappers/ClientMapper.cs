﻿using AutoInventoryPro.Models.Entities;
using AutoInventoryPro.Views.Client.Requests;
using AutoInventoryPro.Views.Client.Responses;

namespace AutoInventoryPro.Services.Mappers;

public static class ClientMapper
{
    public static ClientResponse ToResponse(this Client client) => new()
    {
        IdClient = client.Id,
        CPF = client.CPF,
        Name = client.Name,
        Phone= client.Phone
    };

    public static Client ToEntity(this ClientCreateRequest request) => new() 
    {
        CPF = request.CPF,
        Name = request.Name,
        Phone = request.Phone
    };



    public static IEnumerable<ClientResponse> ToResponse(this IEnumerable<Client> clients) => clients.Select(Client => Client.ToResponse());


}
