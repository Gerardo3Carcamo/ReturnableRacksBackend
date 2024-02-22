using ReturnableRacksBackend.Services;
using System.Data;
using static ReturnableRacksBackend.Controllers.ReturnableRacks.Models.ReturnableRacksModels;
namespace ReturnableRacksBackend.Controllers.ReturnableRacks.Methods
{
    public class ReturnableRacksMethods
    {
        public static Models.ReturnableRacksModels.HttpResponse AddRoles(Roles data)
        {
            string query = $@"Insert into RR_ROLES VALUES (@ROLE_NAME)";
            Dictionary<string, object?>? param = new();
            param?.Add("@ROLE_NAME", data.ROLE_NAME);
            SQLService.InsertMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddRoles");
        }
        public static Models.ReturnableRacksModels.HttpResponse GetAllRoles()
        {
            string query = $@"Select ID AS ROLE_ID, ROLE_NAME AS ROLE_NAME FROM RR_ROLES";
            List<Models.ReturnableRacksModels.Roles> list = SQLService.SelectMethod<Models.ReturnableRacksModels.Roles>(query);
            return new Models.ReturnableRacksModels.HttpResponse(list, "Ok", false, "AddRoles");
        }
        public static Models.ReturnableRacksModels.HttpResponse DeleteRole(Roles data)
        {
            string query = $@"DELETE FROM RR_ROLES WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.ROLE_ID);
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteRoles");
        }
        public static Models.ReturnableRacksModels.HttpResponse UpdateRole(Roles data)
        {
            string query = $@"Update RR_ROLES SET ROLE_NAME = @ROLE_NAME WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.ROLE_ID);
            param.Add("ROLE_NAME", data.ROLE_NAME);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteRoles");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllAreas()
        {
            string query = $@"SELECT ID AS AREA_ID, AREA_CODE AS AREA_CODE, AREA_DESC AS AREA_DESC FROM RR_AREAS";
            List<Areas> areas = new List<Areas>();
            areas = SQLService.SelectMethod<Areas>(query);
            return new Models.ReturnableRacksModels.HttpResponse(areas, "Ok", false, "GetAllAreas");
        }
        public static Models.ReturnableRacksModels.HttpResponse AddAreas(Areas data)
        {
            string query = $@"INSERT INTO RR_AREAS VALUES (@AREA_CODE, @AREA_DESC)";
            Dictionary<string, object?>? param = new();
            param.Add("AREA_CODE", data.AREA_CODE);
            param.Add("AREA_DESC", data.AREA_DESC);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddAreas");
        }
        public static Models.ReturnableRacksModels.HttpResponse DeleteArea(Areas data)
        {
            string query = $@"DELETE FROM RR_AREAS WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.AREA_ID);
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteArea");
        }
        public static Models.ReturnableRacksModels.HttpResponse UpdateArea(Areas data)
        {
            string query = $@"Update RR_AREAS SET AREA_DESC = @AREA_DESC, AREA_CODE = @AREA_CODE WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.AREA_ID);
            param.Add("AREA_DESC", data.AREA_DESC);
            param.Add("AREA_CODE", data.AREA_CODE);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "UpdateArea");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllRampas()
        {
            string query = $@"SELECT R.ID AS RAMPA_ID, R.RAMP_NUMBER AS DOCK_NUMBER, A.AREA_CODE AS AREA_CODE 
                                FROM RR_RAMPAS AS R
                                INNER JOIN RR_AREAS AS A ON
                                A.ID = R.AREA_ID";
            List<Rampas> rampas = new();
            rampas = SQLService.SelectMethod<Rampas>(query);
            return new Models.ReturnableRacksModels.HttpResponse(rampas, "Ok", false, "GetAllRampas");
        }
        public static Models.ReturnableRacksModels.HttpResponse AddRampas(Rampas data)
        {
            string query = $@"INSERT INTO RR_RAMPAS VALUES (@RAMP_NUMBER, @AREA_ID)";
            Dictionary<string, object?>? param = new();
            param.Add("RAMP_NUMBER", data.DOCK_NUMBER);
            param.Add("AREA_ID", data.AREA_ID);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddRampas");
        }
        public static Models.ReturnableRacksModels.HttpResponse DeleteRampa(Rampas data)
        {
            string query = $@"DELETE FROM RR_RAMPAS WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.RAMPA_ID);
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteArea");
        }
        public static Models.ReturnableRacksModels.HttpResponse UpdateRampa(Rampas data)
        {
            string query = $@"Update RR_RAMPAS SET AREA_ID = @AREA_ID, RAMP_NUMBER = @DOCK_NUMBER WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.RAMPA_ID);
            param.Add("AREA_ID", data.AREA_ID);
            param.Add("DOCK_NUMBER", data.DOCK_NUMBER);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "UpdateArea");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllVendors()
        {
            string query = $@"select id as VENDOR_ID, * from RR_VENDORS";
            List<Vendors> list = SQLService.SelectMethod<Vendors>(query);
            return new Models.ReturnableRacksModels.HttpResponse(list, "Ok", false, "GetAllVendors");
        }
        public static Models.ReturnableRacksModels.HttpResponse AddVendor(Vendors data)
        {
            string query = $@"INSERT INTO RR_VENDORS (VENDOR_CODE, VENDOR_NAME, VENDOR_DESC) 
                          VALUES (@VENDOR_CODE, @VENDOR_NAME, @VENDOR_DESC)";
            Dictionary<string, object?>? param = new();
            param.Add("VENDOR_CODE", data.VENDOR_CODE);
            param.Add("VENDOR_NAME", data.VENDOR_NAME);
            param.Add("VENDOR_DESC", data.VENDOR_DESC);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddVendor");
        }

        public static Models.ReturnableRacksModels.HttpResponse DeleteVendor(Vendors data)
        {
            string query = $@"DELETE FROM RR_VENDORS WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.VENDOR_ID);
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteVendor");
        }

        public static Models.ReturnableRacksModels.HttpResponse UpdateVendor(Vendors data)
        {
            string query = $@"UPDATE RR_VENDORS 
                          SET VENDOR_CODE = @VENDOR_CODE, VENDOR_NAME = @VENDOR_NAME, VENDOR_DESC = @VENDOR_DESC 
                          WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.VENDOR_ID);
            param.Add("VENDOR_CODE", data.VENDOR_CODE);
            param.Add("VENDOR_NAME", data.VENDOR_NAME);
            param.Add("VENDOR_DESC", data.VENDOR_DESC);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "UpdateVendor");
        }

