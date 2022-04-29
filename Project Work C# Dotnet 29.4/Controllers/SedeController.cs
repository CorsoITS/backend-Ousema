using Microsoft.AspNetCore.Mvc;
using Project_Work.Services;
using Project_Work.Models;


namespace Project_Work.Controllers;

[ApiController]
[Route("sede")]

public class SedeController : ControllerBase{

    private SedeService sedeService = new SedeService();

    [HttpGet]
    public IEnumerable<Sede> GetListaSedi(){
        return sedeService.GetListaSedi();
    }

    [HttpGet("{id}")]
    public ActionResult<Sede> getSede(int id){
        return sedeService.getSede(id);
    }

    [HttpPost]
    public IActionResult Create(Sede sede){
        var result = sedeService.Create(sede);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Sede sede){
        var result = sedeService.Update(id, sede);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var result = sedeService.Delete(id);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }
}