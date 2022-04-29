using Microsoft.AspNetCore.Mvc;
using Project_Work.Services;
using Project_Work.Models;


namespace Project_Work.Controllers;

[ApiController]
[Route("somministrazione")]

public class SomministrazioneController : ControllerBase{

    private SomministrazioneService somministrazioneService = new SomministrazioneService();

    [HttpGet]
    public IEnumerable<Somministrazione> GetListaSomministrazioni(){
        return somministrazioneService.GetListaSomministrazioni();
    }

    [HttpGet("/vaccino/{vaccino}")]
    public IEnumerable<Somministrazione> GetListaVaccino(string vaccino){
        return somministrazioneService.GetListaVaccino(vaccino);
    }
    
    [HttpGet("/dose/{dose}")]
    public IEnumerable<Somministrazione> GetListaDose(string dose){
        return somministrazioneService.GetListaDose(dose);
    }

    [HttpGet("{id}")]
    public ActionResult<Somministrazione> GetSomministrazione(int id){
        return somministrazioneService.GetSomministrazione(id);
    }

    [HttpPost]
    public IActionResult Create(Somministrazione somministrazione){
        var result = somministrazioneService.Create(somministrazione);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Somministrazione somministrazione){
        var result = somministrazioneService.Update(id, somministrazione);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var result = somministrazioneService.Delete(id);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }
}