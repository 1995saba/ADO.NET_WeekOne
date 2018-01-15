using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    // Data Transfer Object
    public class RegionDTO
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public override string ToString()
        {
            return $"{RegionId} - {RegionDescription}";
        }
        public RegionDTO(int regionId, string regionDescription)
        {
            RegionId = regionId;
            RegionDescription = regionDescription;
        }

        public RegionDTO()
        {

        }
    }
}
