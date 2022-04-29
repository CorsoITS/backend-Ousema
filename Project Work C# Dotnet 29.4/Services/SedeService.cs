using Project_Work.Models;
using Project_Work.Repositories;

namespace Project_Work.Services;

public class SedeService{

    public SedeRepository sedeRepository = new SedeRepository();

    public IEnumerable<Sede> GetListaSedi(){
        return sedeRepository.GetListaSedi();
    }

    public Sede getSede(int id){
        return sedeRepository.GetSede(id);
    }

    public bool Create(Sede sede){
        if (sedeRepository.GetSede(sede.id) == null){
            if (sede.name.Length > 0 && sede.city.Length > 0 && sede.address.Length > 0 ){
                return sedeRepository.Create(sede);
            } else {
                return false;
            }
        } else{
            return false;
        }      
    }

    public bool Update(int id, Sede sede){
        if (sede.name.Length > 0 && sede.city.Length > 0 && sede.address.Length > 0 ){
            return sedeRepository.Update(id, sede);
        } else {
            return false;
        }
}

    public bool Delete(int id){
        return sedeRepository.Delete(id);
    }
}