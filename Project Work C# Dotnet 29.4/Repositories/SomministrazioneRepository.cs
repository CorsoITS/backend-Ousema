using Project_Work.Context;
using MySql.Data.MySqlClient;
using Project_Work.Models;

namespace Project_Work.Repositories;

public class SomministrazioneRepository{

    private AppDb appDb = new AppDb();

    public IEnumerable<Somministrazione> GetListaSomministrazioni(){
        var result = new List<Somministrazione>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,vaccino,dose,data_somministrazione,note,operatore_id,persona_id from somministrazione";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var somministrazione = new Somministrazione(){
                id = reader.GetInt16("id"),
                vaccine = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                date = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("operatore_id"),
                persona_id = reader.GetInt16("persona_id"),
            };
            result.Add(somministrazione);
        }
        appDb.Connection.Close();
        return result;
    }

    public IEnumerable<Somministrazione> GetListaVaccino(string vaccino){
        var result = new List<Somministrazione>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from somministrazione WHERE vaccino=@vaccino";
        var parameter = new MySqlParameter()
        {
            ParameterName = "vaccino",
            DbType = System.Data.DbType.String,
            Value = vaccino
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var somministrazione = new Somministrazione(){
                id = reader.GetInt16("id"),
                vaccine = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                date = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("operatore_id"),
                persona_id = reader.GetInt16("persona_id"),
            };
            result.Add(somministrazione);
        }
        appDb.Connection.Close();
        return result;
    }

    public IEnumerable<Somministrazione> GetListaDose(string dose){
        var result = new List<Somministrazione>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select * from somministrazione WHERE dose=@dose";
        var parameter = new MySqlParameter()
        {
            ParameterName = "dose",
            DbType = System.Data.DbType.String,
            Value = dose
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var somministrazione = new Somministrazione(){
                id = reader.GetInt16("id"),
                vaccine = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                date = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("operatore_id"),
                persona_id = reader.GetInt16("persona_id"),
            };
            result.Add(somministrazione);
        }
        appDb.Connection.Close();
        return result;
    }
    public Somministrazione GetSomministrazione(int? id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,vaccino,dose,data_somministrazione,note,operatore_id,persona_id from somministrazione where id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var somministrazione = new Somministrazione()
            {
                id = reader.GetInt16("id"),
                vaccine = reader.GetString("vaccino"),
                dose = reader.GetString("dose"),
                date = reader.GetDateTime("data_somministrazione"),
                note = reader.GetString("note"),
                operatore_id = reader.GetInt16("operatore_id"),
                persona_id = reader.GetInt16("persona_id"),
            };
            appDb.Connection.Close();
            return somministrazione;
        }

        appDb.Connection.Close();
        return null;
    }
    public bool Create(Somministrazione somministrazione) {
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into somministrazione (vaccino,dose,data_somministrazione,note,operatore_id,persona_id) values (@vaccino,@dose,@data_somministrazione,@note,@operatore_id,@persona_id)";
        var parameterVaccine = new MySqlParameter()
        {
            ParameterName = "vaccino",
            DbType = System.Data.DbType.String,
            Value = somministrazione.vaccine
        };
        command.Parameters.Add(parameterVaccine);
        var parameterDose = new MySqlParameter()
        {
            ParameterName = "dose",
            DbType = System.Data.DbType.String,
            Value = somministrazione.dose
        };
        command.Parameters.Add(parameterDose);
        var parameterDate = new MySqlParameter()
        {
            ParameterName = "data_somministrazione",
            DbType = System.Data.DbType.DateTime,
            Value = somministrazione.date
        };
        command.Parameters.Add(parameterDate);
        var parameterNote = new MySqlParameter()
        {
            ParameterName = "note",
            DbType = System.Data.DbType.String,
            Value = somministrazione.note
        };
        command.Parameters.Add(parameterNote);
        var parameterOperatore_id = new MySqlParameter()
        {
            ParameterName = "operatore_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.operatore_id
        };
        command.Parameters.Add(parameterOperatore_id);
        var parameterPersona_id = new MySqlParameter()
        {
            ParameterName = "persona_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.persona_id
        };
        command.Parameters.Add(parameterPersona_id);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(int id, Somministrazione somministrazione){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update somministrazione set vaccino=@vaccino, dose=@dose, data_somministrazione=@data_somministrazione, note=@note, operatore_id=@operatore_id, persona_id=@persona_id where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var parameterVaccine = new MySqlParameter()
        {
            ParameterName = "vaccino",
            DbType = System.Data.DbType.String,
            Value = somministrazione.vaccine
        };
        command.Parameters.Add(parameterVaccine);
        var parameterDose = new MySqlParameter()
        {
            ParameterName = "dose",
            DbType = System.Data.DbType.String,
            Value = somministrazione.dose
        };
        command.Parameters.Add(parameterDose);
        var parameterDate = new MySqlParameter()
        {
            ParameterName = "data_somministrazione",
            DbType = System.Data.DbType.DateTime,
            Value = somministrazione.date
        };
        command.Parameters.Add(parameterDate);
        var parameterNote = new MySqlParameter()
        {
            ParameterName = "note",
            DbType = System.Data.DbType.String,
            Value = somministrazione.note
        };
        command.Parameters.Add(parameterNote);
        var parameterOperatore_id = new MySqlParameter()
        {
            ParameterName = "operatore_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.operatore_id
        };
        command.Parameters.Add(parameterOperatore_id);
        var parameterPersona_id = new MySqlParameter()
        {
            ParameterName = "persona_id",
            DbType = System.Data.DbType.Int16,
            Value = somministrazione.persona_id
        };
        command.Parameters.Add(parameterPersona_id);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from somministrazione where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }
}