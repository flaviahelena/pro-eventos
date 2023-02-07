using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {


        public IEnumerable<Event> _event = new Event[]
        {
            new Event(){
                    EventID = 1,
                    Theme = "Angular 11 e .Net 5",
                    Local = "Belo Horizonte",
                    Batch = "1º lote",
                    QtdPeople = 250,
                    EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageURL = "foto.jpg"
                },
                new Event(){
                    EventID = 2,
                    Theme = "Angular 11 e .Net 5 e suas novidades",
                    Local = "Belo Horizonte",
                    Batch = "1º lote",
                    QtdPeople = 250,
                    EventDate = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    ImageURL = "foto.jpg"
                }
        };

        public EventController(){

        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _event;
        }
        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return _event.Where(evento => evento.EventID == id);
        }
    }
}
