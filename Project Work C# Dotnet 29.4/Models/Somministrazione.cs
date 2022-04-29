namespace Project_Work.Models;

public class Somministrazione{

    public int? id {get;set;}
    public string vaccine {get;set;}
    public string dose {get;set;}
    public DateTime date {get;set;}
    public string note {get;set;}    
    public int operatore_id {get;set;}
    public int persona_id {get;set;}

}