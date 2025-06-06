﻿namespace Soltrix.Services
{
    using System.IO;
    using System.Text.Json;
    using System;
    using System.Collections.Generic;
    using global::Soltrix.Models;

    namespace Soltrix.Services
    {
        /// <summary>
        /// Serviço responsável pela criação de backups de eventos de energia.
        /// </summary>
        public class BackupService
        {

            /// <summary>
            /// Cria um arquivo de backup com os eventos de energia fornecidos.
            /// </summary>
            /// <param name="eventos">Lista de eventos de energia a serem salvos.</param>
            /// <param name="nomeArquivo">Nome do arquivo de backup.</param>
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
