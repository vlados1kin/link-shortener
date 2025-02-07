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

    [HttpGet("{shortUrl:regex(^[[a-zA-Z0-9]]{{9}}$)}")]
    public async Task<IActionResult> RedirectToLongUrl([FromRoute] string shortUrl)
    {
        var longUrl = await _sender.Send(new GetLongUrlQuery(shortUrl, true));

        return Redirect(longUrl);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUrlByLongUrl([FromRoute] Guid id)
    {
        await _sender.Send(new DeleteUrlByIdCommand(id, true));

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUrls()
    {
        var urlsResponseDto = await _sender.Send(new GetAllUrlsQuery(false));

        return Ok(urlsResponseDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUrl([FromRoute] Guid id, [FromBody] UrlRequestDto urlRequestDto)
    {
        var urlResponseDto = await _sender.Send(new UpdateUrlCommand(id, urlRequestDto.LongUrl));
        urlResponseDto.ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{urlResponseDto.ShortUrl}";
        
        return Ok(urlResponseDto);
    }
}