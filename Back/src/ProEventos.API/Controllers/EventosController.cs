using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contracts;
using ProEventos.Domain;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventService eventService;
    public EventosController(IEventService eventService)
    {
        this.eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventsEntity = await eventService.GetAllEventsAsync(true);
            if (eventsEntity == null) { return NotFound("Nenhum evento encontrado"); }

            return Ok(eventsEntity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var eventEntity = await eventService.GetEventByIdAsync(id, true);
            if (eventEntity == null) { return NotFound("Nenhum evento com a ID solicitada encontrado"); }

            return Ok(eventEntity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{theme}/theme")]
    public async Task<IActionResult> GetByTheme(string theme)
    {
        try
        {
            var eventEntity = await eventService.GetAllEventsByThemeAsync(theme, true);
            if (eventEntity == null) { return NotFound("Nenhum evento por tema encontrado"); }

            return Ok(eventEntity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Event newEvent)
    {
        try
        {
            var eventEntity = await eventService.AddEvents(newEvent);
            if (eventEntity == null) { return BadRequest("Erro ao inserir o evento"); }

            return Ok(eventEntity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar adicionar o evento. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Event myEvent)
    {
        //Erro atualmente aqui quando o myEvent ta vazio
        try
        {
            var eventEntity = await eventService.UpdateEvent(id, myEvent);
            if (eventEntity == null) { return BadRequest("Erro ao tentar atualizar"); }

            return Ok(eventEntity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar atualizar o evento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {

            return await eventService.DeleteEvent(id) ? 
                                        Ok($"O Evento de id: {id} foi excluído") :
                                        BadRequest("Evento não excluído");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                           $"Erro ao tentar excluir o evento. Erro: {ex.Message}");
        }
    }
}
