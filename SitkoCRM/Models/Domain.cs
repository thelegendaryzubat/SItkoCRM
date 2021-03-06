﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("Domains")]
    public class Domain : BaseModel<int>
    {
        public string Name { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))] public DomainStatus Status { get; set; }

        public int HostId { get; set; }

        [ForeignKey(nameof(HostId))] public Host Host { get; set; }

        public List<DomainService> DomainsServices { get; set; }
    }

    public class DomainsRepository : Repository<Domain, int, CRMContainer>
    {
        public DomainsRepository(RepositoryContext<Domain, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
