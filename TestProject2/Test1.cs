using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Eclipseworks.Controllers;
using Eclipseworks.Entity;
using Eclipseworks.Model;
using Eclipseworks.Service;

namespace TestProject2
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task PostTarefa()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TarefasController>();

            Tarefa tarefa = new Tarefa();

            //TarefaController
            tarefa.IdProjeto = 1;
            tarefa.IdUsuario = 1;
            tarefa.Titulo = "Titulo Teste";
            tarefa.Descricao = "Descricao teste";
            tarefa.DataVencimento = DateTime.Now.AddDays(10);
            tarefa.DataInclusao = DateTime.Now;
            tarefa.Status = "em andamento";
            tarefa.Prioridade = "alta";
            tarefa.Comentarios = "Comentario teste";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            TarefasService register = new TarefasService(context);

            TarefasController addTarefa = new TarefasController(register, logger);
            var result = await addTarefa.Post(tarefa);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetAllTarefas()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TarefasController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            TarefasService register = new TarefasService(context);

            TarefasController addTarefa = new TarefasController(register, logger);
            var result = await addTarefa.Get();

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetTarefa()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TarefasController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            TarefasService register = new TarefasService(context);

            TarefasController addTarefa = new TarefasController(register, logger);
            var result = await addTarefa.Get();

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task PutTarefa()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TarefasController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            Tarefa tarefa = new Tarefa();

            tarefa.IdProjeto = 1;
            tarefa.IdUsuario = 1;
            tarefa.Titulo = "Titulo Teste update";
            tarefa.Descricao = "Descricao teste update";
            tarefa.DataVencimento = DateTime.Now.AddDays(10);
            tarefa.DataInclusao = DateTime.Now;
            tarefa.Status = "pendente";
            tarefa.Prioridade = "baixa";
            tarefa.Comentarios = "Comentario teste update";


            ApplicationDbContext context = new ApplicationDbContext(options);

            TarefasService register = new TarefasService(context);

            TarefasController addTarefa = new TarefasController(register, logger);
            var result = await addTarefa.Put(1, tarefa);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task DeleteTarefa()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<TarefasController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            TarefasService register = new TarefasService(context);

            TarefasController addTarefa = new TarefasController(register, logger);
            var result = await addTarefa.Delete(1);

            //<> 404
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task PostProjeto()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<ProjetosController>();

            Projeto projeto = new Projeto();

            //ProjetoController
            projeto.Id = 1;
            projeto.IdUsuario = 1;
            projeto.NomeProjeto = "Projeto Teste";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            var context = new ApplicationDbContext(options);

            var register = new ProjetosService(context);

            var addProjeto = new ProjetosController(register, logger);
            var result = await addProjeto.Post(projeto);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetAllProjetos()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<ProjetosController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            ProjetosService register = new ProjetosService(context);

            ProjetosController getProjeto = new ProjetosController(register, logger);
            var result = await getProjeto.Get();

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task DeleteProjeto()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<ProjetosController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            ProjetosService register = new ProjetosService(context);

            ProjetosController deleteProjeto = new ProjetosController(register, logger);
            var result = await deleteProjeto.Delete(1);

            //<> 404
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetRelatorioMediaTarefasConcluidasUltimoMes()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<RelatoriosController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            RelatoriosService register = new RelatoriosService(context);

            RelatoriosController getRelatorio = new RelatoriosController(register, logger);
            var result = await getRelatorio.RelatorioMediaTarefasConcluidasUltimoMes(1);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetRelatorioTarefasConcluidasUltimoMesPorUsuario()
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<RelatoriosController>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;TrustServerCertificate=true;")
            .Options;

            ApplicationDbContext context = new ApplicationDbContext(options);

            RelatoriosService register = new RelatoriosService(context);

            RelatoriosController getRelatorio = new RelatoriosController(register, logger);
            var result = await getRelatorio.RelatorioTarefasConcluidasUltimoMesPorUsuario(1);

            Assert.IsNotNull(result);

        }
    }
}
