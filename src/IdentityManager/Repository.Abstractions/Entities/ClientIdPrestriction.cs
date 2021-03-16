﻿namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class ClientIdPrestriction
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
