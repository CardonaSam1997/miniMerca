namespace miniMercado.Model
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }         // Indica si la operación fue exitosa
        public string Message { get; set; }      // Mensaje de respuesta (éxito o error)
        public T Data { get; set; }
    }
}
