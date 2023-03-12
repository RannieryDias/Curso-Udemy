using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;
    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    
    [HttpGet("{id}")]
    public Evento Get(int id)
    {
        return _context.Eventos.FirstOrDefault(i => i.EventoId == id);
    }

    [HttpPost]
    public Evento Post(Evento evento)
    {
        return evento;
    }

    [HttpPut("{id}")]
    public Evento Put(int id)
    {
        Evento eventChange = _context.Eventos.FirstOrDefault(i => i.EventoId == id);
        

        return eventChange;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
}
