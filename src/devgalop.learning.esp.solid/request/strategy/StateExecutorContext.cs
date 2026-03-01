using devgalop.learning.esp.solid.request.validator;

namespace devgalop.learning.esp.solid.request.strategy
{
    public class StateExecutorContext(
        IEnumerable<IRuleValidator> validators
    )
    {
        public Request Execute(Request request)
        {
            var strategy = GetStrategy(request);
            return strategy.Execute(request);
        }
        
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