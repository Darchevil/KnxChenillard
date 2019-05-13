using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChenillardWebApp.Models;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using Knx.Bus.Common.Configuration;
using Knx.Falcon.Sdk;
using Knx.Bus.Common;
using Knx.Bus.Common.GroupValues;
using System.Threading;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChenillardWebApp.Controllers
{
    [Route("api/[controller]")]
    public class StateChenillardController : ControllerBase
    {
        public int speed = 1000;
        public string Led1 = "0/1/1";
        public string Led2 = "0/1/2";
        public string Led3 = "0/1/3";
        public string Led4 = "0/1/4";

        //******************************************GET METHODS***********************************************
        //****************************************************************************************************


        //TESTS
        [HttpGet ("{id}")]
        [Produces("application/json")]
        public IActionResult Get(int id, string query)
        {
            return Ok(new Value { Id = id, Text = "value :" + id });
        }

        [HttpPost]
        public IActionResult Post([FromBody]Value value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Save the value to the database.
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }


        [HttpGet ("Connect")]
        public ActionResult<string> index()
        {
            Bus bus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.1.10", 0x0e57, false));
            Chenillard chenillard = new Chenillard(bus);
            return "connected : type '/start' to start the chenillard and '/stop' to stop it";
        }

        //[HttpGet]
        //public ActionResult<string> accueil()
        //{
        //    return 
        //}




        [HttpGet("disconnect")]
        public ActionResult<string> disconnection()
        {
            using (Bus bus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.1.10", 0x0e57, false)))
            {
                // Disconnect when done
                bus.Disconnect();
            }
            return "disconnected";
        }
        [HttpGet("readValue")]
        public ActionResult<string> read()
        {
            using (Bus bus = new Bus(new KnxIpTunnelingConnectorParameters("192.168.0.10", 0x0e57, false)))
            {
                // Read value from sensor
                GroupValue data = bus.ReadValue("0/0/1");
            }
            return "read";
        }
    }
    public class Value
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
    }
}
