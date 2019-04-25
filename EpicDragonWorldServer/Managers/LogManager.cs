﻿using System;
using System.IO;
using System.Runtime.CompilerServices;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class LogManager
{
    private static readonly string LOG_PATH = "Log" + Path.DirectorySeparatorChar;
    private static readonly string LOG_FILE_CONSOLE = "Console ";
    private static readonly string LOG_FILE_WORLD = "World ";
    private static readonly string LOG_FILE_CHAT = "Chat ";
    private static readonly string LOG_FILE_EXT = ".txt";
    private static readonly string LOG_DATE_FORMAT = "{0:dd/MM HH:mm:ss}";
    private static readonly string LOG_FILE_NAME_FORMAT = "{0:yyyy-MM-dd}";

    public static void Init()
    {
        // Create Log directory used by LogManager.
        Directory.CreateDirectory("Log");
    }

    private static string GetFileName(string prefix, DateTime currentTime)
    {
        string date = string.Format(LOG_FILE_NAME_FORMAT, currentTime);
        string fileName = LOG_PATH + prefix + date + LOG_FILE_EXT;
        if (Config.LOG_FILE_SIZE_LIMIT_ENABLED && File.Exists(fileName))
        {
            int counter = 0;
            long fileSize = new FileInfo(fileName).Length;
            while (fileSize >= Config.LOG_FILE_SIZE_LIMIT)
            {
                fileName = LOG_PATH + prefix + date + "-" + counter++ + LOG_FILE_EXT;
                fileSize = File.Exists(fileName) ? new FileInfo(fileName).Length : 0;
            }
        }
        return fileName;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void Log(string message)
    {
        DateTime currentTime = DateTime.Now;
        message = "[" + string.Format(LOG_DATE_FORMAT, currentTime) + "] " + message;
        // Write to console.
        Console.WriteLine(message);
        // Append to "log\Console yyyy-MM-dd.txt" file.
        using (StreamWriter writer = File.AppendText(GetFileName(LOG_FILE_CONSOLE, currentTime)))
        {
            writer.WriteLine(message);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void LogWorld(string message)
    {
        DateTime currentTime = DateTime.Now;
        // Append to "log\World yyyy-MM-dd.txt" file.
        using (StreamWriter writer = File.AppendText(GetFileName(LOG_FILE_WORLD, currentTime)))
        {
            writer.WriteLine("[" + string.Format(LOG_DATE_FORMAT, currentTime) + "] " + message);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void LogChat(string message)
    {
        DateTime currentTime = DateTime.Now;
        // Append to "log\Chat yyyy-MM-dd.txt" file.
        using (StreamWriter writer = File.AppendText(GetFileName(LOG_FILE_CHAT, currentTime)))
        {
            writer.WriteLine("[" + string.Format(LOG_DATE_FORMAT, currentTime) + "] " + message);
        }
    }
}
