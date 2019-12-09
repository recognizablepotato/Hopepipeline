﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HopePipeline.Models;
using System.Data.SqlClient;
using HopePipeline.Models.DbEntities.Tracking;

namespace HopePipeline.Controllers
{
    public class TrackingController : Controller
    {
        public IActionResult demoTracking()
        {
            return View();
        }

        public ViewResult ccrTracking()
        {
            return View();
        }

        public ViewResult schoolTracking()
        {
            return View();
        }

        public ViewResult disciplineTracking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitTracking()
        {
            return View();
        }

        public ViewResult TrackingList()
        {
            var results = new List<TrackingRow>();
            string connectionString = "Data Source=iscrew.database.windows.net;Initial Catalog=HopePipeline;User ID=user;Password=pAssw0rd;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();

            string query = "SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode;";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //We push information from the query into a row and onto the list of rows
               // TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = reader.GetString(2), clientCode = reader.GetString(3) };
                TrackingRow row = new TrackingRow { lname = reader.GetString(0), fname = reader.GetString(1), status = reader.GetInt32(2), clientCode = reader.GetInt32(3) };

                results.Add(row);
            }
            reader.Close();

            return View("TrackingList", results);
        }

        [HttpPost]
        public IActionResult Search(Tracking model)
        {
            string retur = model.Name;
            return Content(retur);
        }

        public ViewResult Delete(int ClientID)
        {
            string connectionString = "placeholder";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn.Open();
            string query = "DELETE from [tracking table] WHERE [ClientID] = " + ClientID + ";";
            command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            return View("TrackingList");
        }
    }
}