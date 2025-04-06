using Chapter9.Interfaces;
using Newtonsoft.Json;

namespace Chapter9.Middlewares;

public class CustomRouteHandler(IShipmentService shipmentService) : IRouter
{
    public async Task RouteAsync(RouteContext context)
    {
        var path = (context.HttpContext.Request.Path.Value ?? "").Trim('/');
        var segments = path.Split('/');

        if (segments.Length == 2 && segments[0] == "shipments")
        {
            var shipmentId = segments[1];
            if (shipmentService.ShhipmentExists(shipmentId))
            {
                context.Handler = async httpContext =>
                {
                    var shipment = await shipmentService.GetShipment(shipmentId);
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(shipment));
                };
            }
        }
        await Task.CompletedTask;
    }

    public VirtualPathData? GetVirtualPath(VirtualPathContext context) => null;
}
