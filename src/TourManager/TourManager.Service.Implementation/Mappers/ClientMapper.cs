using System;
using System.Collections.Generic;
using TourManager.Repository.Entities;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation.Mappers
{
    /// <summary>
    /// Client mapper
    /// </summary>
    public class ClientMapper
    {
        /// <summary>
        /// Map client single entity to client model
        /// </summary>
        /// <param name="tourClient">The client entity to map</param>
        /// <returns></returns>
        public static Client MapFromSingle(TourClientEntity tourClient)
        {
            return new Client
            {
                Id = tourClient.Id,
                FirstName = tourClient.Client.FirstName,
                LastName = tourClient.Client.LastName,
                Phone = tourClient.Client.Phone,
                Email = tourClient.Client.Email,
                DateOfBirth = tourClient.Client.DateOfBirth,
                PlaceOfBirth = tourClient.Client.PlaceOfBirth,
                PassportNumber = tourClient.Client.PassportNumber,
                IssuedBy = tourClient.Client.IssuedBy,
                IssueDate = tourClient.Client.IssueDate,
                ExpireDate = tourClient.Client.ExpireDate,
                Notes = tourClient.Client.Notes
            };
        }

        /// <summary>
        /// Map client single model to client entity
        /// </summary>
        /// <param name="client">The client model to map</param>
        /// <returns></returns>
        public static TourClientEntity MapToSingle(Client client)
        {
            var tourClient = new ClientEntity
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Phone = client.Phone,
                Email = client.Email,
                DateOfBirth = client.DateOfBirth ?? new DateTime(),
                PlaceOfBirth = client.PlaceOfBirth,
                PassportNumber = client.PassportNumber,
                IssuedBy = client.IssuedBy,
                IssueDate = client.IssueDate ?? new DateTime(),
                ExpireDate = client.ExpireDate ?? new DateTime(),
                Notes = client.Notes
            };

            return new TourClientEntity
            {
                ClientId = tourClient.Id,
                Client = tourClient
            };
        }

        /// <summary>
        /// Map client entities collection to client model collection
        /// </summary>
        /// <param name="clients">The clients collection to map</param>
        /// <returns></returns>
        public static List<Client> MapFrom(ICollection<TourClientEntity> clients)
        {
            var result = new List<Client>();

            foreach (var client in clients)
            {
                // map each client
                result.Add(MapFromSingle(client));
            }

            return result;
        }

        /// <summary>
        /// Map client models collection to client entities collection
        /// </summary>
        /// <param name="clients">The clients collection to map</param>
        /// <returns></returns>
        public static List<TourClientEntity> MapTo(ICollection<Client> clients)
        {
            var result = new List<TourClientEntity>();

            foreach (var client in clients)
            {
                // map each client
                result.Add(MapToSingle(client));
            }

            return result;
        }
    }
}
