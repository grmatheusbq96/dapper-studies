using Dapper;
using DapperStudy.Domain.Interfaces.Repositories.Generico;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DapperStudy.Infra.Persistence.Repositories.Generico
{
    public class RepositorioGenerico<TEntity, Tid> : IRepositorioGenerico<TEntity, Tid>
        where TEntity : class
        where Tid : IEquatable<Tid>
    {
        protected IDbConnection _connection;
        protected readonly string connectionString = "";

        public RepositorioGenerico()
        {
            _connection = new SqlConnection(connectionString);
        }

        public bool Add(TEntity entity)
        {
            try
            {
                var nomeTabela = ObterNomeTabela();
                var colunas = ObterColunas(excludeKey: true);
                var valores = ObterValores(excludeKey: true);
                var query = $"INSERT INTO {nomeTabela} ({colunas}) VALUES ({valores})";

                return _connection.Execute(query, entity) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                var nomeTabela = ObterNomeTabela();
                var colunaChave = ObterColunaChave();
                var valorChave = ObterValorChave();
                var query = $"DELETE FROM {nomeTabela} WHERE {colunaChave} = @{valorChave}";

                return _connection.Execute(query, entity) > 0;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                var nomeTabela = ObterNomeTabela();
                var query = $"SELECT * FROM {nomeTabela}";

                return _connection.Query<TEntity>(query);
            }
            catch
            {
                return null;
            }
        }

        public TEntity GetById(Tid Id)
        {
            try
            {
                var nomeTabela = ObterNomeTabela();
                var colunaChave = ObterColunaChave();
                var query = $"SELECT * FROM {nomeTabela} WHERE {colunaChave} = '{Id}'";

                return _connection.Query<TEntity>(query).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                var nomeTabela = ObterNomeTabela();
                var colunaChave = ObterColunaChave();
                var valorChave = ObterValorChave();

                var query = new StringBuilder();
                query.Append($"UPDATE {nomeTabela} SET ");

                foreach (var property in ObterPropriedades(true))
                {
                    var colunaAttr = property.GetCustomAttribute<ColumnAttribute>();

                    var nomePropriedade = property.Name;
                    var nomeColuna = colunaAttr.Name;

                    query.Append($"{nomeColuna} = @{nomePropriedade},");
                }

                query.Remove(query.Length - 1, 1);

                query.Append($" WHERE {colunaChave} = @{valorChave}");

                return _connection.Execute(query.ToString(), entity) > 0;
            }
            catch
            {
                return false;
            }
        }

        private static string ObterNomeTabela()
        {
            var objeto = typeof(TEntity);
            var tabelaAttr = objeto.GetCustomAttribute<TableAttribute>();

            if (tabelaAttr != null)
                return tabelaAttr.Name;

            return objeto.Name + "s";
        }

        public static string ObterColunaChave()
        {
            PropertyInfo[] propriedades = typeof(TEntity).GetProperties();

            foreach (PropertyInfo property in propriedades)
            {
                object[] keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);

                if (keyAttributes != null && keyAttributes.Length > 0)
                {
                    object[] columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);

                    if (columnAttributes != null && columnAttributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = (ColumnAttribute)columnAttributes[0];
                        return columnAttribute.Name;
                    }
                    else
                    {
                        return property.Name;
                    }
                }
            }

            return null;
        }

        private static string ObterColunas(bool excludeKey = false)
        {
            var objeto = typeof(TEntity);
            var colunas = string.Join(", ", objeto.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var colunaAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return colunaAttr != null ? colunaAttr.Name : p.Name;
                }));

            return colunas;
        }

        protected string ObterValores(bool excludeKey = false)
        {
            var propriedades = typeof(TEntity).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            var valores = string.Join(", ", propriedades.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return valores;
        }

        protected IEnumerable<PropertyInfo> ObterPropriedades(bool excludeKey = false)
        {
            var propriedades = typeof(TEntity).GetProperties()
                .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null);

            return propriedades;
        }

        protected string ObterValorChave()
        {
            var propriedades = typeof(TEntity).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if (propriedades.Any())
            {
                return propriedades.FirstOrDefault().Name;
            }

            return null;
        }
    }
}