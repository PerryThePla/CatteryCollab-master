using Application.Interfaces;
using Application.UseCases;
using System.Configuration;
using System.Data;
using System.Windows;
using Infrastracture.Persistance.Repositories;
using System.IO;
using Domain.Model.Entities;
using Infrastracture.Persistance.Dto;
using Application.Dto;
namespace WpfCattery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>


    public partial class App : System.Windows.Application
    {
        // Repository e servizi accessibili globalmente
        public static ICatRepository CatRepository { get; private set; }
        public static IAdoptionRepository AdoptionRepository { get; private set; }
        public static IModelRepository<Adopter> AdopterRepository { get; private set; }
        public static CatService CatService { get; private set; }
        public static AdoptionService AdoptionService { get; private set; }
        public static AdopterService AdopterService { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string baseDir = AppContext.BaseDirectory;
            CatRepository = new JsonCatRepository(Path.Combine(baseDir, "cats.json"));
            AdoptionRepository = new JsonAdoptionRepository(Path.Combine(baseDir, "adoptions.json"));
            AdopterRepository = (IModelRepository<Adopter>) new JsonAdopterRepository(Path.Combine(baseDir, "adopters.json"));
            AdoptionService = new AdoptionService(AdoptionRepository);
            AdopterService = new AdopterService(AdopterRepository);
            CatService = new CatService(CatRepository);
        }
    }

}
