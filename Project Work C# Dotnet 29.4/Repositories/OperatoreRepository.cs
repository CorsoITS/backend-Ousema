using Project_Work.Context;
using MySql.Data.MySqlClient;
using Project_Work.Models;

namespace Project_Work.Repositories;

public class OperatoreRepository{

    private AppDb appDb = new AppDb();

    public IEnumerable<Operatore> GetListaOperatori(){
        var result = new List<Operatore>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,nome,cognome,ruolo,username,sede_id from operatore";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operatore(){
                id = reader.GetInt16("id"),
                name = reader.GetString("nome"),
                lastname = reader.GetString("cognome"),
                role = reader.GetString("ruolo"),
                username = reader.GetString("username"),
                password = "*********",
                sede_id = reader.GetInt16("sede_id")
            };
            result.Add(operatore);
        }
        appDb.Connection.Close();

        return result;
    }

    public Operatore GetOperatore(int? id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,nome,cognome,ruolo,username,sede_id from operatore where id=@id";
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
            var operatore = new Operatore()
            {
                id = reader.GetInt16("id"),
                name = reader.GetString("nome"),
                lastname = reader.GetString("cognome"),
                role = reader.GetString("ruolo"),
                username = reader.GetString("username"),
                password = "*********",
                sede_id = reader.GetInt16("sede_id")
            };
            appDb.Connection.Close();
            return operatore;
        }

        appDb.Connection.Close();
        return null;
    }
    public bool Create(Operatore operatore) {
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into operatore (nome,cognome,ruolo,username,password,sede_id) values (@nome,@cognome,@ruolo,@username,@password,@sede_id)";
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.name
        };
        command.Parameters.Add(parameterName);
        var parameterLastName = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.lastname
        };
        command.Parameters.Add(parameterLastName);
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.role
        };
        command.Parameters.Add(parameterRuolo);
        var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.username
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSede = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.sede_id
        };
        command.Parameters.Add(parameterSede);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(int id, Operatore operatore){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update operatore set nome=@nome, cognome=@cognome, ruolo=@ruolo, username=@username, password=@password, sede_id=@sede_id where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = operatore.name
        };
        command.Parameters.Add(parameterName);
        var parameterLastName = new MySqlParameter()
        {
            ParameterName = "cognome",
            DbType = System.Data.DbType.String,
            Value = operatore.lastname
        };
        command.Parameters.Add(parameterLastName);
        var parameterRuolo = new MySqlParameter()
        {
            ParameterName = "ruolo",
            DbType = System.Data.DbType.String,
            Value = operatore.role
        };
        command.Parameters.Add(parameterRuolo);
        var parameterUsername = new MySqlParameter()
        {
            ParameterName = "username",
            DbType = System.Data.DbType.String,
            Value = operatore.username
        };
        command.Parameters.Add(parameterUsername);
        var parameterPassword = new MySqlParameter()
        {
            ParameterName = "password",
            DbType = System.Data.DbType.String,
            Value = operatore.password
        };
        command.Parameters.Add(parameterPassword);
        var parameterSede = new MySqlParameter()
        {
            ParameterName = "sede_id",
            DbType = System.Data.DbType.Int16,
            Value = operatore.sede_id
        };
        command.Parameters.Add(parameterSede);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from operatore where id=@id";
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