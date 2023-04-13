using BarcodeLib;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.Drawing.Imaging;

namespace FirstDemo.Infrastructure.Services.Extra;

public class BarcodeGeneratorService : IBarcodeGeneratorService
{
    private readonly Barcode _barcode;
    private readonly ILogger<BarcodeGeneratorService> _logger;
    private const string Base64ImagePrefix = "data:image/png;base64, ";

    public BarcodeGeneratorService(ILogger<BarcodeGeneratorService> logger)
    {
        _logger = logger;
        _barcode = new Barcode
        {
            IncludeLabel = true,
            StandardizeLabel = true,
            BackColor = Color.White,
            ForeColor = Color.Black
        };
    }

    public string GenerateBarcode(string data, int width = 250, int height = 100, TYPE type = TYPE.CODE93)
    {
        try
        {
            var image = _barcode.Encode(type, data, width, height);

            using var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            var imageBytes = ms.ToArray();
            return Base64ImagePrefix + Convert.ToBase64String(imageBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Barcode generating failed with {@Object}", new
            {
                data,
                type,
                width,
                height,
                imageFormat = ImageFormat.Png,
                includeLabel = true,
                standardizedLabel = true,
                backgroundColor = Color.White,
                foregroundColor = Color.Black
            });

            return string.Empty;
        }
    }
}