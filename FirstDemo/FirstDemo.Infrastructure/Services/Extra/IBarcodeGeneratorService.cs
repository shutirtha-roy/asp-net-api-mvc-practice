using BarcodeLib;

namespace FirstDemo.Infrastructure.Services.Extra;
public interface IBarcodeGeneratorService
{
    string GenerateBarcode(string data, int width = 200, int height = 100, TYPE type = TYPE.CODE128);
}