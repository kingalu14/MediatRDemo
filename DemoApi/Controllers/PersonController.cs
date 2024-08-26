using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        IMediator _mediator;
        public PersonController(IMediator mediator) {
            _mediator = mediator;
        }


        [HttpGet]
        // GET: PersonController
        public async Task<List<PersonModel>> Get()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

       
        [HttpGet("{id}")]
        // GET: PersonController
        public async Task<PersonModel> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }


        // POST: PersonController/Create
        [HttpPost]
        public async Task<PersonModel> Post([FromBody] PersonModel value)
        {
            var model = new InsertPersonCommand(value.FirstName, value.LastName);
            return await _mediator.Send(model);
        }




        //// GET: PersonController/Details/5
        //public string Details(int id)
        //{
        //    return "value";
        //}

        //// GET: PersonController/Create
        //public string Create()
        //{
        //    return "value";
        //}

        //// POST: PersonController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public string Create(IFormCollection collection)
        //{
        //    return "value";
        //}

        //// GET: PersonController/Edit/5
        //public string Edit(int id)
        //{
        //    return "value";
        //}

        //// POST: PersonController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public string Edit(int id, IFormCollection collection)
        //{
        //  return "value";

        //}
    }
}
