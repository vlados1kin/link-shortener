using System.Security.Cryptography;
using System.Text;
using LinkShortener.Domain.Interfaces;

namespace LinkShortener.Application.Services;

public class ShortUrlGenerator : IShortUrlGenerator
{
    private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private const int ShortUrlLength = 9;
    
    public string Generate()
    {
        var shortUrlBuilder = new StringBuilder(ShortUrlLength);
        for (var i = 0; i < ShortUrlLength; i++)
        {
            var randomNumber = RandomNumberGenerator.GetInt32(0, int.MaxValue);
            shortUrlBuilder.Append(AllowedChars[randomNumber % AllowedChars.Length]);
        }

        return shortUrlBuilder.ToString();
    }
}