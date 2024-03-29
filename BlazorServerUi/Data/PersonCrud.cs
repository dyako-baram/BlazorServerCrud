﻿using BlazorServerUi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerUi.Data
{
    public class PersonCrud : IPersonCrud
    {
        private readonly IConfiguration _configuration;

        public PersonCrud(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<PersonModel>> LoadPeople()
        {
            string ConnectionString = _configuration.GetConnectionString("Default");
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                var rows = await con.QueryAsync<PersonModel>("Select * from PersonTable", new { });
                return rows.ToList();
            }
        }
        public async Task InsertPerson(PersonModel personModel)
        {
            string ConnectionString = _configuration.GetConnectionString("Default");
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                Guid guid = Guid.NewGuid();
                await con.ExecuteAsync(" Insert into PersonTable(Id,FullName,DOB,Email,Gender) Values (@id,@fullName,@dOB,@email,@gender)", new { id = guid, personModel.FullName, personModel.DOB, personModel.Email, personModel.Gender });

            }
        }
        public async Task DeletePerson(Guid guid)
        {
            string ConnectionString = _configuration.GetConnectionString("Default");
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                await con.ExecuteAsync("delete from PersonTable where Id=@id", new { id = guid });

            }
        }
        public async Task UpdatePerson(PersonModel pm)
        {
            string ConnectionString = _configuration.GetConnectionString("Default");
            using (IDbConnection con = new SqlConnection(ConnectionString))
            {
                await con.ExecuteAsync("Update PersonTable set FullName=@fullName, DOB=@dOb,Email=@email,Gender=@gender where Id=@id", new {pm.FullName,pm.Email,pm.DOB,pm.Gender,pm.Id });

            }
        }

    }
}
