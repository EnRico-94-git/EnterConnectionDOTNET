using System;
namespace AdvancedBusinessDev.Services
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();

        // Propriedades de configuração
        public string ConnectionString { get; private set; }

        // Construtor privado para evitar instanciação externa
        private ConfigurationManager()
        {
            // Inicialize as configurações aqui
            ConnectionString = "Data Source=oracle.fiap.com.br:1521/orcl;User ID=rm;Password=;";
        }

        public static ConfigurationManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                    return _instance;
                }
            }
        }
    }
}