using devgalop.learning.esp.solid.request.validator;

namespace devgalop.learning.esp.solid.request.strategy
{
    public class StateExecutorContext(
        IEnumerable<IRuleValidator> validators
    )
    {
        /// <summary>
        /// Ejecuta el proceso según el estado actual del request. El método delega la ejecución a la estrategia correspondiente, que se determina en función del estado del request. Cada estrategia implementa la lógica específica para manejar el request en ese estado particular.
        /// </summary>
        /// <param name="request">El request que se va a procesar.</param>
        /// <returns>El request procesado con el estado actualizado.</returns>
        public Request Execute(Request request)
        {
            var strategy = GetStrategy(request);
            return strategy.Execute(request);
        }
        
        /// <summary>
        /// Determina y retorna la estrategia de ejecución adecuada según el estado actual del request. Utiliza un switch para mapear cada estado a su correspondiente estrategia. Si el estado del request no tiene una estrategia implementada, se lanza una excepción indicando que la estrategia no está implementada para ese estado.
        /// </summary>
        /// <param name="request">El request para el cual se determinará la estrategia.</param>
        /// <returns>La estrategia de ejecución correspondiente al estado del request.</returns>
        /// <exception cref="NotImplementedException">Se lanza cuando no hay una estrategia implementada para el estado del request.</exception>
        private IStateExecutorStrategy GetStrategy(Request request)
        {
            return request.State switch
            {
                ERequestState.DRAFT => new DraftStrategy(),
                ERequestState.SUBMITTED => new SubmittedStrategy(),
                ERequestState.UNDER_REVIEW => new UnderReviewStrategy(validators),
                _ => throw new NotImplementedException($"Estrategia no implementada para el estado {request.State}")
            };
        }
    }
}