using ShoppingAPI_Jueves_2023II.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2023II.DAL;
using ShoppingAPI_Jueves_2023II.DAL.Entities;
using ShoppingAPI_Jueves_2023II.Domain.Interfaces;

namespace ShoppingAPI_Jueves_2023II.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
        //creacion de metodo seederAsync
        //este metodo es una especie de main()
        // este metodo tendra la resposabilidad de prepoblar mis diferentes tablas en la BD

        public async Task SeederAsync()
        {
            // primero: agregare un metodo propio de EFC que hace las veces de comando update-database
            // un metodo que me crea la bD INMEDIATAMENTE PONGO EN EJECUCION MI API 

            await _context.Database.EnsureCreatedAsync();

            // apartir de aqui se crean los  metodo necesarios para prepoblar mi BD
            await PopulaterCountriesAsync();

            await _context.SaveChangesAsync();
        }
        #region private Methos
        private async Task PopulaterCountriesAsync()
        {
            //metodo Any() indica di la tabla tiene almenos  un registro
            // con (!) se niega el any he indica uq eno hat nada en la tabla 
            if (!_context.Countries.Any())
            {
                //asi se crea un objeto pais con su respectivos estados
                _context.Countries.Add(new Entities.Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "rusia",
                    States = new List<State>()
                    {
                        new State 
                        {
                            CreatedDate = DateTime.Now,
                            Name = "moscu"
                        },
                        new State 
                        {
                            CreatedDate = DateTime.Now,
                            Name = "San Petersburgo"
                        }
                    }
                });
            }
        }
            #endregion
    }
}
