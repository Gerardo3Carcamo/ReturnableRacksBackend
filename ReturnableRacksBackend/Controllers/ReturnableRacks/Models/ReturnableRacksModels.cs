namespace ReturnableRacksBackend.Controllers.ReturnableRacks.Models
{
    public class ReturnableRacksModels
    {

        public class HttpResponse
        {
            public object? data { get; set; } = null;
            public string? message { get; set; } = string.Empty;
            public bool error { get; set; } = false;
            public string? apiName { get; set; } = "";
            public HttpResponse(){}
            public HttpResponse(object? data, string message, bool error, string apiName)
            {
                this.data = data;
                this.message = message;
                this.error = error;
                this.apiName = apiName;
            }
        }

        public class Roles
        {
            public int ROLE_ID { get; set; }
            public string? ROLE_NAME { get; set; }
        }

        public class Areas
        {
            public int AREA_ID { get; set; }
            public string? AREA_DESC { get;set; }
            public string? AREA_CODE { get; set; }
        }
        public class Rampas
        {
            public int RAMPA_ID { get; set; }
            public int DOCK_NUMBER { get; set; }
            public int? AREA_ID { get; set; }
            public string? AREA_CODE { get; set; }
        }

        public class Vendors
        {
            public int VENDOR_ID { get; set; }
            public string? VENDOR_DESC { get; set; }
            public string? VENDOR_CODE { get; set; }
            public string? VENDOR_NAME { get; set; }
        }
        public class Racks
        {
            public int RACK_ID { get; set; }
            public string? RACK_NAME { get; set; }
            public int VENDOR_ID { get; set; }
            public string? VENDOR_CODE { get; set; }
        }
        public class Carriers
        {
            public int CARRIER_ID { get; set; }
            public string? CARRIER_DESC { get; set; }
            public string? CARRIER_CODE { get;set; }
            public string? CARRIER_NAME { get;set; }
        }
        public class Operadores
        {
            public int OPERADOR_ID { get; set; }
            public string? OPERADOR_NAME { get; set; }
            public int ROLE_ID { get; set; }
            public int AREA_ID { get; set; }
            public string? AREA_CODE { get; set; }
            public string? ROLE_NAME { get; set; }
            public string? TOKEN { get; set; }
            public string? PASSWORD { get; set; }
        }
        public class Inspecciones
        {
            public int ID { get; set; }
            public string? FOLIO { get; set; }
            public string? SELLO1 { get; set; }
            public string? SELLO2 { get; set; }
            public int ENTRY_CUBE {  get; set; }
            public int LEAVE_CUBE { get; set; }
            public DateTime TS_LOAD { get; set; }
            public int CARRIER_ID {  get; set; }
            public string? CARRIER_CODE { get; set; }
            public string? OPERADOR_ID { get; set; }
            public string? NAME { get; set; }
            public int VENDOR_ID {  get; set; }
            public string? VENDOR_CODE { get; set; }
            public int RAMPA_ID { get; set; }
            public string? RAMP_NUMBER { get; set; }
            public string? MOVEMENT_TYPE { get; set; }
            public string? EXIT_TYPE {  get; set; }
            public List<RacksCargados?>? RACKS {  get; set; }
        }
        public class RacksCargados
        {
            public int ID { get; set; }
            public int RACK_ID { get; set; }
            public string? RACK_NAME { get; set; }
            public int COUNT { get; set; }
        }
        public class DatesFilter
        {
            public DateTime? START_DATE { get; set; }
            public DateTime? END_DATE { get; set; }
        }
        public class StackedCharts
        {
            public int TOTAL { get; set; }
            public string? LABELS { get; set; }
            public string? DATA { get; set; }
        }
        public class RacksSent
        {
            public int TOTAL { get; set; }
            public string? VENDOR_CODE { get; set; }
            public DateTime TS_LOAD { get; set; }
        }
    }
}
