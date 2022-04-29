using Project_Work.Context;
using MySql.Data.MySqlClient;
using Project_Work.Models;

namespace Project_Work.Repositories;

public class SedeRepository{

    private AppDb appDb = new AppDb();

    public IEnumerable<Sede> GetListaSedi(){
        var result = new List<Sede>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,nome,citta,indirizzo from sede";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var sede = new Sede(){
                id = reader.GetInt16("id"),
                name = reader.GetString("nome"),
                city = reader.GetString("citta"),
                address = reader.GetString("indirizzo")
            };
            result.Add(sede);
        }
        appDb.Connection.Close();

        return result;
    }

    public Sede GetSede(int? id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id,nome,citta,indirizzo from sede where id=@id";
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
            var sede = new Sede()
            {
                id = reader.GetInt16("id"),
                name = reader.GetString("nome"),
                city = reader.GetString("citta"),
                address = reader.GetString("indirizzo")
            };
            appDb.Connection.Close();
            return sede;
        }

        appDb.Connection.Close();
        return null;
    }
    public bool Create(Sede sede) {
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into sede (nome,citta,indirizzo) values (@nome,@citta,@indirizzo)";
        var parameterName = new MySqlParameter()
        {
            ParameterName = "nome",
            DbType = System.Data.DbType.String,
            Value = sede.name
        };
        command.Parameters.Add(parameterName);
        var parameterCity = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.city
        };
        command.Parameters.Add(parameterCity);
        var parameterAddress = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.address
        };
        command.Parameters.Add(parameterAddress);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(int id, Sede sede){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update sede set nome=@nome, citta=@citta, indirizzo=@indirizzo where id=@id";
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
            Value = sede.name
        };
        command.Parameters.Add(parameterName);
         var parameterCity = new MySqlParameter()
        {
            ParameterName = "citta",
            DbType = System.Data.DbType.String,
            Value = sede.city
        };
        command.Parameters.Add(parameterCity);
        var parameterAddress = new MySqlParameter()
        {
            ParameterName = "indirizzo",
            DbType = System.Data.DbType.String,
            Value = sede.address
        };
        command.Parameters.Add(parameterAddress);

        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id){
        appDb.Connection.Open();

        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from sede where id=@id";
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