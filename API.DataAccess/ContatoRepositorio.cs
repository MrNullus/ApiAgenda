using API.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class ContatoRepositorio : DataBaseContext
    {
        protected DataBaseContext DB { get; set; }

        public ContatoRepositorio(string connString):base(connString) { DB = new DataBaseContext(connString); }


        /// <summary>
        /// Retorna todos contatos
        /// </summary>
        /// <returns></returns>
        public List<Contato> GetAll()
        {
            return DB.Contatos.ToList();
        }

        /// <summary>
        /// Retornando contato por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contato Get(int id)
        {
            return DB.Contatos.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Retornando contato por celular principal
        /// </summary>
        /// <param name="celular"></param>
        /// <returns></returns>
        public Contato GetContatoPorCelular(string celular)
        {
            return DB.Contatos.Where(x => x.Celular== celular).FirstOrDefault();
        }

        /// <summary>
        /// inserindo contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public int Insert(Contato contato)
        {
            var dbEntityEntry = DB.Entry(contato);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DB.Set<Contato>().Add(contato);
            }
            return DB.SaveChanges();
        }

        /// <summary>
        /// atualizando contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public int Update(Contato contato)
        {
            var dbEntityEntry = DB.Entry(contato);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DB.Set<Contato>().Attach(contato);
            }

            dbEntityEntry.State = EntityState.Modified;

            return DB.SaveChanges();
        }

        /// <summary>
        /// deletando o contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            var contato = DB.Set<Contato>().Find(id);
            if (contato == null)
            {
                return 0;
            }

            DB.Set<Contato>().Remove(contato);
            return DB.SaveChanges();
        }
    }
}
