﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Question;

public sealed record QuestionViewModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}
