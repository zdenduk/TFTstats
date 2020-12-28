using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTstats.Model
{
    public class MetadataDTO
    {
        string data_version { get; set; }
        string match_id { get; set; }
        List<string> participants { get; set; }
    }
}
