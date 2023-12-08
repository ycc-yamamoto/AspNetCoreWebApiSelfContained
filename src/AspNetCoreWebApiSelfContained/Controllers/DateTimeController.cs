using System;
using AspNetCoreWebApiSelfContained.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DateTimeOffset = System.DateTimeOffset;

namespace AspNetCoreWebApiSelfContained.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class DateTimeController : Controller
{
    [HttpGet]
    [ProducesResponseType(typeof(DateTimeOffsetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DateTimeOffsetDto> Get([FromQuery] string timeZoneId)
    {
        try
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var result = new DateTimeOffsetDto
            {
                Value = new DateTimeOffset(
                    TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone),
                    timeZone.BaseUtcOffset),
                TimeZone = new TimeZoneDto
                {
                    Id = timeZone.Id,
                    DisplayName = timeZone.DisplayName,
                    BaseUtcOffset = timeZone.BaseUtcOffset
                }
            };

            return result;
        }
        catch (TimeZoneNotFoundException)
        {
            return NotFound();
        }
    }
}
