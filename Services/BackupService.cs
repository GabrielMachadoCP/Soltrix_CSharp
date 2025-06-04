namespace Soltrix.Services
{
    using System.IO;
    using System.Text.Json;
    using System;
    using System.Collections.Generic;
    using global::Soltrix.Models;

    namespace Soltrix.Services
    {
        public class BackupService
        {
            public void CriarBackup(List<EventoEnergia> eventos, string nomeArquivo)
            {
                string pastaBackup = @"C:\Backup_Soltrix";

                if (!Directory.Exists(pastaBackup))
                    Directory.CreateDirectory(pastaBackup);

                string caminhoCompleto = Path.Combine(pastaBackup, nomeArquivo);

                string json = JsonSerializer.Serialize(eventos, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(caminhoCompleto, json);

                Console.WriteLine($"Backup salvo em: {caminhoCompleto}");
            }
        }
    }


}
