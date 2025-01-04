using Chapter9.Interfaces;
using Newtonsoft.Json;

namespace Chapter9.Middlewares
{
    public class CustomRouteHandler : IRouter
    {
        private readonly IShipmentService _shipmentService;

        public CustomRouteHandler(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task RouteAsync(RouteContext context)
        {
            var path = context.HttpContext.Request.Path.Value.Trim('/');
            var segments = path.Split('/');

            if (segments.Length == 2 && segments[0] == "shipments")
            {
                var shipmentId = segments[1];
                if (_shipmentService.ShhipmentExists(shipmentId))
                {
                    context.Handler = async httpContext =>
                    {
                        var shipment = await _shipmentService.GetShipment(shipmentId);
                        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(shipment));
                    };
                }
            }
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
