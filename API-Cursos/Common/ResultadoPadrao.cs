namespace API_Cursos.Common
{
    public class ResultadoPadrao<T>
    {
        public bool Sucesso {  get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public T? Dados { get; set; }
        public int StatusCode { get; set; }


        public static ResultadoPadrao<T> Ok(T? dados = default, string? mensagem = null, int statusCode = 200)
        {
            return new ResultadoPadrao<T>
            {
                Sucesso = true,
                Dados = dados,
                Mensagem = mensagem,
                StatusCode = statusCode
            };
        }

        public static ResultadoPadrao<T> Falha(string mensagem, int statusCode = 400)
        {
            return new ResultadoPadrao<T>
            {
                Sucesso = false,
                Mensagem = mensagem,
                StatusCode = statusCode
            };
        }
    }
}
