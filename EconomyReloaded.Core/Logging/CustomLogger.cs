using System;
using System.IO;

namespace EconomyReloaded.Core.Logging
{
  public class CustomLogger
  {
    const string LogPath = @"C:\Users\jespe\Documents\Visual Studio 2015\Projects\EconomyReloaded\EconomyReloaded\App_Data\";
    public static void Log(Exception ex)
    {
      var file = "ErrorLog.txt";
      var fileName = string.Format("{0}{1}",DateTime.Now.ToString("yyyyMdd-hhmmss"),file);
      if (Directory.Exists(LogPath))
      {
        try
        {
          using (var writer = new StreamWriter(LogPath + fileName, true))
          {
            writer.WriteLine(ex.Message + " Time:" + DateTime.Now.ToString("o"));
          }
        }
        catch (Exception)
        {
        }
      }
    }
  }
}
