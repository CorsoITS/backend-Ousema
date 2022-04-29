using Project_Work.Models;
using Project_Work.Repositories;

namespace Project_Work.Services;

public class OperatoreService{

    public OperatoreRepository operatoreRepository = new OperatoreRepository();
    public SedeRepository sedeRepository = new SedeRepository();

    public IEnumerable<Operatore> GetListaOperatori(){
        return operatoreRepository.GetListaOperatori();
    }

    public Operatore getOperatore(int id){
        return operatoreRepository.GetOperatore(id);
    }

    public bool Create(Operatore operatore){
        if (operatoreRepository.GetOperatore(operatore.id) == null){
            if (operatore.name.Length > 0 && operatore.lastname.Length > 0 && operatore.username.Length > 0 && operatore.password.Length >0 && sedeRepository.GetSede(operatore.sede_id) != null){
                    return operatoreRepository.Create(operatore);
                }else {return false;}
        } else{return false;}     
    }

    public bool Update(int id, Operatore operatore){
        if (operatore.name.Length > 0 && operatore.lastname.Length > 0 && operatore.username.Length > 0 && operatore.password.Length >0 && sedeRepository.GetSede(operatore.sede_id) != null ){
                return operatoreRepository.Update(id, operatore);
            } else {return false;}
        }

    public bool Delete(int id){
        return operatoreRepository.Delete(id);
    }
}