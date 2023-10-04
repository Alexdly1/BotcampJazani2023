﻿using System;

namespace Jazani.Application.Generals.Dtos.MineralTypes
{
    public class MineralTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public String? Slug { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
