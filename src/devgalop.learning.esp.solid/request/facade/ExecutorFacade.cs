using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devgalop.learning.esp.solid.request.strategy;

namespace devgalop.learning.esp.solid.request.facade
{
    public sealed class ExecutorFacade(
        StateExecutorContext executorContext
    )
    {
        private readonly Dictionary<int, ERequestState> _stateAllowed = new()
        {
            {1, ERequestState.DRAFT},
            {2, ERequestState.SUBMITTED},
            {3, ERequestState.UNDER_REVIEW}
        };

        /// <summary>
        /// Ejecuta el proceso según el estado actual del request. El método delega la ejecución a la estrategia correspondiente, que se determina en función del estado del request. Cada estrategia implementa la lógica específica para manejar el request en ese estado particular.
        /// </summary>
        /// <param name="request">El request que se desea procesar.</param>
        /// <returns>El request procesado con el estado actualizado.</returns>
        public Request Execute(Request request)
        {
            return executorContext.Execute(request);
        }

        /// <summary>
        /// Retorna los estados pendientes para un request dado, es decir, aquellos estados que aún no han sido alcanzados. Si el request ya se encuentra en un estado final (APROBADO o RECHAZADO), se devuelve un conjunto vacío.
        /// </summary>
        /// <param name="request">El request para el cual se desean obtener los estados pendientes.</param>
        /// <returns>Un conjunto de cadenas que representan los estados pendientes.</returns>
        public HashSet<string> GetPendingStates(Request request)
        {
            if(request.State == ERequestState.APPROVED || request.State == ERequestState.REJECTED)
                return new HashSet<string>();
            int currentStateValue = _stateAllowed.FirstOrDefault(kv => kv.Value == request.State).Key;
            return [.. _stateAllowed.Where(kv => kv.Key > currentStateValue).Select(kv => kv.Value.ToString())];
        }

    }
}