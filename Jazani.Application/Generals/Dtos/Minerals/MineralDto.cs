using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Domain.Generals.Models;
using System;

namespace Jazani.Application.Generals.Dtos.Minerals
{
    public class MineralDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public String? Symbol { get; set; }
        public MineralTypeSimpleDto MineralType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
