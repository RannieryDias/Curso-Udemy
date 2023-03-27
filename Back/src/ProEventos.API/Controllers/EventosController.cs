using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly ProEventosContext _context;
    public EventosController(ProEventosContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return _context.Events;
    }

    
    [HttpGet("{id}")]
    public Event Get(int id)
    {
        return _context.Events.FirstOrDefault(i => i.Id == id);
    }

    [HttpPost]
    public Event Post(Event evento)
    {
        return evento;
    }

    [HttpPut("{id}")]
    public Event Put(int id)
    {
        Event eventChange = _context.Events.FirstOrDefault(i => i.Id == id);
        

        return eventChange;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
}
