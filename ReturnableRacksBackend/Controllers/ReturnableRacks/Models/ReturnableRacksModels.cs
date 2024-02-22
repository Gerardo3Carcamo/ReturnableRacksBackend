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
            public HttpResponse(object data, string message, bool error, string apiName)
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
        }
    }
}
