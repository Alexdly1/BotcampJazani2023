using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.MineralTypes
{
    public class MineralTypeSavaDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public String? Slug { get; set; }
    }
}
