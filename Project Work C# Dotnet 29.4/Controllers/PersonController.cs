using Microsoft.AspNetCore.Mvc;
using Project_Work.Models;
using Project_Work.Services;


namespace Project_Work.Controllers;

[ApiController]
[Route("person")]

public class PersonController : ControllerBase{

    private PersonService personService = new PersonService();

    [HttpGet]
    public IEnumerable<Person> GetPeople(){
        return personService.GetPeople();
    }

    [HttpGet("{id}")]
    public ActionResult<Person> getPerson(int id){
        return personService.getPerson(id);
    }

    [HttpPost]
    public IActionResult Create(Person person){
        var result = personService.Create(person);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Person person){
        var result = personService.Update(id, person);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var result = personService.Delete(id);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }
}