using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AppServiceApplicationSettingsToHcl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("入力ファイルパス(.json): ");
                string inputFilePath = Console.ReadLine();

                var date = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                string outputFilePath = $"OutputFile_{date}.txt";
                string jsonString = File.ReadAllText(inputFilePath);
                var data = JsonSerializer.Deserialize<List<ApplicationSetting>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (!File.Exists(outputFilePath))
                {
                    using (StreamWriter sw = File.CreateText(outputFilePath))
                    {
                        sw.WriteLine("app_settings = {");
                        foreach (var item in data)
                        {
                            sw.WriteLine($"\"{item.Name}\" = \"{item.Value}\"");
                        }
                        sw.WriteLine("}");
                    }
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
