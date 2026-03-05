using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.request.strategy
{
    /// <summary>
    /// Interfaz que define la estrategia de ejecución para los diferentes estados de un request.
    /// </summary>
    public interface IStateExecutorStrategy
    {
        /// <summary>
        /// Ejecuta la lógica especifica para el estado actual del request. Cada implementación de esta interfaz representa una estrategia diferente para manejar el request en un estado particular.
        /// </summary>
        /// <param name="request">El request que se va a procesar.</param>
        /// <returns>El request procesado con el estado actualizado.</returns>
        Request Execute(Request request);
    }
}