using ApiCrudPersonajesSeries.Data;
using ApiCrudPersonajesSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudPersonajesSeries.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context) 
        { 
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertPersonajeAsync(int id, string nombre, string imagen, string serie)
        {
            Personaje personaje = new Personaje
            {
                Id = id,
                Nombre = nombre,
                Imagen = imagen,
                Serie = serie
            };
            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajesAsync(int id, string nombre, string imagen, string serie)
        {
            Personaje personaje = new Personaje
            {
                Id = id,
                Nombre = nombre,
                Imagen = imagen,
                Serie = serie
            };
            this.context.Personajes.Update(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajesAsync(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Personaje>> GetPersonajesBySerieAsync(string serie)
        {
            return await this.context.Personajes.Where(x => x.Serie == serie).ToListAsync();
        }

        public async Task<List<string>> GetSeriesAsync()
        {
            return await this.context.Personajes.Select(x => x.Serie).Distinct().ToListAsync();
        }
    }
}
