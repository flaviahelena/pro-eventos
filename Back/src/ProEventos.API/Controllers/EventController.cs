using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {

        private readonly DataContext context;

        public EventController(DataContext context){
            this.context = context;

        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return context.Events;
        }
        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            return context.Events.FirstOrDefault(evento => evento.EventID == id);
        }
    }
}
