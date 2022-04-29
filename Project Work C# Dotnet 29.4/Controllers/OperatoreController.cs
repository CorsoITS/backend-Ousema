using Microsoft.AspNetCore.Mvc;
using Project_Work.Services;
using Project_Work.Models;


namespace Project_Work.Controllers;

[ApiController]
[Route("operatore")]

public class OperatoreController : ControllerBase{

    private OperatoreService operatoreService = new OperatoreService();

    [HttpGet]
    public IEnumerable<Operatore> GetListaOperatori(){
        return operatoreService.GetListaOperatori();
    }

    [HttpGet("{id}")]
    public ActionResult<Operatore> getOperatore(int id){
        return operatoreService.getOperatore(id);
    }

    [HttpPost]
    public IActionResult Create(Operatore operatore){
        var result = operatoreService.Create(operatore);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Operatore operatore){
        var result = operatoreService.Update(id, operatore);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var result = operatoreService.Delete(id);

        if (result){
            return Ok();
        } else{
            return BadRequest("I dati inseriti non sono corretti");
        }
    }
}