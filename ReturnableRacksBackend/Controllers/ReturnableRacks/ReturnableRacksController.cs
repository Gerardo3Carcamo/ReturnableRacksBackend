using Microsoft.AspNetCore.Mvc;
using ReturnableRacksBackend.Controllers.ReturnableRacks.Models;
using ReturnableRacksBackend.Controllers.ReturnableRacks.Methods;
using static ReturnableRacksBackend.Controllers.ReturnableRacks.Models.ReturnableRacksModels;

namespace ReturnableRacksBackend.Controllers.ReturnableRacks
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReturnableRacksController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddRoles(ReturnableRacksModels.Roles data) 
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddRoles(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, "Error", true, "AddRoles"));
            }
        }
        [HttpPost]
        public ActionResult DeleteRole(ReturnableRacksModels.Roles data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteRole(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, "Error", true, "AddRoles"));
            }
        }
        [HttpGet]
        public ActionResult GetAllRoles()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllRoles());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, "Error", true, "AddRoles"));
            }
        }
        [HttpPost]
        public ActionResult UpdateRole(ReturnableRacksModels.Roles data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateRole(data));
            }
            catch(Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, "Error", true, "UpdateRole"));
            }
        }

        [HttpPost]
        public ActionResult AddAreas(ReturnableRacksModels.Areas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddAreas(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddAreas"));
            }
        }
        [HttpPost]
        public ActionResult DeleteArea(ReturnableRacksModels.Areas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteArea(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteArea"));
            }
        }
        [HttpGet]
        public ActionResult GetAllAreas()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllAreas());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllAreas"));
            }
        }
        [HttpPost]
        public ActionResult UpdateArea(ReturnableRacksModels.Areas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateArea(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateArea"));
            }
        }

        [HttpPost]
        public ActionResult AddRampas(ReturnableRacksModels.Rampas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddRampas(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddRampas"));
            }
        }
        [HttpPost]
        public ActionResult DeleteRampa(ReturnableRacksModels.Rampas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteRampa(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteRampa"));
            }
        }
        [HttpGet]
        public ActionResult GetAllRampas()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllRampas());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllRampas"));
            }
        }
        [HttpPost]
        public ActionResult UpdateRampa(ReturnableRacksModels.Rampas data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateRampa(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateRampa"));
            }
        }

        [HttpPost]
        public ActionResult AddVendor(ReturnableRacksModels.Vendors data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddVendor(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddRampas"));
            }
        }
        [HttpPost]
        public ActionResult DeleteVendor(ReturnableRacksModels.Vendors data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteVendor(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteRampa"));
            }
        }
        [HttpGet]
        public ActionResult GetAllVendors()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllVendors());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllRampas"));
            }
        }
        [HttpPost]
        public ActionResult UpdateVendor(ReturnableRacksModels.Vendors data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateVendor(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateRampa"));
            }
        }

        [HttpPost]
        public ActionResult AddRack(ReturnableRacksModels.Racks data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddRack(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddRack"));
            }
        }

        [HttpPost]
        public ActionResult DeleteRack(ReturnableRacksModels.Racks data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteRack(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteRack"));
            }
        }

        [HttpPost]
        public ActionResult UpdateRack(ReturnableRacksModels.Racks data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateRack(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateRack"));
            }
        }

        [HttpGet]
        public ActionResult GetAllRacks()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllRacks());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllRacks"));
            }
        }

        [HttpPost]
        public ActionResult AddCarrier(Carriers data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddCarrier(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddCarrier"));
            }
        }

        [HttpPost]
        public ActionResult DeleteCarrier(Carriers data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteCarrier(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteCarrier"));
            }
        }

        [HttpPost]
        public ActionResult UpdateCarrier(Carriers data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateCarrier(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateCarrier"));
            }
        }

        [HttpGet]
        public ActionResult GetAllCarriers()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllCarriers());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllCarriers"));
            }
        }

        [HttpPost]
        public ActionResult AddOperador(ReturnableRacksModels.Operadores data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.AddOperador(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddOperador"));
            }
        }

        [HttpPost]
        public ActionResult DeleteOperador(ReturnableRacksModels.Operadores data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.DeleteOperador(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteOperador"));
            }
        }

        [HttpPost]
        public ActionResult UpdateOperador(ReturnableRacksModels.Operadores data)
        {
            try
            {
                return Ok(ReturnableRacksMethods.UpdateOperador(data));
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateOperador"));
            }
        }

        [HttpGet]
        public ActionResult GetAllOperadores()
        {
            try
            {
                return Ok(ReturnableRacksMethods.GetAllOperadores());
            }
            catch (Exception ex)
            {
                return NotFound(new ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllOperadores"));
            }
        }

    }
}
