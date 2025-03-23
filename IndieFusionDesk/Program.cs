using IndieDesk;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace IndieFusionDesk
{
    internal static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Adicionando configuração do appsettings
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            // Inicialize a configuração da aplicação antes de criar qualquer Form
            ApplicationConfiguration.Initialize();

            // Inicializando o formulário de login
            Login login = new Login();
            login.ShowDialog();

            // Após o login, executa o MDI principal
            Application.Run(new mdiUser());
        }
    }
}