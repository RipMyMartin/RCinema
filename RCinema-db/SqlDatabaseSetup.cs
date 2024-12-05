using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace RCinema_db
{
    [TestClass()]
    public class SqlDatabaseSetup
    {
        // Этот атрибут и метод необходимы для инициализации тестовой среды
        [AssemblyInitialize()]
        public static void InitializeAssembly(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext ctx)
        {
            // Настройка тестовой базы данных на основе настроек из конфигурационного файла
            SqlDatabaseTestClass.TestService.DeployDatabaseProject();
            SqlDatabaseTestClass.TestService.GenerateData();
        }
    }
}
