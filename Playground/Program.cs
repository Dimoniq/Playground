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

      var result =  config.GetSection("Root").Get<Composite<ServiceA>>();


      IComposite<ServiceA> item =  result;

      Console.WriteLine("end");
    }
  }


  interface IComposite<T>
  {
    public string Commons { get; set; }
    public T Custom { get; set; }
  }

  class Composite<T> : IComposite<T>
  {
    public string Commons { get; set; }
    public T Custom { get; set; }
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