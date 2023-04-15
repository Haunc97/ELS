namespace ELS.UseCase.PluginInterfaces.Common
{
    public interface IExcelReader
    {
        List<T> ReadExcel<T>(string filePath) where T : new();
        List<T> ReadExcel<T>(byte[] content) where T : new();
    }
}
