using FluentValidation;
using LinkShortener.Application.DTO;

namespace LinkShortener.Application.Validators;

public class UrlRequestDtoValidator : AbstractValidator<UrlRequestDto>
{
    public UrlRequestDtoValidator()
    {
        RuleFor(url => url.LongUrl)
            .NotEmpty().WithMessage("Long url is required.")
            .Must(IsValidUrl)
            .WithMessage("Long url is not in the correct format. The correct formats: http://example.com/ or https://foo.net/bar?baz=1");
    }

    private bool IsValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}