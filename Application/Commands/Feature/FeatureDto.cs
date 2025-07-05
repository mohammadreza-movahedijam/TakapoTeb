using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feature;

public sealed record FeatureDto
{

    public IFormFile? FileImageOne { get; set; }
    public IFormFile? FileImageTwo { get; set; }
    public IFormFile? FileImageThree { get; set; }
    public IFormFile? FileImageFour { get; set; }





    public string? ImageOne { get; set; }
    public string? ImageTwo { get; set; }
    public string? ImageThree { get; set; }
    public string? ImageFour { get; set; }
    public string? TitleEnOne { get; set; }
    public string? TitleEnTwo { get; set; }
    public string? TitleEnThree { get; set; }
    public string? TitleEnFour { get; set; }
    public string? TitleFaOne { get; set; }
    public string? TitleFaTwo { get; set; }
    public string? TitleFaThree { get; set; }
    public string? TitleFaFour { get; set; }
    public string? TextEnOne { get; set; }
    public string? TextEnTwo { get; set; }
    public string? TextEnThree { get; set; }
    public string? TextEnFour { get; set; }
    public string? TextFaOne { get; set; }
    public string? TextFaTwo { get; set; }
    public string? TextFaThree { get; set; }
    public string? TextFaFour { get; set; }
}
