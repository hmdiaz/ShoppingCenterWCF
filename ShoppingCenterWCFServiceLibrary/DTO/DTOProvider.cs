using ShoppingCenterBOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterWCFServiceLibrary.DTO
{
    [DataContract]
    public class DTOProvider
    {
        [DataMember]
        public int ProviderId { get; set; }

        [DataMember]
        public string ProviderName { get; set; }

        public DTOProvider(Provider provider)
        {
            this.ProviderId = provider.ProviderId;
            this.ProviderName = provider.ProviderName;
        }
    }
}
