using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Playground
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
      IConfiguration config = builder.Build();

      var section = config.GetSection("Root");


      var result =  config.GetSection("Root").Get<Composite<ServiceA>>();


      IComposite<ServiceA> item =  result;

      Console.WriteLine("end");
    }
  }


  interface IComposite<TServiceInterface>
  {
    public string Commons { get; set; }
    public TServiceInterface Custom { get; set; }
  }

  class Composite<TServiceInterface> : IComposite<TServiceInterface>
  {
    public string Commons { get; set; }
    public TServiceInterface Custom { get; set; }
  }

  interface IServiceA
  {
    public string Name { get; set; }
  }

  class ServiceA : IServiceA
  {
    public string Name { get; set; }
  }
}