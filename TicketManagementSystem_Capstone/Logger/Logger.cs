using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace TicketManagementSystem_Capstone.Logger;

public class Logger
{
    private static Logger instance = null;
    private string filePath;
    private static readonly object padlock = new object();

    public static Logger Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

    }

    private Logger()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var logDir = Path.Combine(appDataPath, "Dura-Tech", "Logs");
        filePath = Path.Combine(logDir, "log.txt");
        LogDirectoryExists(logDir);
    }

    private void LogDirectoryExists(string dir)
    {
        try
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
    }
    public void WriteError(string error)
    {
        try
        {
            lock(padlock) { 
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(error);
            }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