        public static Models.ReturnableRacksModels.HttpResponse AddRack(Racks data)
        {
            string query = $@"INSERT INTO RR_RACKS (RACK_NAME, VENDOR_ID) 
                          VALUES (@RACK_NAME, @VENDOR_ID)";
            Dictionary<string, object?>? param = new();
            param.Add("RACK_NAME", data.RACK_NAME);
            param.Add("VENDOR_ID", data.VENDOR_ID);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddRack");
        }

        public static Models.ReturnableRacksModels.HttpResponse DeleteRack(Racks data)
        {
            string query = $@"DELETE FROM RR_RACKS WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.RACK_ID);
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteRack");
        }

        public static Models.ReturnableRacksModels.HttpResponse UpdateRack(Racks data)
        {
            string query = $@"UPDATE RR_RACKS 
                          SET RACK_NAME = @RACK_NAME, VENDOR_ID = @VENDOR_ID 
                          WHERE ID = @ID";
            Dictionary<string, object?>? param = new();
            param.Add("ID", data.RACK_ID);
            param.Add("RACK_NAME", data.RACK_NAME);
            param.Add("VENDOR_ID", data.VENDOR_ID);
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "UpdateRack");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllRacks()
        {
            string query = $@"SELECT ID AS RACK_ID, * FROM RR_RACKS";
            List<Racks> list = SQLService.SelectMethod<Racks>(query);
            return new Models.ReturnableRacksModels.HttpResponse(list, "Ok", false, "GetAllRacks");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllCarriers()
        {
            string query = "SELECT ID AS CARRIER_ID, * FROM RR_CARRIERS";
            List<Carriers> list = SQLService.SelectMethod<Carriers>(query);
            return new Models.ReturnableRacksModels.HttpResponse(list, "Ok", false, "GetAllCarriers");
        }

        public static Models.ReturnableRacksModels.HttpResponse AddCarrier(Carriers data)
        {
            string query = "INSERT INTO RR_CARRIERS (CARRIER_CODE, CARRIER_NAME, CARRIER_DESC) VALUES (@CARRIER_CODE, @CARRIER_NAME, @CARRIER_DESC)";
            Dictionary<string, object?> param = new Dictionary<string, object?>
        {
            { "CARRIER_CODE", data.CARRIER_CODE },
            { "CARRIER_NAME", data.CARRIER_NAME },
            { "CARRIER_DESC", data.CARRIER_DESC }
        };
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "AddCarrier");
        }

