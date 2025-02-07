using LinkShortener.Application.Commands;
using LinkShortener.Application.DTO;
using LinkShortener.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.API.Controllers;

[ApiController]
[Route("shortener")]
public class ShortenerController : ControllerBase
{
    private readonly ISender _sender;
    
    public ShortenerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> GenerateShortUrl([FromBody] UrlRequestDto urlRequestDto)
    {
        var urlResponseDto = await _sender.Send(new CreateUrlCommand(urlRequestDto.LongUrl));
        urlResponseDto.ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{urlResponseDto.ShortUrl}";
        
        return Created(urlResponseDto.ShortUrl, urlResponseDto);
    }

    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> RedirectToLongUrl([FromRoute] string shortUrl)
    {
        var longUrl = await _sender.Send(new GetLongUrlQuery(shortUrl, true));

        return Redirect(longUrl);
    }
}