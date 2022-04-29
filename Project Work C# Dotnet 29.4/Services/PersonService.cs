using Project_Work.Models;
using Project_Work.Repositories;

namespace Project_Work.Services;

public class PersonService{

    public PersonRepository personRepository = new PersonRepository();

    public IEnumerable<Person> GetPeople(){
        return personRepository.GetPeople();
    }

    public Person getPerson(int id){
        return personRepository.GetPerson(id);
    }

    public bool Create(Person person){
        if (personRepository.GetPerson(person.id) == null){
            if (person.name.Length > 0 && person.lastname.Length > 0 && person.codice_fiscale.Length == 16 ){
                return personRepository.Create(person);
            } else {
                return false;
            }
        } else{
            return false;
        }      
    }

    public bool Update(int id, Person person){
        return personRepository.Update(id, person);
    }

    public bool Delete(int id){
        return personRepository.Delete(id);
    }
}