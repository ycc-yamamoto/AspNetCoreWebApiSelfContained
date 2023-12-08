using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebApiSelfContained.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiSelfContained.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TimeZoneController : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TimeZoneDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<TimeZoneDto>> Get([FromQuery] string? timeZoneWord = null)
    {
        IEnumerable<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();

        if (!string.IsNullOrEmpty(timeZoneWord))
        {
            timeZones = timeZones.Where(x => x.Id.Contains(timeZoneWord, StringComparison.OrdinalIgnoreCase));
        }

        var result = timeZones.Select(x => new TimeZoneDto
        {
            Id = x.Id,
            DisplayName = x.DisplayName,
            BaseUtcOffset = x.BaseUtcOffset
        }).ToArray();

        return result.Length == 0 ? NotFound() : result;
    }
}
