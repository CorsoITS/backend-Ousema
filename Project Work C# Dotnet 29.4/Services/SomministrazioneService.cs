using Project_Work.Models;
using Project_Work.Repositories;

namespace Project_Work.Services;

public class SomministrazioneService{

    public SomministrazioneRepository somministrazioneRepository = new SomministrazioneRepository();
    public OperatoreRepository operatoreRepository = new OperatoreRepository();
    public PersonRepository personRepository = new PersonRepository();

    public IEnumerable<Somministrazione> GetListaSomministrazioni(){
        return somministrazioneRepository.GetListaSomministrazioni();
    }

    public IEnumerable<Somministrazione> GetListaVaccino(string vaccino){
        return somministrazioneRepository.GetListaVaccino(vaccino);
    }

    public IEnumerable<Somministrazione> GetListaDose(string dose){
        return somministrazioneRepository.GetListaDose(dose);
    }


    public Somministrazione GetSomministrazione(int id){
        return somministrazioneRepository.GetSomministrazione(id);
    }

    public bool Create(Somministrazione somministrazione){
        if(somministrazione.vaccine.Length > 0 && somministrazione.dose.Length > 0 && somministrazione.date <= DateTime.Now &&
         operatoreRepository.GetOperatore(somministrazione.operatore_id) != null && personRepository.GetPerson(somministrazione.persona_id) != null){
            return somministrazioneRepository.Create(somministrazione);
        } else{return false;}
}

    public bool Update(int id, Somministrazione somministrazione){
        if(somministrazione.vaccine.Length > 0 && somministrazione.dose.Length > 0 && somministrazione.date <= DateTime.Now && 
        operatoreRepository.GetOperatore(somministrazione.operatore_id) != null && personRepository.GetPerson(somministrazione.persona_id) != null){
            return somministrazioneRepository.Update(id, somministrazione);
        } else{return false;}
    }

    public bool Delete(int id){
        return somministrazioneRepository.Delete(id);
    }
}