        public static Models.ReturnableRacksModels.HttpResponse UpdateCarrier(Carriers data)
        {
            string query = "UPDATE RR_CARRIERS SET CARRIER_CODE = @CARRIER_CODE, CARRIER_NAME = @CARRIER_NAME, CARRIER_DESC = @CARRIER_DESC WHERE ID = @ID";
            Dictionary<string, object?> param = new Dictionary<string, object?>
        {
            { "ID", data.CARRIER_ID },
            { "CARRIER_CODE", data.CARRIER_CODE },
            { "CARRIER_NAME", data.CARRIER_NAME },
            { "CARRIER_DESC", data.CARRIER_DESC }
        };
            SQLService.UpdateMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "UpdateCarrier");
        }

        public static Models.ReturnableRacksModels.HttpResponse DeleteCarrier(Carriers data)
        {
            string query = "DELETE FROM RR_CARRIERS WHERE ID = @ID";
            Dictionary<string, object?> param = new Dictionary<string, object?>
        {
            { "ID", data.CARRIER_ID }
        };
            SQLService.DeleteMethod(query, param);
            return new Models.ReturnableRacksModels.HttpResponse(true, "Ok", false, "DeleteCarrier");
        }

        public static Models.ReturnableRacksModels.HttpResponse GetAllOperadores()
        {
            try
            {
                string query = $@"select O.ID AS OPERADOR_ID, O.[NAME] AS OPERADOR_NAME,
                                    A.AREA_CODE, R.ROLE_NAME, A.ID AS AREA_ID, R.ID AS ROLE_ID
                                    FROM [dbo].[RR_OPERADORES] AS O
                                    INNER JOIN [dbo].RR_ROLES AS R 
                                    ON R.ID = O.ROLE_ID
                                    INNER JOIN [dbo].RR_AREAS AS A
                                    ON A.ID = O.AREA_ID";
                List<Operadores> operadores = SQLService.SelectMethod<Operadores>(query);
                return new Models.ReturnableRacksModels.HttpResponse(operadores, "Operadores obtenidos correctamente", false, "GetAllOperadores");
            }
            catch (Exception ex)
            {
                return new Models.ReturnableRacksModels.HttpResponse(null, ex.Message, true, "GetAllOperadores");
            }
        }

        public static Models.ReturnableRacksModels.HttpResponse AddOperador(Operadores data)
        {
            try
            {
                string query = "INSERT INTO RR_OPERADORES (NAME, ROLE_ID, AREA_ID) VALUES (@Name, @RoleId, @AreaId)";
                Dictionary<string, object?> parameters = new Dictionary<string, object?>();
                parameters.Add("@Name", data.OPERADOR_NAME);
                parameters.Add("@RoleId", data.ROLE_ID);
                parameters.Add("@AreaId", data.AREA_ID);
                SQLService.UpdateMethod(query, parameters);
                return new Models.ReturnableRacksModels.HttpResponse(true, "Operador agregado correctamente", false, "AddOperador");
            }
            catch (Exception ex)
            {
                return new Models.ReturnableRacksModels.HttpResponse(null, ex.Message, true, "AddOperador");
            }
        }

        public static Models.ReturnableRacksModels.HttpResponse UpdateOperador(Operadores data)
        {
            try
            {
                string query = "UPDATE RR_OPERADORES SET NAME = @Name, ROLE_ID = @RoleId, AREA_ID = @AreaId WHERE ID = @OperadorId";
                Dictionary<string, object?> parameters = new Dictionary<string, object?>();
                parameters.Add("@Name", data.OPERADOR_NAME);
                parameters.Add("@RoleId", data.ROLE_ID);
                parameters.Add("@AreaId", data.AREA_ID);
                parameters.Add("@OperadorId", data.OPERADOR_ID);
                SQLService.UpdateMethod(query, parameters);
                return new Models.ReturnableRacksModels.HttpResponse(true, "Operador actualizado correctamente", false, "UpdateOperador");
            }
            catch (Exception ex)
            {
                return new Models.ReturnableRacksModels.HttpResponse(null, ex.Message, true, "UpdateOperador");
            }
        }

        public static Models.ReturnableRacksModels.HttpResponse DeleteOperador(Operadores data)
        {
            try
            {
                string query = "DELETE FROM RR_OPERADORES WHERE ID = @OperadorId";
                Dictionary<string, object?> parameters = new Dictionary<string, object?>();
                parameters.Add("@OperadorId", data.OPERADOR_ID);
                SQLService.DeleteMethod(query, parameters);
                return new Models.ReturnableRacksModels.HttpResponse(true, "Operador eliminado correctamente", false, "DeleteOperador");
            }
            catch (Exception ex)
            {
                return new Models.ReturnableRacksModels.HttpResponse(null, ex.Message, true, "DeleteOperador");
            }
        }
    }
}
