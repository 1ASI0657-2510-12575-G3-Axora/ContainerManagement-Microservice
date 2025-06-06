using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlertInstanceController : ControllerBase
    {
         /// <summary>
        /// Acknowledges an alert instance by its ID.
        /// </summary>
        /// <param name="alertInstanceId">The unique identifier of the alert instance to acknowledge.</param>
        /// <param name="command">The command containing the details necessary to acknowledge the alert.</param>
        /// <returns>A task representing the asynchronous operation, containing the acknowledged alert resource.</returns>
        [HttpPost]
        [Route("{alertInstanceId}/ack")]
        public Task<ActionResult<AlertResource>> AcknowledgeAlert([FromRoute]int alertId, [FromBody]AcknowledgeAlertCommand command)
        {
            throw new NotImplementedException();
        }
          /// <summary>
        /// Dismisses an alert instance by its ID.
        /// </summary>
        /// <param name="alertInstanceId">The unique identifier of the alert instance to dismiss.</param>
        /// <param name="command">The command containing the details necessary to dismiss the alert.</param>
        /// <returns>A task representing the asynchronous operation, containing the dismissed alert resource.</returns>

        [HttpPost]
        [Route("{alertInstanceId}/dismiss")]
        public Task<ActionResult<AlertResource>> DismissAlert([FromRoute]int alertId, [FromBody]DismissAlertCommand command)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retrieves a list of active alerts.
        /// </summary>
        /// <param name="query">The query object containing the parameters for fetching active alerts.</param>
        /// <returns>A task representing the asynchronous operation, containing a collection of active alert resources.</returns>

        [HttpGet]
        public Task<ActionResult<IEnumerable<AlertResource>>> GetActiveAlerts([FromBody]GetActiveAlertsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
